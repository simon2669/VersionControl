using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06.Entities;
using week06.MnbServiceReference1;

namespace week06
{
    public partial class Form1 : Form
    {
        BindingList<string> Currencies = new BindingList<string>();
        BindingList<RateData> Rates = new BindingList<RateData>();
        string result;
        public Form1()
        {
            

            RefreshData();
            //dateTimePicker2
            
        }

        private void RefreshData()
        {
            InitializeComponent();
            
            Rates.Clear();
            Currencies.Clear();
            
            LoadData();
            
            
            
            
            
            WorkWithXlm();
            GetCurrencies();
            comboBox1.DataSource = Currencies;
            dataGridView1.DataSource = Rates;
            createDiagram();

            
        }

        private void GetCurrencies()
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                
                string currentValutaName;
                //Currencies

                
                

                // Valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null)
                    continue;
                currentValutaName = childElement.GetAttribute("curr");

                if (!Currencies.Contains(currentValutaName))
                {
                    Currencies.Add(currentValutaName);
                }
            }
        }

        private void createDiagram()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void WorkWithXlm()
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                // Létrehozzuk az adatsort és rögtön hozzáadjuk a listához
                // Mivel ez egy referencia típusú változó, megtehetjük, hogy előbb adjuk a listához és csak később töltjük fel a tulajdonságait
                var rate = new RateData();
                Rates.Add(rate);

                // Dátum
                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                // Valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                // Érték
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        private void LoadData()
        {
            // A változó deklarációk jobb oldalán a "var" egy dinamikus változó típus.
            // A "var" változó az első értékadás pillanatában a kapott érték típusát veszi fel, és később nem változtatható.
            // Jelen példa első sora tehát ekvivalens azzal, ha a "var" helyélre a MNBArfolyamServiceSoapClient-t írjuk.
            // Ebben a formában azonban olvashatóbb a kód, és változtatás esetén elég egy helyen átírni az osztály típusát.

            var mnbService = new MNBArfolyamServiceSoapClient();

            string startD = (dateTimePicker1.Value).ToString();
            string endD = (dateTimePicker2.Value).ToString();
            string currName = (comboBox1.SelectedItem).ToString();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = currName,
                startDate = startD,
                endDate = endD
            };

            // Ebben az esetben a "var" a GetExchangeRates visszatérési értékéből kapja a típusát.
            // Ezért a response változó valójában GetExchangeRatesResponseBody típusú.
            var response = mnbService.GetExchangeRates(request);

            // Ebben az esetben a "var" a GetExchangeRatesResult property alapján kapja a típusát.
            // Ezért a result változó valójában string típusú.
            result = response.GetExchangeRatesResult;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
