using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Test111
{

	[Activity(Label = "BasicTable")]
	public class HomeScreenActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.HomeScreen);

			ListView listView;
			listView = FindViewById<ListView>(Resource.Id.List);
			var tableItems = new List<TableItem>() { 
				new TableItem(){
					Heading="111",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg1
				},
				new TableItem(){
					Heading="222",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg2
				},
				new TableItem(){
					Heading="333",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg1
				},
				new TableItem(){
					Heading="444",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg2
				},
				new TableItem(){
					Heading="555",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg1
				},
				new TableItem(){
					Heading="666",SubHeading="aaa",ImageResourceId=Resource.Drawable.jpg2
				}
			};								
			listView.Adapter = new HomeScreenAdapter(this, tableItems);
			listView.ChoiceMode = ChoiceMode.Single;
			listView.SetItemChecked(4, true);
			listView.ItemClick += (sender, e) => { 
				var t = tableItems[e.Position];
				Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
			};  
		}
	}
}
