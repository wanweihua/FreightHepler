namespace FreightHepler
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class LoginInfoTemp
    {
        private static LoginInfoTemp conditionTemp = null;
        private List<UserInfo> listUsers;
        private string password = string.Empty;
       // private List<TrainInformation> ticketConditionListTrain;
       // private string ticketConditonEnables = string.Empty;
        //private StationName ticketConditonFromStation;
        //private StationName ticketConditonToStation;
        //private List<DateTime> ticketCondtionTrainDate;
        private string userName = string.Empty;

        private LoginInfoTemp()
        {
        }

        public void Save()
        {
            SerializableTool.ObjectToFile(this, AppDomain.CurrentDomain.BaseDirectory + @"Data\LoginInfoTemp.temp");
        }

        public static LoginInfoTemp Instance
        {
            get
            {
                if (conditionTemp == null)
                {
                    conditionTemp = SerializableTool.FileToObject(AppDomain.CurrentDomain.BaseDirectory + @"Data\LoginInfoTemp.temp") as LoginInfoTemp;
                    conditionTemp = (conditionTemp == null) ? new LoginInfoTemp() : conditionTemp;
                }
                if (conditionTemp.ListUsers == null)
                {
                    conditionTemp.ListUsers = new List<UserInfo>();
                }
                
                return conditionTemp;
            }
        }

        public List<UserInfo> ListUsers
        {
            get
            {
                return this.listUsers;
            }
            set
            {
                this.listUsers = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
    }

    [Serializable]
    public class UserInfo
    {
        public UserInfo(string name, string password)
        {
           
            this.name = name;
            this.password = password;
        }
        private string password = string.Empty;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

    }
}

