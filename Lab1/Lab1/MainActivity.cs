using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Lab1
{
	[Activity(Label = "Lab1", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button button;
		TextView TextViewDev;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button>(Resource.Id.myButton);
			TextViewDev = FindViewById<TextView>(Resource.Id.textViewDev);

			button.Click += button_click;

		}

		private async void button_click(object sender, EventArgs e)
		{
			TextViewDev.Text = "nombre";
			string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			Lab1.Registro helper = new Lab1.Registro();
			await helper.InsertarEntidad("correo", "lab1", myDevice);
			button.Text = "Gracias por completar el Lab1";
		}
	}
}

