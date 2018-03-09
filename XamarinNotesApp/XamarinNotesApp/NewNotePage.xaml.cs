using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNotesApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewNotePage : ContentPage
	{
        Note selectedNote;
        public NewNotePage()
        {
            InitializeComponent();
        }
		public NewNotePage (Note selectedNote)
		{
			InitializeComponent ();

            this.selectedNote = selectedNote;
            titleEntry.Text = selectedNote.Title;
            contentEditor.Text = selectedNote.Content;
		}

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (selectedNote == null)
            {
                Note note = new Note()
                {
                    Title = titleEntry.Text,
                    Content = contentEditor.Text
                };

                //! added using SQLite;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Note>();
                    int itemsInserted = conn.Insert(note);

                    if (itemsInserted > 0)
                        DisplayAlert("Done", "Note saved", "Ok");
                    else
                        DisplayAlert("Error", "Note not saved", "Ok");
                }
            }
            else
            {
                selectedNote.Title = titleEntry.Text;
                selectedNote.Content = contentEditor.Text;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Note>();
                    int itemsUpdated = conn.Insert(selectedNote);

                    if (itemsUpdated > 0)
                        DisplayAlert("Done", "Note updated", "Ok");
                    else
                        DisplayAlert("Error", "Note not updated", "Ok");
                }
            }
        }
    }
}