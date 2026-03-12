using Microsoft.Extensions.DependencyInjection;

namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateTime data = DateTime.Now;
            Preferences.Set("dtAtual", data);
            Preferences.Set("AcaoInicial", $"* App executado às {data}");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Preferences.Set("AcaoStart", $" App iniciado às {DateTime.Now}");
        }

        protected override void OnSleep()
        {
            base.OnStart();
            Preferences.Set("AcaoSleep", $" App segundo plano às {DateTime.Now}");
        }

        protected override void OnResume()
        {
            base.OnStart();
            Preferences.Set("AcaoResume", $" App reativado às {DateTime.Now}");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}