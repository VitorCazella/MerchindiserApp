using MerchindiserApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MerchindiserApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}