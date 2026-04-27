using Autofac;
using System;
using System.Windows.Forms;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();

            // Registra os componentes
            //LOGIN
            builder.RegisterType<FormLogin>().As<ILoginView>();
            builder.RegisterType<LoginPresenter>();

            //MENU
            builder.RegisterType<FormMenu>().As<IMenuView>();
            builder.RegisterType<MenuPresenter>();

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
