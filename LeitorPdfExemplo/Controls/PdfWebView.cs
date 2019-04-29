using System;
using Xamarin.Forms;

namespace LeitorPdfExemplo.Controls
{
    public class PdfWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create("Uri", typeof(string), typeof(PdfWebView), default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}
