using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinNotesApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //! added using SQLite;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Note>();
                List<Note> notes = conn.Table<Note>().ToList();
                notesListView.ItemsSource = notes;
            }
        }

        private void NewToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewNotePage());
        }

        private void NotesListView_ItemSelected(object sender, EventArgs e)
        {

        }
    }
}
