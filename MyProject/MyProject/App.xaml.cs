using System.Collections.ObjectModel;
using Xamarin.Forms;
using MyProject.Framework;
using MyProject.Models;
using MyProject.Service;
using MyProject.Views;
using MyProject.ViewModels;

namespace MyProject
{
    public partial class App : Application
    {
        public static NavigationService NavigationService { get; } = new NavigationService();

        //~~ Data source ...
        public static InventoryService InventoryService { get; } = new InventoryService();        
        
        //~~ Data that would be recorded, if app was functional ...
        public static OrderSummary MyOrderSummary { get; set; } = new OrderSummary();

        //~~ Static View Models ... because I don't know what's calling the ItemsChanged multiple times, yet...
        public static OrderSummaryVM MyOrderSummaryVM { get; set; } = new OrderSummaryVM();
        public static InventoryVM MyInventoryVM { get; set; } = new InventoryVM { };

        public App()
        {
            InitializeComponent();

            //~~ Register pages with Navigation Service ...
            NavigationService.Configure(ViewNames.OrderSummaryPage, typeof(OrderSummaryPage));
            NavigationService.Configure(ViewNames.InventoryPage, typeof(InventoyPage));

            //~~ Used to track changes to SelectedItems ...
            MyOrderSummary.Unsorted = new ObservableCollection<Inventory>();

            InitializeComponent();

            MainPage = new NavigationPage(new OrderSummaryPage());
        }


    }
}
