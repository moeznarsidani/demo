using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
namespace App3
{
    class database
    {
        String folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool Createdatabase()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Listitem.db")))
            {
                connection.CreateTable<ListItem>();
                return true;
            }
        }

        public bool insert(ListItem item)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Listitem.db")))
            {
                connection.Insert(item);
                return true;
            }
        }
    }
}