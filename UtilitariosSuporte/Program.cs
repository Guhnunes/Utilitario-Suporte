using Autofac;
using System;
using System.IO;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Login;
using UtilitariosSuporte.Features.Login.Presenter;
using UtilitariosSuporte.Features.Login.View;
using UtilitariosSuporte.Features.Menu;
using UtilitariosSuporte.Features.Menu.Presenter;
using UtilitariosSuporte.Features.Menu.View;
using UtilitariosSuporte.Features.CaminhoFiscal;
using UtilitariosSuporte.Features.CaminhoFiscal.Presenter;
using UtilitariosSuporte.Features.CaminhoFiscal.Repositories;
using UtilitariosSuporte.Features.CaminhoFiscal.View;

namespace UtilitariosSuporte
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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

            // Registra os componentes
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
            builder.RegisterType<FormDirFiscal>().As<ICaminhoFiscalView>();
            builder.RegisterType<CaminhoFiscalPresenter>();
            builder.RegisterType<CaminhoFiscalRepository>().As<ICaminhoFiscalRepository>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                // 1. Resolve e executa o Login
                var loginView = scope.Resolve<ILoginView>();
                var loginPresenter = scope.Resolve<LoginPresenter>();
                loginPresenter.SetView(loginView);

                Application.Run((Form)loginView);

                // 2. Verifica se o login foi bem sucedido (DialogResult.OK)
                if (((Form)loginView).DialogResult == DialogResult.OK)
                {
                    // 3. Resolve e executa o Menu
                    var menuView = scope.Resolve<IMenuView>();
                    var menuPresenter = scope.Resolve<MenuPresenter>();
                    menuPresenter.SetView(menuView);

                    Application.Run((Form)menuView);
                }
            }
        }
    }
}
