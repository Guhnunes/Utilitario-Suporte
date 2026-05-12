using Autofac;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using System.Threading.Tasks;
using UtilitariosSuporte.Features.CaminhoFiscal;
using UtilitariosSuporte.Features.CaminhoFiscal.Presenter;
using UtilitariosSuporte.Features.CaminhoFiscal.Repositories;
using UtilitariosSuporte.Features.CaminhoFiscal.View;
using UtilitariosSuporte.Features.Compartilhamento;
using UtilitariosSuporte.Features.Compartilhamento.Presenter;
using UtilitariosSuporte.Features.Compartilhamento.View;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Login;
using UtilitariosSuporte.Features.Login.Presenter;
using UtilitariosSuporte.Features.Login.View;
using UtilitariosSuporte.Features.Menu;
using UtilitariosSuporte.Features.Menu.Presenter;
using UtilitariosSuporte.Features.Menu.View;

namespace UtilitariosSuporte
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // --- INÍCIO DA LÓGICA DE AUTO-ELEVAÇÃO ---
            if (!IsAdministrator())
            {
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas" // Força o prompt do Windows (UAC)
                };

                try
                {
                    Process.Start(processInfo);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // O usuário clicou em "Não" no prompt do UAC
                    MessageBox.Show("Este utilitário precisa de privilégios de administrador para aplicar correções de rede e sistema.",
                                    "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // Encerra a instância sem privilégios
            }
            // --- FIM DA LÓGICA DE AUTO-ELEVAÇÃO ---
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Sempre alterar aqui e no version.txt antes de subir uma nova versão no git
            string versaoLocal = "1.2.0";
            bool estaAtualizado = await VerificadorAtualizacao.IsVersaoAtualizada(versaoLocal);

            if (!estaAtualizado)
            {
                var resultado = MessageBox.Show(
                    "Existe uma nova versão disponível no GitHub! Deseja baixar agora?",
                    "Atualização Disponível",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {
                    // Abre o navegador no link do repositório
                    Process.Start("https://github.com/Guhnunes/Utilitario-Suporte/blob/master/UtilitariosSuporte/bin/Release/app.publish/UtilitariosSuporte.exe");
                    return; // Fecha o app para o usuário instalar a nova
                }
            }

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string caminhoIni = Path.Combine(appData, "SGC_Config.ini");
            var sgcConfig = new SgcConfig(caminhoIni);
            string stringConexaoFirebird = sgcConfig.ObterStringConexao();
            if (string.IsNullOrEmpty(stringConexaoFirebird))
            {
                MessageBox.Show($"Erro ao tentar conectar banco de dados!\nCaminho buscado: {caminhoIni}",
                                "Erro fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var builder = new ContainerBuilder();

            //REGISTRO DE CONEXÃO
            builder.RegisterType<FabricaDeConexao>()
                   .As<IFabricaDeConexao>()
                   .WithParameter("stringDeConexao", stringConexaoFirebird)
                   .SingleInstance();
            //LOGIN
            builder.RegisterType<FormLogin>().As<ILoginView>();
            builder.RegisterType<LoginPresenter>();

            //MENU
            builder.RegisterType<FormMenu>().As<IMenuView>();
            builder.RegisterType<MenuPresenter>();

            //DIR FISCAL
            builder.RegisterType<FormDirFiscal>().As<IDirFiscalView>();
            builder.RegisterType<CaminhoFiscalPresenter>();
            builder.RegisterType<CaminhoFiscalRepository>().As<ICaminhoFiscalRepository>();

            //COMPARTILHAMENTO
            builder.RegisterType<FormCompartilhamento>().As<ICompartilhamentoView>();
            builder.RegisterType<CompartilhamentoPresenter>().AsSelf();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var loginView = scope.Resolve<ILoginView>();
                var loginPresenter = scope.Resolve<LoginPresenter>();
                loginPresenter.SetView(loginView);

                Application.Run((Form)loginView);

                if (((Form)loginView).DialogResult == DialogResult.OK)
                {
                    var menuView = scope.Resolve<IMenuView>();
                    var menuPresenter = scope.Resolve<MenuPresenter>();
                    menuPresenter.SetView(menuView);

                    Application.Run((Form)menuView);
                }
            }
        }
        /// <summary>
        /// Verifica se o processo atual possui privilégios de administrador.
        /// </summary>
        private static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
