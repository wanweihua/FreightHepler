namespace FreightHepler
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class LoginInfoTemp
    {
        private static LoginInfoTemp conditionTemp = null;
        private List<string[]> listUsers;
        private string password = string.Empty;
        private List<TrainInformation> ticketConditionListTrain;
        private string ticketConditonEnables = string.Empty;
        private StationName ticketConditonFromStation;
        private StationName ticketConditonToStation;
        private List<DateTime> ticketCondtionTrainDate;
        private string userName = string.Empty;

        private LoginInfoTemp()
        {
        }

        public void Save()
        {
            //SerializableTool.ObjectToFile(this, AppDomain.CurrentDomain.BaseDirectory + @"Data\LoginInfoTemp.temp");
        }

        public static LoginInfoTemp Instance
        {
            get
            {
                //if (conditionTemp == null)
                //{
                //    conditionTemp = SerializableTool.FileToObject(AppDomain.CurrentDomain.BaseDirectory + @"Data\LoginInfoTemp.temp") as LoginInfoTemp;
                //    conditionTemp = (conditionTemp == null) ? new LoginInfoTemp() : conditionTemp;
                //}

                LoginInfoTemp conditionTemp = new LoginInfoTemp();
                
                return conditionTemp;
            }
        }

        public List<string[]> ListUsers
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

        public List<TrainInformation> TicketConditionListTrain
        {
            get
            {
                return this.ticketConditionListTrain;
            }
            set
            {
                this.ticketConditionListTrain = value;
            }
        }

        public string TicketConditonEnables
        {
            get
            {
                return this.ticketConditonEnables;
            }
            set
            {
                this.ticketConditonEnables = value;
            }
        }

        public StationName TicketConditonFromStation
        {
            get
            {
                return this.ticketConditonFromStation;
            }
            set
            {
                this.ticketConditonFromStation = value;
            }
        }

        public StationName TicketConditonToStation
        {
            get
            {
                return this.ticketConditonToStation;
            }
            set
            {
                this.ticketConditonToStation = value;
            }
        }

        public List<DateTime> TicketCondtionTrainDate
        {
            get
            {
                return this.ticketCondtionTrainDate;
            }
            set
            {
                this.ticketCondtionTrainDate = value;
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
}

