using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;

namespace WeatherSchedudle
{
    public partial class Form1 : Form
    {
        private readonly CartesianChart temperatureChart = new CartesianChart();
        private readonly CartesianChart humidityChart = new CartesianChart();
        public Form1()
        {
            InitializeComponent();
            Controls.Add(temperatureChart);
            Controls.Add(humidityChart);
            temperatureChart.Visible = false;
            humidityChart.Visible = false;
        }

        private void cartesianChart2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e) //Графік з температурою
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Широта
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Довгота
        {

        }

        private async void button1_Click(object sender, EventArgs e) //Прогноз(натискаємо на кнопку, враховаується широта і довгота, з посилання в графіки)
        {
            double latitude, longitude;
            if (double.TryParse(textBox1.Text, out latitude) && double.TryParse(textBox2.Text, out longitude))
            {
                string apiUrl = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&units=metric&lang=ua&appid=522939462acdeb28a5f79f10077fc4b8";
                await GetAndDisplayWeatherForecast(apiUrl);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private async Task GetAndDisplayWeatherForecast(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(apiUrl);
                    temperatureChart.Visible = true;
                    humidityChart.Visible = true;

                    //Додати код для відображення темп та волог
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e) //Графік з вологістю
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
