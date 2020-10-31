using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DsCustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSqareMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public DSqareMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new DSqareMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DSqareMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DSqareMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public DSqareMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DSqareMasterDetailPageMasterMenuItem>(new[]
                {
                    new DSqareMasterDetailPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new DSqareMasterDetailPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new DSqareMasterDetailPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new DSqareMasterDetailPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new DSqareMasterDetailPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}