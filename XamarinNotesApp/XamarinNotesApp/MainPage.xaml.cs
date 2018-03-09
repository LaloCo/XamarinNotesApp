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

            notesListView.Refreshing += NotesListView_Refreshing;
		}

        private void NotesListView_Refreshing(object sender, EventArgs e)
        {
            ReadPosts();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ReadPosts();
        }

        private void NewToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewNotePage());
        }

        private void NotesListView_ItemSelected(object sender, EventArgs e)
        {
            Note selectedNote = notesListView.SelectedItem as Note;
            Navigation.PushAsync(new NewNotePage(selectedNote));
        }

        private void MenuItem_Delete(object sender, EventArgs args)
        {
            Note itemToDelete = ((sender as MenuItem).BindingContext as Note);

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Note>();
                conn.Delete(itemToDelete);
            }

            ReadPosts();
        }

        private void ReadPosts()
        {
            //! added using SQLite;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Note>();
                List<Note> notes = conn.Table<Note>().ToList();
                notesListView.ItemsSource = notes;
                notesListView.IsRefreshing = false;
            }
        }
    }
}
