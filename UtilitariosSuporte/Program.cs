using Autofac;
using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Login;
using UtilitariosSuporte.Features.Login.Presenter;
using UtilitariosSuporte.Features.Login.View;

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

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var view = scope.Resolve<ILoginView>();
                var presenter = scope.Resolve<LoginPresenter>();

                presenter.SetView(view);

                Application.Run((Form)view);
            }
        }
    }
}
