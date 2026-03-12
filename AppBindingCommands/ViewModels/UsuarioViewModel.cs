using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace AppBindingCommands.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name = string.Empty;

        public string Name 
        { 
            get => name;
            set
            {
                if (name == null)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Nome digitado:{Name}";
    }
}
