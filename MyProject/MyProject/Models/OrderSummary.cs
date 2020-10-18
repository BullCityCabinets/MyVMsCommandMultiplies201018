using System.Collections.ObjectModel;

namespace MyProject.Models
{
    public class OrderSummary : BindableBase
    {
        private ObservableCollection<Inventory> _unsorted { get; set; }
        public ObservableCollection<Inventory> Unsorted
        {
            get => _unsorted;
            set
            {
                _unsorted = value;
                RaisePropertyChanged(nameof(Unsorted));
            }
        }


        public OrderSummary()
        {
        }
    }


}
