using System.ComponentModel;
using Xamarin.Forms;
using DsVendor.ViewModels;

namespace DsVendor.Views
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