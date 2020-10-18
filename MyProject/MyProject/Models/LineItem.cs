

namespace MyProject.Models
{
    public class LineItem : Inventory
    {
        private int _orderId { get; set; }
        public int OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                RaisePropertyChanged(nameof(OrderId));
            }
        }

        private int _qty { get; set; }
        public int Qty
        {
            get => _qty;
            set
            {
                _qty = value;
                RaisePropertyChanged(nameof(Qty));
            }
        }


        //This can be used to reduce code when the inventory items are added to an order summary...
        public LineItem(Inventory inventory) 
        {
            this.Name = inventory.Name;
            this.Condition = inventory.Condition;

            this.OrderId = 1;
            this.Qty = 1;
        }

    }


}
