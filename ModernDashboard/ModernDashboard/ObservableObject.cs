using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModernDashboard
{
    public class ObservableObject : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
