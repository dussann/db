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
using Java.Lang;

namespace LocalDB
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtAge { get; set; }
        public TextView txtEMail { get; set; }

    }
    public class ListViewAdapters:BaseAdapter
    {
        public Activity activity;
        public List<Person> lstPerson;
        public ListViewAdapters(Activity activity,List<Person> lstPerson)
        {
            this.activity = activity;
            this.lstPerson = lstPerson;
        }

        public override int Count
        {
            get
            {
                return lstPerson.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPerson[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.List_view_dataTemplate, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
            var txtEMail = view.FindViewById<TextView>(Resource.Id.textView3);

            txtName.Text = lstPerson[position].Name;
            txtAge.Text = ""+lstPerson[position].Age;
            txtEMail.Text = lstPerson[position].Email;

            return view;




        }
    }
}