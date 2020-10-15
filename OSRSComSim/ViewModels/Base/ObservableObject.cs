using PropertyChanged;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace OSRSComSim
{
    /// <summary>
    /// Class that casts "PropertyChanged" event when needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is casted when any child property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (IChannelSender, e) => { };
    }
}
