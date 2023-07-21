using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Essentials;
using OxyPlot;
using OxyPlot.Series;

namespace Plot_Graph.Views
{
    public partial class MainPage : ContentPage
    {
        private string _fileContent;

        public string FileContent
        {
            get{ return _fileContent; }
            set{
                _fileContent = value;
                OnPropertyChanged(nameof(FileContent));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void ChooseFileButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.Android, new[] { "text/plain" } }, // For Android, specify MIME type for txt files
                        { DevicePlatform.iOS, new[] { "public.plain-text" } } // For iOS, specify MIME type for txt files
                    }),
                    PickerTitle = "Please select a txt file"
                });

                if (file != null)
                {
                    var content = System.IO.File.ReadAllText(file.FullPath);
                    FileContent = content;
                    labelInfo.Text = file.FileName;
                    createLineChart(content);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                labelInfo.Text = "Error: " + ex.Message;
            }
        }

        private void createLineChart(string content)
        {
            try
            {
                var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var plotModel = new PlotModel { Title = "Line Chart", TitleFontSize = 20 };
                var lineSeries = new LineSeries { MarkerType = MarkerType.Circle, MarkerSize = 4 };

                for (int i = 0; i < lines.Length; i++)
                {
                    var values = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length >= 2 && float.TryParse(values[0], out var xValue) && float.TryParse(values[1], out var yValue))
                    {
                        lineSeries.Points.Add(new DataPoint(xValue, yValue));
                    }
                }

                plotModel.Series.Add(lineSeries);
                lineChartView.Model = plotModel;
            }
            catch (Exception ex)
            {
                labelInfo.Text = "Error: " + ex.Message;
            }
        }

    }
}
