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
	public class MainActivity : Activity
	{
		static readonly List<string> phoneNumbers = new List<string>();
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var phoneNumberText = FindViewById<TextView>(Resource.Id.PhoneNumberText);
			var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			var callButton = FindViewById<Button>(Resource.Id.CallButton);

			callButton.Enabled = false;

			var translatedNumber = string.Empty;

			translateButton.Click += (object sender, EventArgs e) =>
			{
				translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
				if (String.IsNullOrWhiteSpace(translatedNumber))
				{
					callButton.Text = "Call";
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};
			Button callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
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


		}
	}
}


