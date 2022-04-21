
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using ModernDashboard.Model;

namespace ModernDashboard.ViewModel
{
    public class MovieViewModel : ObservableObject
    {
        private CollectionViewSource MovieItemsCollection;
        public ICollectionView MovieSourceCollection => MovieItemsCollection.View;

        public MovieViewModel()
        {           
            ObservableCollection<MovieItems> movieItems = new ObservableCollection<MovieItems>
            {

                new MovieItems { MovieName = "Action", MovieImage = @"Assets/clap_icon.png" },
                new MovieItems { MovieName = "Thriller", MovieImage = @"Assets/clap_icon.png" },
                new MovieItems { MovieName = "Adventure", MovieImage = @"Assets/clap_icon.png" },
                new MovieItems { MovieName = "Drama", MovieImage = @"Assets/clap_icon.png" },
                new MovieItems { MovieName = "Fantasy", MovieImage = @"Assets/clap_icon.png" },
                new MovieItems { MovieName = "Mystery", MovieImage = @"Assets/clap_icon.png" }

            };

            MovieItemsCollection = new CollectionViewSource { Source = movieItems };
            MovieItemsCollection.Filter += MenuItems_Filter;

        }

        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MovieItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            MovieItems _item = e.Item as MovieItems;
            if (_item.MovieName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

    }
}
