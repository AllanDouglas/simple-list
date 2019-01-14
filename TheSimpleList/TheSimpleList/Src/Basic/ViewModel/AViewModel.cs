using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheSimpleList.Src.Basic.ViewModel
{
    public abstract class AViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
