using System;

namespace Kitchenator.Web.PropertyManager.Components
{
    public class ViewModel<TInstance>
    {
        public EventHandler<TInstance> OnChange;        

        TInstance _instance;

        public ViewModel(TInstance instance)
        {
            Instance = instance;
        }

        public TInstance Instance
        {
            get { return _instance; }
            set
            {
                _instance = value;
                AnnounceChange();
            }
        }

        private void AnnounceChange()
        {
            OnChange?.Invoke(this, Instance);
        }
    }
}