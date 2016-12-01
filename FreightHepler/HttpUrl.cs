namespace FreightHepler
{
    using System;

    public class HttpUrl
    {
        
        //public static string RandCode = ("https://dynamic.12306.cn/otsweb/passCodeNewAction.do?module=login&rand=sjrand&" + random.NextDouble());
        //public static string RandCodeOrder = ("https://dynamic.12306.cn/otsweb/passCodeNewAction.do?module=passenger&rand=randp&" + random.NextDouble());
        //private static Random random = new Random();
        public string host = string.Empty;
        public string loginUrl = string.Empty;
        public string captchaUrl = string.Empty;
        public string initUrl = string.Empty;
        public string pageTypeLogin = string.Empty;

        private static HttpUrl HttpURL = null;
        public static HttpUrl Instance
        {
            get
            {
                if (HttpURL == null)
                {
                    HttpURL = new HttpUrl();
                }

                return HttpURL;
            }
        }
        public HttpUrl()
        {
             host = "https://frontier.xian.95306.cn";
             loginUrl = host + "/gateway/hydzsw/Dzsw/j_spring_security_check";
             captchaUrl = host + "/gateway/hydzsw/Dzsw/security/jcaptcha.jpg";
             pageTypeLogin = host + "/gateway/hydzsw/Dzsw/action/TbSysLogincountPerdateAction_countingLogincountPerdate";
             initUrl = host + "/gateway/hydzsw/Dzsw/login_bur.jsp";              
        }
        
    }
}

