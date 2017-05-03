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
using PCLProject;

namespace AndroidApp
{
    class AndroidDialog : PCLProject.IDialog
    {
        Context AppContext;
        public AndroidDialog(Context content)
        {
            AppContext = content;
        }

        public void Show (string message)
        {
            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(AppContext);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage(message);
            Alert.SetButton("OK", (s, ev) => { });
            Alert.Show();
        }
    }
}