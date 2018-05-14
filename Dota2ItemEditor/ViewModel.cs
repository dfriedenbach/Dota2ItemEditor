using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dota2ItemEditor
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ThrowOnInvalidPropertyName { get; set; } = true;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void VerifyPropertyName(string propertyName)
        {
            if (ThrowOnInvalidPropertyName && TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new Exception("Invalid property name: " + propertyName);
            }
        }
    }

    public class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Dota2Item>();
        }
        public ObservableCollection<Dota2Item> Items { get; }

        private void newItem(string name = "item_new")
        {
            Items.Add(new Dota2Item(name));
        }

        private Command _newItemCommand;
        public ICommand NewItemCommand
        {
            get
            {
                if (_newItemCommand == null)
                {
                    _newItemCommand = new Command(param => this.newItem());
                }
                return _newItemCommand;
            }
        }
    }

}
