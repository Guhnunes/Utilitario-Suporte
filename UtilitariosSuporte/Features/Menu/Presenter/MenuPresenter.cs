using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Login.Presenter;
using UtilitariosSuporte.Features.Menu.View;

namespace UtilitariosSuporte.Features.Menu.Presenter
{
    public class MenuPresenter : BasePresenter<IMenuView>
    {
        public MenuPresenter() : base(null)
        {
        }

        public override void SetView(IMenuView view)
        {
            base.SetView(view);
            // Aqui você assinará os eventos dos botões futuramente
        }
    }
}