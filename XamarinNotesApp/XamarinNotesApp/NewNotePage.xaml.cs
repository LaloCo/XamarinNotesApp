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
		public NewNotePage ()
		{
			InitializeComponent ();
		}

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
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
    }
}