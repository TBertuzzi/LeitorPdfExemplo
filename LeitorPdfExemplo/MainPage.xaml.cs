using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LeitorPdfExemplo.Helpers;
using Xamarin.Forms;

namespace LeitorPdfExemplo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CarregarPdf();
        }

        private void CarregarPdf()
        {
            var dependency = DependencyService.Get<ILocalFileProvider>();

            if (dependency == null)
            {
                DisplayAlert("Erro ao carregar dependencia", "Dependencia não encontrada", "OK");

                return;
            }

            var localPath = string.Empty;

            string url = "https://repositorio.unesp.br/bitstream/handle/11449/118389/000793203.pdf";

            var fileName = Guid.NewGuid().ToString();

            using (var httpClient = new HttpClient())
            {
                var pdfStream = Task.Run(() => httpClient.GetStreamAsync(url)).Result;
                localPath =
                    Task.Run(() => dependency.SaveFileToDisk(pdfStream, $"{fileName}.pdf")).Result;
            }

            if (string.IsNullOrWhiteSpace(localPath))
            {
                DisplayAlert("Error baixar PDF", "não foi possivel encontrar o arquivo", "OK");

                return;
            }

            PdfView.Uri = localPath;
        }
    }
}
