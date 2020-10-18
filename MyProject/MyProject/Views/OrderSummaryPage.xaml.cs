
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderSummaryPage : ContentPage
    {
        public OrderSummaryPage()
        {
            InitializeComponent();
            BindingContext = App.MyOrderSummaryVM;
        }
    }
}