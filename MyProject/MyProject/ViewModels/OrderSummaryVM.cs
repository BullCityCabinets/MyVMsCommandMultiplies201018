using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using MyProject.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyProject.ViewModels
{
    public class OrderSummaryVM : BaseVM
    {
        //~~ Navigate ...
        public ICommand GoToInventory { get; set; }

        //~~ To Display App.MyOrderSummary.Unsorted ...
        public ObservableCollection<LineItem> LineItemsDisplayed { get; set; }

        //~~ CTOR ...
        public OrderSummaryVM()
        {            
            GoToInventory = new Command<string>(OnGoToInventory);

            LineItemsDisplayed = new ObservableCollection<LineItem>();

            //~~ Updates from InventoryPage ...
            MessagingCenter.Subscribe<InventoryVM, object>(this, "MessageOrderSummary", OnOrderChanged);
        }

        //~~ Navigate away ...
        private void OnGoToInventory(string obj)
        {
            App.NavigationService.NavigateTo("InventoryPage");
            
        }


        //~~ Updates from InventoryPage ...
        public int OnOrderChangedCount;
        private void OnOrderChanged(InventoryVM sender, object objectChanged)
        {
            OnOrderChangedCount++;
            Debug.WriteLine("~~~ OnOrderChanged called... total messages received..." + OnOrderChangedCount);

            var itemChanged = new LineItem((Inventory)objectChanged);
            Debug.WriteLine("~~~ itemChanged...Id# " + itemChanged.Id);
            Debug.WriteLine("~~~            ... " + itemChanged.Name);
            Debug.WriteLine("~~~            ... " + itemChanged.Condition);
            Debug.WriteLine("~~~" );


            bool contains = LineItemsDisplayed.Any(x => x.Name == itemChanged.Name);
            if (!contains)
            {
                LineItemsDisplayed.Add(itemChanged);
                Debug.WriteLine("~~~ OnOrderChanged Added a LineItem... + + + ");
            }
            else if (contains)
            {
                LineItemsDisplayed.Remove(LineItemsDisplayed.Where(x => x.Name == itemChanged.Name).First());
                Debug.WriteLine("~~~ OnOrderChanged Removed LineItem... - - - ");
            }


        }










    }
}
