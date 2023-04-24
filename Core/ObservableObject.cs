using System.ComponentModel; // Import the INotifyPropertyChanged interface
using System.Runtime.CompilerServices; // Import the CallerMemberName attribute

namespace AssetsView.Core
{
    // Define a class called ObservableObject that implements INotifyPropertyChanged
    class ObservableObject : INotifyPropertyChanged
    {
        // Define an event called PropertyChanged of type PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        // Define a protected method called OnPropertyChanged that raises the PropertyChanged event
        // The [CallerMemberName] attribute allows the name parameter to be omitted when the method is called
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            // Invoke the PropertyChanged event, passing in this object as the sender and the property name as the event argument
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
