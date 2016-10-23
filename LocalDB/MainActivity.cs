using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using LocalDB.Resources.DataHelper;

namespace LocalDB
{
    [Activity(Label = "LocalDB", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lstData;
        List<Person> lstSource = new List<Person>();
        DataBase db;
        public Boolean test;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // testiranje
            //evo je promena
            SetContentView(Resource.Layout.Main);
            db = new DataBase();
            db.createDataBase();

            lstData = FindViewById<ListView>(Resource.Id.listView);

            var editName = FindViewById<EditText>(Resource.Id.editName);
            var editAge = FindViewById<EditText>(Resource.Id.editAge);
            var editEMail = FindViewById<EditText>(Resource.Id.editEMail);

            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            LoadData();

            btnAdd.Click += delegate
             {
                 Person person = new Person()
                 {
                     Name = editName.Text,
                     Age = int.Parse(editAge.Text),
                     Email = editEMail.Text
             };
               test=db.insertIntoTablePerson(person);
                
               LoadData();
             };

            lstData.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)

                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Yellow);
                    else
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Red);
                }
                var txtName = e.View.FindViewById<TextView>(Resource.Id.textView1);
                var txtAge = e.View.FindViewById<TextView>(Resource.Id.textView2);
                var txtEmail = e.View.FindViewById<TextView>(Resource.Id.textView3);

                editName.Text = txtName.Text;
                editAge.Tag = e.Id;

                editAge.Text = txtAge.Text;
                editEMail.Text = txtEmail.Text;
            };
        }
        private void LoadData()
        {
            lstSource = db.SelectTablePerson();
            var adapter = new ListViewAdapters(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}

