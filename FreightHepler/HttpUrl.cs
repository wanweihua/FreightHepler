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
        public string CurBgMenu = string.Empty;
        public string initOutBurDataPermissionApply = string.Empty;
        public string searchDataPermissionApply = string.Empty;
        public string UnitUrl = string.Empty;
        public string CurBureauFz = string.Empty;
        public string PM = string.Empty;
        public string queryZyxByTmism = string.Empty;
        public string outBurDataPermissionApply = string.Empty;
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
             host = "https://frontier.wulmq.95306.cn";
             //host = "https://frontier.lanzh.95306.cn";
             
             loginUrl = host + "/gateway/hydzsw/Dzsw/j_spring_security_check";
             captchaUrl = host + "/gateway/hydzsw/Dzsw/security/jcaptcha.jpg";
             pageTypeLogin = host + "/gateway/hydzsw/Dzsw/action/TbSysLogincountPerdateAction_countingLogincountPerdate";
             initUrl = host + "/gateway/hydzsw/Dzsw/login_bur.jsp";
             CurBgMenu = host + "/gateway/hydzsw/Dzsw/action/WorkPlatformAction_getCurBgMenu";
             initOutBurDataPermissionApply = host + "/gateway/hydzsw/Dzsw/action/TbUnitInfoApplyAction_initOutBurDataPermissionApply";
             searchDataPermissionApply = host + "/gateway/hydzsw/Dzsw/action/TbUnitInfoApplyAction_searchDataPermissionApply";
             UnitUrl = host + "/gateway/hydzsw/Dzsw/action/AjaxAction_getAllUnit?q=&limit=100&timestamp=1480593801224";
            //https://frontier.wulmq.95306.cn/gateway/hydzsw/Dzsw/action/AjaxAction_getAllUnit?q=01-602%E5%BA%93&limit=50&timestamp=1480593804029

             CurBureauFz = host + "/gateway/hydzsw/Dzsw/action/AjaxAction_getCurBureauFz?q=&limit=50&timestamp=1480593804266";
             PM = host + "/gateway/hydzsw/Dzsw/action/AjaxAction_getAllPm?q=&limit=50&timestamp=1480642768800";
             //searchDataPermissionApply = host + "/gateway/hydzsw/Dzsw/action/TbUnitInfoApplyAction_searchDataPermissionApply";
             queryZyxByTmism = host + "/gateway/hydzsw/Dzsw/action/AjaxAction_queryZyxByTmism";
             outBurDataPermissionApply = host + "/gateway/hydzsw/Dzsw/action/TbUnitInfoApplyAction_outBurDataPermissionApply";

            //https://frontier.lanzh.95306.cn/gateway/hydzsw/Dzsw/action/TbUnitInfoApplyAction_searchDataPermissionApply 
        }
        
    }
}

