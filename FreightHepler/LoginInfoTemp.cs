namespace FreightHepler
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class LoginInfoTemp
    {
        private static LoginInfoTemp conditionTemp = null;
        private List<UserName> listUsers;
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
                    conditionTemp.ListUsers = new List<UserName>();
                }
                
                return conditionTemp;
            }
        }

        public List<UserName> ListUsers
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
    public class UserName
    {
        public UserName(string user,string name)
        {
            this.user = user;
            this.name = name;
        }
        private string user = string.Empty;
        public string User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
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

