using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "ListActivity", Theme = "@style/AppTheme")]
    public class ListActivity : AppCompatActivity
    {
        ListView mylist;
        ProgressBar progressBar;
        ListAdapter myadapter;
        private int DetailViewIntentId=401;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.list);
            mylist = FindViewById<ListView>(Resource.Id.listView1);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            showData();



            // Create your application here
        }

        private List<listItem> GenerateListData()
        {
            List<listItem> data = new List<listItem>();
            for (int i = 0; i < 30; i++)
            {

                listItem obj = new listItem();
                obj.Id = i;
                obj.Title = "Title" + i;
                obj.Subtitle = "Address" + i;
                obj.Distance = i + " km";
                obj.Image = "https://picsum.photos/200/200/?" + i;
                data.Add(obj);
            }

            return data;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            MenuInflater.Inflate(Resource.Menu.menu1, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_insert:
                    var intent = new Intent(this, typeof(DetailView));
                    StartActivityForResult(intent, DetailViewIntentId);
                    return true;

                case Resource.Id.action_refresh:
                    Toast.MakeText(this, "Refresh is clicked", ToastLength.Long).Show();

                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == DetailViewIntentId) && (resultCode == Result.Ok))
            {
                Toast.MakeText(this, data.GetStringExtra("title")+" "+ data.GetStringExtra("subtitle")+" "+ data.GetStringExtra("distance"), ToastLength.Long).Show();
            }
        }


        private void showData()
        {
            List<listItem> dataList;
            progressBar.Visibility = ViewStates.Visible;
            dataList = GenerateListData();
            progressBar.Visibility = ViewStates.Gone;
            myadapter = new ListAdapter(this, dataList);
            mylist.Adapter = myadapter;


        }


    }
}