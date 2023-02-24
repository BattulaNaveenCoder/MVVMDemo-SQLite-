using MVVMDemo.Services;
using MVVMDemo.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMDemo
{
    public partial class App : Application
    {

        static StudentRepository _studentRepository;
        public static StudentRepository StudentRepository
        {
            get
            {
                if(_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3"));
                }
                return _studentRepository;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StudentView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
