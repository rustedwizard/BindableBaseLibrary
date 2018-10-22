using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindableBaseLibrary
{
    /// <summary>
    /// 
    ///     Implementation of <see cref="INotifyPropertyChanged" /> to simplify models.
    ///     
    ///     This abstract class is designed to be used
    ///     whenever implement INotifyPropertyChanged interface
    ///     is necessary for an class, this class saves the work
    ///     of implement that interface over and over again.
    ///     
    ///     This class is designed to be abstract given the fact that
    ///     there is not real meanning to instantiated it.
    ///     
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     Declare the event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Checks if a property already matches a desired value.  Sets the property and
        ///     notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to the property need the value change </param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.
        /// By defautlt it would be caller memeber's name.</param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the
        ///     desired value.
        /// </returns>
        protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if(Equals(field, value))
            {
                return false;
            }
            else
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }

        /// <summary>
        ///     Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners./>.
        /// </param>
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
