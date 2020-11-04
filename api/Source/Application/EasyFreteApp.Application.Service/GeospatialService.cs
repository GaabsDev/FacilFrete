using EasyFreteApp.Domain.Service;
using EasyFreteApp.Presentation.UI.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EasyFreteApp.Application.Service
{
    public class GeospatialService : IGeospatialService
    {
        public async Task<GeospatialDomain> Geocode(string searchtext)
        {
            var url = string.Format(@"https://geocoder.ls.hereapi.com/6.2/geocode.json?apiKey=16Pzl4xCx-ChBfl_SGUB97c2Ngy8bte6aBJzRF72WHw&searchtext={0}", searchtext);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Replace(",", "."));
                request.Timeout = 60000;
                WebResponse response = request.GetResponse();
                using (var sreader = new StreamReader(response.GetResponseStream()))
                {
                    string responsereader = await sreader.ReadToEndAsync();
                    responsereader = responsereader.Replace("\n", string.Empty);
                    JObject result = JObject.Parse(responsereader);
                    var position = result["Response"]["View"][0]["Result"][0]["Location"]["DisplayPosition"];
                    var lat = position["Latitude"].ToString();
                    var lon = position["Longitude"].ToString();
                    response.Close();
                    return new GeospatialDomain() {Latitude=float.Parse(lat), Longitude= float.Parse(lon), Adress=searchtext };
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        throw new Exception(text);
                    }
                }
            }
        }
    }
}
