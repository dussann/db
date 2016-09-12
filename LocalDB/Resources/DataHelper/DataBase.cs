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
using Android.Util;

namespace LocalDB.Resources.DataHelper
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public Boolean createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.CreateTable<Person>();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }   
        }

        public Boolean insertIntoTablePerson(Person person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.CreateTable<Person>();
                    return true;
                }                    
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLite ex",ex.Message);
                return false;
            }
        }

        public List<Person> SelectTablePerson()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    
                    return connection.Table<Person>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite ex", ex.Message);
                return null;
            }
        }

        public Boolean updateTablePerson(Person person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.Query<Person>("UPDATE Person set Name= ?  Age= ?  Email ?  where Id=? ", person.Name, person.Age, person.Email, person.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite ex", ex.Message);
                return false;
            }
        }
        public Boolean deletePerson(Person person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.Delete(person);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite ex", ex.Message);
                return false;
            }
        }

        public Boolean selectQueryTablePerson(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.Query<Person>("SELECT * FROM Person where Id=? ",Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite ex", ex.Message);
                return false;
            }
        }
    }
}