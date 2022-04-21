
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using ModernDashboard.Model;

namespace ModernDashboard.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private CollectionViewSource HomeItemsCollection;
        public ICollectionView HomeSourceCollection => HomeItemsCollection.View;

        public HomeViewModel()
        {           
            ObservableCollection<HomeItems> homeItems = new ObservableCollection<HomeItems>
            {
                new HomeItems { HomeName = "This PC", HomeImage = @"Assets/pc_icon.png" },               
            };

            HomeItemsCollection = new CollectionViewSource { Source = homeItems };
        }
    }

}