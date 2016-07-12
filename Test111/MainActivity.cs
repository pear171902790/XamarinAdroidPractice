using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Test111
{
	[Activity (Label = "Phone Word", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, SeekBar.IOnSeekBarChangeListener
	{
		static readonly List<string> phoneNumbers = new List<string>();
		SeekBar _seekBar;
		TextView _textView;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
		}

		protected override void OnStart()
		{
			base.OnStart();
			_seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
			_textView = FindViewById<TextView>(Resource.Id.textView1);

			// Assign this class as a listener for the SeekBar events
			_seekBar.SetOnSeekBarChangeListener(this);

			var callButton = FindViewById<Button>(Resource.Id.CallButton);
			var goToComplete = FindViewById<Button>(Resource.Id.GoToAutoComplete);
			var callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
			var translatedNumber = "13720738958";
			callHistoryButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(CallHistoryActivity));
				intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
				StartActivity(intent);
			};
			callButton.Click += (object sender, EventArgs e) =>
			{
				var callDialog = new AlertDialog.Builder(this);
				callDialog.SetMessage("Call " + translatedNumber + "?");
				callDialog.SetNeutralButton("Call", delegate
				{
					phoneNumbers.Add(translatedNumber);
					callHistoryButton.Enabled = true;
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
					StartActivity(callIntent);
				});
				callDialog.SetNegativeButton("Cancel", delegate { });

				callDialog.Show();
			};


			goToComplete.Click += (object sender, EventArgs e) =>
			{
				var intent = new Intent(this, typeof(HomeScreenActivity));
				StartActivity(intent);
			};

		}
		public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			if (fromUser)
			{
				_textView.Text = string.Format("The user adjusted the value of the SeekBar to {0}", seekBar.Progress);
			}
		}

		public void OnStartTrackingTouch(SeekBar seekBar)
		{
			System.Diagnostics.Debug.WriteLine("Tracking changes.");
		}

		public void OnStopTrackingTouch(SeekBar seekBar)
		{
			System.Diagnostics.Debug.WriteLine("Stopped tracking changes.");
		}


	}
}


