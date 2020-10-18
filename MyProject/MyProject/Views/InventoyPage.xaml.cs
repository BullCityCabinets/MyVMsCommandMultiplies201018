using MyProject.Framework;
using MyProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoyPage : ContentPage
    {
        public InventoyPage()
        {
            InitializeComponent();
            BindingContext = App.MyInventoryVM;
        }
    }
}