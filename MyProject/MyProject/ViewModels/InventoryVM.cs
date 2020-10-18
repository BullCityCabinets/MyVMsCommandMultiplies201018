using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyProject.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.ViewModels
{
    public class InventoryVM: BaseVM
    {
        //~~ Data Source...
        public ObservableCollection<Inventory> InventoryDisplayed { get; set; }

        //~~ Selecting Items...              
        public ObservableCollection<object> MySelectedItems { get; set; }   //Captures CollectionView's multiple selection
        public ICommand MySelectionChangedCommand { get; set; }             //Fires on selection change

        //~~ CTOR
        public InventoryVM()
        {
            //~~ Data Source...
            this.InventoryDisplayed = new ObservableCollection<Inventory>(App.InventoryService.GetAllInventory());  

            //~~ Selecting Items...
            this.MySelectedItems = new ObservableCollection<object>() { /* I think "pre-selections" go here */};
            MySelectionChangedCommand = new Command<object>(OnMySelectionChangedCommand);

    
        }

        //~~ Selecting Items...              

        public int OnMySelectionChangedCommandCount;
        private void OnMySelectionChangedCommand(object selectedItems)
        {
            OnMySelectionChangedCommandCount++;
            Debug.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Debug.WriteLine("~~~ OnMySelectionChangedCommandCount++ ... " + OnMySelectionChangedCommandCount);

            var previous = App.MyOrderSummary.Unsorted;
            var current = MySelectedItems;
            Debug.WriteLine("~~~ InventoryVM: App.MyOrderSummary.Unsorted (previous)..." + App.MyOrderSummary.Unsorted.Count);
            Debug.WriteLine("~~~ InventoryVM: MySelectedItems             (current) ..." + MySelectedItems.Count);

            if (previous.Count != current.Count)
            {
                List<object> ItemsChanged = new List<object>();
                object changed = new object();

                if (previous.Count < current.Count)
                {
                    ItemsChanged = current.Except(previous).ToList();
                    foreach (var c in ItemsChanged)  // ItemsChanged is always a list of 1 object
                    {
                        changed = c;
                        App.MyOrderSummary.Unsorted.Add((Inventory)changed);
                        Debug.WriteLine("~~~ InventoryVM: App.MyOrderSummary.Unsorted.Add !");
                        MessageOrderSummary(changed);
                    }
                }
                else if (previous.Count > current.Count)
                {
                    ItemsChanged = previous.Except(current).ToList();
                    foreach (var c in ItemsChanged) // ItemsChanged is always a list of 1 object
                    {
                        changed = c;
                        App.MyOrderSummary.Unsorted.Remove((Inventory)changed);
                        Debug.WriteLine("~~~ InventoryVM: App.MyOrderSummary.Unsorted.Remove !");                        
                        MessageOrderSummary(changed);
                    }
                }

            }

        }

        public int SentMessageCount;
        public void MessageOrderSummary(object changedItem)
        {
            MessagingCenter.Send<InventoryVM, object>(this, "MessageOrderSummary", changedItem);
            SentMessageCount++;
            Debug.WriteLine("~~~ MessageOrderSummaryAdd called... total messages sent...   " + SentMessageCount);
        }



    }
}
