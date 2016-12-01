namespace FreightHepler
{
    using FSLib.Network.Http;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Windows.Forms;

    public class MyWebService
    {
        public MyWebService()
        {
            ServicePointManager.DefaultConnectionLimit = 0x200;
            ServicePointManager.MaxServicePoints = 0x200;
            ServicePointManager.MaxServicePointIdleTime = 1;
            ServicePointManager.Expect100Continue = true;
            //ServicePointManager.CertificatePolicy = new MyPolicy();
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            //System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            //{

            //    return true;

            //};
            client = new HttpClient();
           // client.ServerCertificateValidation += (se, cert, chain, sslerror) => { return true; };
          //  ServerCertificateValidation
        }
        private static MyWebService WebService = null;
        private HttpClient client = null;
        
        public HttpClient Client{
            get { return client;}
            set{ client = value;}
        }
        public static MyWebService Instance
        {
            get
            {
                if (WebService == null)
                {                                     
                    WebService = new MyWebService();
                }
                        
                return WebService;
            }
        }
        public static string[] GetHttpRequest(string url, string ipAddress, string strCookie)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            string[] strArray;
            try
            {
                request = (HttpWebRequest) WebRequest.Create(string.IsNullOrEmpty(ipAddress) ? url : url.Replace("dynamic.12306.cn", ipAddress));
                request.Referer = "";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Accept-Language: zh-cn");
                request.Headers.Add("Accept-Encoding: gzip, default");
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586";
                request.Headers.Add("Pragma", "no-cache");
                request.Headers.Add("If-None-Match", DateTime.Now.Ticks.ToString());
                request.Headers.Add("Cookie", strCookie);
                request.Timeout = 0x2710;
                request.ReadWriteTimeout = 0x2710;
                //request.set_Host("dynamic.12306.cn");
                response = (HttpWebResponse) request.GetResponse();
                string str = response.Headers["X-Via"];
                string str2 = response.Headers["Expires"];
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, Encoding.UTF8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                }
                strArray = new string[] { reader.ReadToEnd(), str, str2 };
            }
            catch (Exception exception)
            {
                strArray = new string[] { exception.Message, string.Empty, string.Empty };
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return strArray;
        }


        public bool Login(string url,UserInfo info,string caption)
        {
           System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };
            //j_username=3758837&j_password=qwe123&j_captcha=awfkw&fromUrl=%2Flogin_bur.jsp
           var context = client.Create<string>(HttpMethod.Post, url, data: new {j_username=info.Name,
                                                                                j_password=info.Password,
                                                                                j_captcha=caption,
                                                                                fromUrl = "/login_bur.jsp"
           });
            //fromUrl=%2Flogin_bur.jsp
           //context.SetRefer("https://frontier.xian.95306.cn/gateway/hydzsw/Dzsw/login_bur.jsp");
           //context.SetAllowAutoRedirect(true);
           context.Send();
 
            if (context.IsValid() && context.Response.Status == HttpStatusCode.Redirect)
            {
                return true;
            }
            else
                return false;
            return false;
        }

        public Image GetCaptcha(string url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };
            var context = client.Create<Image>(HttpMethod.Get, url);
            context.Send();

            if (context.IsValid())
            {
                var pic = new PictureBox();                            
                pic.Image = context.Result;
                return pic.Image;
                
            }
            return null;
        }


        public bool PageTypeLogin(string url)
        {
            //https://frontier.xian.95306.cn/gateway/hydzsw/Dzsw/action/TbSysLogincountPerdateAction_countingLogincountPerdate 
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };

            var context = client.Create<string>(HttpMethod.Post, url, data: new { pageType = "login" });
           // context.SetRefer("https://frontier.xian.95306.cn/gateway/hydzsw/Dzsw/login_bur.jsp");
            context.Send();
            if (context.IsValid())
            {
                return true;
            }
            return false;          
        }
        public bool getCookie(string url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };
           

            var context = client.Create<string>(HttpMethod.Get, url);
           // context.SetRefer("https://frontier.xian.95306.cn/gateway/hydzsw/Dzsw/login_bur.jsp");
            context.Send();
            if (context.IsValid())
            {
                return true;
            }
            return false;
        }

        public string getHtml(string url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };


            var context = client.Create<string>(HttpMethod.Get, url);
         
            context.Send();
            if (context.IsValid())
            {
                return context.Result;
            }
            return string.Empty;
        }

        public List<UnitPrice> GetUnit(string url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };


            var context = client.Create<List<UnitPrice>>(HttpMethod.Get, url);
         
            context.Send();
            if (context.IsValid())
            {
               
                return context.Result;
            }
            return null;
        }

        public List<Bureau> getCurBureauFz(string url)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;

            };
            var context = client.Create<List<Bureau>>(HttpMethod.Get, url);

            context.Send();
            if (context.IsValid())
            {

                return context.Result;
            }
            return null;
        }
    }
}

