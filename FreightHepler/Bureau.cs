using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreightHepler
{
    public class Bureau
    {
        //"HZZM":"敖包","SBDM":"65","TMISM":"43102",},{"

        public string HZZM { get; set; }
        public string SBDM { get; set; }
        public string TMISM { get; set; }

        public string DBM { get; set; }


        public string PYM { get; set; }

        public string SSSX { get; set; }
    }

    public class PM
    {
        //[{"DM":"1570001","IFSZJF":null,"MC":"1.3.5-三硝基苯","PYM":"135SXJB"}]
        public string DM { get; set; }
        public string IFSZJF { get; set; }
        public string MC { get; set; }

        public string PYM { get; set; }
    }



    //{"data":{"curPageNo":1,"dataRows":[{"dataPermissionId":"J001480645215102461944000","enddate":"2099-12-30","fhdwdm":"3102257","fhdwmc":"01单位","fzhzzm":"安国镇","fztmism":"41261","fzyxdm":"41261","fzyxmc":"铁路货场","hzpm":"1059乳剂(农药)","pmdm":"1321001","startdate":"2016-12-02","status":"19","unitId":""}],"first":0,"hasNext":false,"hasPre":false,"nextPage":1,"order":"asc","orderBy":"dataPermissionId","orderByColumnRelations":[],"pageSize":20,"paramMap":null,"prePage":1,"totalPages":1,"totalRecords":1},"success":true}

    //dataRows [{"dataPermissionId":"J001480645215102461944000","enddate":"2099-12-30","fhdwdm":"3102257","fhdwmc":"01单位","fzhzzm":"安国镇","fztmism":"41261",
    //"fzyxdm":"41261","fzyxmc":"铁路货场","hzpm":"1059乳剂(农药)","pmdm":"1321001","startdate":"2016-12-02","status":"19","unitId":""}]
    public class DataPermission
    {
        public Data data { get; set; }
        public bool success { get; set; }
    }
    public class DataRow
    {
        public string dataPermissionId { get; set; }
        public string enddate { get; set; }
        public string fhdwdm { get; set; }
        public string fhdwmc { get; set; }
        public string fzhzzm { get; set; }
        public string fztmism { get; set; }
        public string fzyxdm { get; set; }
        public string fzyxmc { get; set; }
        public string hzpm { get; set; }
        public string pmdm { get; set; }
        public string startdate { get; set; }
        public string status { get; set; }
        public string unitId { get; set; }
    }
    public class Data
    {
        public int curPageNo { get; set; }
        public List<DataRow> dataRows { get; set; }
        public int first { get; set; }
        public bool hasNext { get; set; }
        public bool hasPre { get; set; }
        public int nextPage { get; set; }
        public string order { get; set; }
        public string orderBy { get; set; }
        public List<string> orderByColumnRelations { get; set; }
        public int pageSize { get; set; }
        public string paramMap { get; set; }
        public int prePage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
    }
    //[{"DM":"41261","QC":"铁路货场"}]
    public class Zyx
    {
        public string DM { get; set; }
        public string QC { get; set; }
    }

    public class Page
    {
        public int pageSize { get; set; }
        public string orderBy { get; set; }
        public int curPageN { get; set; }
        public string order { get; set; }
   }
    //{"message":"提报申请成功！","object":0,"success":true}
    public class Submit
    {
       public string message{get;set;}
       public int Object{get;set;}
       public bool success{get;set;}
   }
   
}
