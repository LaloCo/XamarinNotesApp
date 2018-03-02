using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinNotesApp
{
    public class Note
    {
        //! added using SQLite;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
