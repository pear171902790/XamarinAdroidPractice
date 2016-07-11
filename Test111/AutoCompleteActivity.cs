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

			var autoCompleteOptions = new String[] { "Hello", "Hey", "Heja", "Hi", "Hola", "Bonjour", "Gday", "Goodbye", "Sayonara", "Farewell", "Adios" };
			var autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, autoCompleteOptions);
			var autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);
			autocompleteTextView.Adapter = autoCompleteAdapter;
			var goToMain = FindViewById<Button>(Resource.Id.GoToMain);
			var editText = FindViewById<EditText>(Resource.Id.editText1);
			var textView = FindViewById<TextView>(Resource.Id.textView1);
			editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
			{

				textView.Text = e.Text.ToString();

			};


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

