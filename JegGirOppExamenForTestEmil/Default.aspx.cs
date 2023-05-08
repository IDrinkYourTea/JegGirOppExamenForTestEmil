using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSONOppgava
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Denne labelen er lagt på i html-en "foran".
            LabelTempNow.Text = GetNowTemp().ToString();//vi må ha tostring fordi labels text er string, mens temperatur er et tall, en int.
            LabelStyrkeNow.Text = GetNowStyrke().ToString();
            LabelRetningNow.Text = GetNowRetning().ToString();
            LabelThreeNow.Text = GetNowThree().ToString();
        }

        //Oppgave 1 - henter ut temp nå
        public int GetNowTemp()//denne har int, så vil da kunne returnere et heltall. Bør returnere en double, et desimaltall
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            int temp = 0; //heltall. her bør det være en annen datatype. Fikser du det?

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    temp = data.Value<int>("air_temperature");//key name står i " " - getting key.value
                }
                return temp;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        public int GetNowStyrke()//denne har int, så vil da kunne returnere et heltall. Bør returnere en double, et desimaltall
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            int styrke = 0; //heltall. her bør det være en annen datatype. Fikser du det?

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    styrke = data.Value<int>("wind_speed");//key name står i " " - getting key.value
                }
                return styrke;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        public double GetNowRetning()//denne har int, så vil da kunne returnere et heltall. Bør returnere en double, et desimaltall
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            double retning = 0; //heltall. her bør det være en annen datatype. Fikser du det?

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    retning = data.Value<double>("wind_from_direction");//key name står i " " - getting key.value
                }
                return retning;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        public (int, int, double) GetNowThree()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");
            int temp = GetNowTemp();
            int styrke = GetNowStyrke();
            double retning = GetNowRetning();

            return (temp, styrke, retning);
        }
    }
}