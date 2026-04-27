namespace UtilitariosSuporte.Features.Infraestrutura
{
    public abstract class BasePresenter<TView>
    {
        protected TView View;
        protected BasePresenter(TView view) => View = view;
        public virtual void SetView(TView view) => View = view;
    }
}