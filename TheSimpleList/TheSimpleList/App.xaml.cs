using CommonServiceLocator;
using TheSimpleList.Src;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TheSimpleList
{
    public partial class App : Application
    {
        private readonly StartPoint startPoint;
        
        public App()
        {
            startPoint = new StartPoint(this);
            startPoint.Start();

            InitializeComponent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
