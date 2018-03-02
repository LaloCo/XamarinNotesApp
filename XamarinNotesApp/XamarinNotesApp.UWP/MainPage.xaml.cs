using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamarinNotesApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string dbName = "notes.db3";
            //! added using Windows.Storage;
            string folderPath = ApplicationData.Current.LocalFolder.Path;
            //! added using System.IO;
            string dbPath = Path.Combine(folderPath, dbName);
            LoadApplication(new XamarinNotesApp.App(dbPath));
        }
    }
}
