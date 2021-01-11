using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ratertracker
{
    public class UrlCaptureConfiguration
    {

        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public int ProcessId { get; set; }

        public bool IgnoreResources { get; set; }
        public string CaptureDomain { get; set; }
        public List<string> UrlFilterExclusions { get; set; }
        public List<string> ExtensionFilterExclusions { get; set; }
        [Browsable(false)]
        public string Cert { get; set; }

        [Browsable(false)]
        public string Key { get; set; }
        public UrlCaptureConfiguration()
        {
           CaptureDomain = "";
            //UrlFilterExclusions = new List<string>("tracker".Split('|'));www.raterhub.com
            UrlFilterExclusions = new List<string>()
                {
                    "/vt/",
                    "/StaticMapService",
                    "/vt",
                    "/evaluation/rater/tracker/",
                    "/css",
                    "/js",
                     "/js/",
                    "/jsapi",
                    "googleusercontent.com",
                    "googleapis.com",
                    "google.com",
                    "google.fr",
                    "leapforceathome.com",
                    "google-analytics.com"
                };
            ExtensionFilterExclusions = new List<string>(".css|.js|.png|.jpg|.gif|.ico|.svg|.telechargement".Split('|'));
        }


    }
}
