using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace Test111
{
	[Activity(Label = "Auto Complete")]
	public class AutoCompleteActivity:Activity
	{
		protected override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AutoComplete);
		}

		protected override void OnStart()
		{
			base.OnStart();



			var goToMain = FindViewById<Button>(Resource.Id.GoToMain);
			goToMain.Click += (object s, EventArgs e) =>
			{
				var intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);
			};
		}

		protected override void OnResume()
		{
			base.OnResume();
		}

		protected override void OnPause()
		{
			base.OnPause();
		}

		protected override void OnStop()
		{
			base.OnStop();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override void OnRestart()
		{
			base.OnRestart();
		}
	}
}

