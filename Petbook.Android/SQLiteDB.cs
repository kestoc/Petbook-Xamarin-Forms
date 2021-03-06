﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Petbook.Droid;
using SQLite;
using Xamarin.Forms;
using Petbook.Tablas;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Petbook.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        //Clase para hacer la creacion de la DB local en Android y su ruta
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la base de datos
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}