using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LazyApiPack.Utils.ComponentModel
{
    /// <summary>
    /// Provides a class that notifies when a property changes.
    /// </summary>
    [DebuggerStepThrough]
    public abstract class NotifyObject : INotifyPropertyChanging, INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Raised when a property is changing.
        /// </summary>
        public event PropertyChangingEventHandler? PropertyChanging;
        /// <summary>
        /// Sets a property to a specific value.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="backingField">Reference to the backingfield.</param>
        /// <param name="newValue">The new value for the backingfield.</param>
        /// <param name="propertyName">Name of the property (leave empty if the calling member name should be used).</param>
        /// <returns>True if the property has changed or false, if not.</returns>
        protected virtual bool SetPropertyValue<T>(ref T backingField, T newValue, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, newValue))
            {
                return false;
            }

            var oldValue = backingField;
            OnPropertyChanging(oldValue, newValue, propertyName);

            backingField = newValue;

            OnPropertyChanged(oldValue, newValue, propertyName);
            return true;
        }

        /// <summary>
        /// Raises the property changed event with the caller member name and this as the sender.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="oldValue">Value that has been replaced.</param>
        /// <param name="newValue">New value.</param>
        /// <param name="propertyName">Name of the property that has been changed.</param>
        protected virtual void OnPropertyChanged(object? oldValue, object? newValue, [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raised when a property is changing.
        /// </summary>
        /// <param name="propertyName">Property name or the caller member name if left out.</param>
        protected virtual void OnPropertyChanging([CallerMemberName] string? propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        /// Raised when a property is changing
        /// </summary>
        /// <param name="oldValue">The value that is being replaced.</param>
        /// <param name="newValue">The value that is being replaced with.</param>
        /// <param name="propertyName">Name of the property that is changing or the caller member name if left out.</param>
        protected virtual void OnPropertyChanging(object? oldValue, object? newValue, [CallerMemberName] string? propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        }


    }
}