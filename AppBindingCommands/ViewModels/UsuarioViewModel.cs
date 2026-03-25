using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

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

        public string displayMessage = string.Empty;

        public string DisplayMessage
        {
            get => displayMessage;
            set 
            {
                if (displayMessage == null) 
                {
                    return;
                }
                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public ICommand ShowMessageCommand { get; }

        public void ShowMessage() 
        {
            DateTime data = Preferences.Get("dtAtual", DateTime.MinValue);
            DisplayMessage = $"Boa noite {Name}, hoje é {data}";
        }

        public UsuarioViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async() => await CountCharacters());
        }

        public async Task CountCharacters()
        {
            string nameLenght = string.Format("Seu nome tem {0} letras", name.Length);

            await Application.Current.MainPage.DisplayAlert("Informação", nameLenght, "Ok");
        }

        public ICommand CountCommand { get; }

        public async Task CleanConfirmation()
        {
            if (await Application.Current.MainPage.DisplayAlert("Confirmação", "Confirma limpeza de dados?", "Yes","No"))
            {
                Name = string.Empty;
                DisplayMessage = string.Empty;
                OnPropertyChanged(name);
                OnPropertyChanged(DisplayMessage);

                await Application.Current.MainPage.DisplayAlert("Informacação", "Limpeza realizada com sucesso", "Ok");
            }
        }


    }
}
