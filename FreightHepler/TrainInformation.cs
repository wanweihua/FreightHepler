namespace FreightHepler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Serializable]
    public class TrainInformation
    {
        private string advancedSoftSleeper = string.Empty;
        private int advancedSoftSleeperCount = 0;
        private string arrivedTime = string.Empty;
        private string businessSeat = string.Empty;
        private int businessSeatCount = 0;
        private string purpose_codes = string.Empty;//weihua.wan
        [NonSerialized]
       // private BuyLinkEditValue buyLink;
        private string buyLinkText = string.Empty;
        private bool[] checkedListSeatType = new bool[9];
        private DateTime date = DateTime.MinValue;
        private string displayDate = string.Empty;
        private string displayEndStation = string.Empty;
        private string displayStartStation = string.Empty;
        private string drvingTime = string.Empty;
        [NonSerialized]
        private string[] dynamicOrderArgs;
        private string endStation = string.Empty;
        private DateTime endTime = DateTime.Now;
        private DateTime endTimeSort = DateTime.Now;
        private string firstClassSeat = string.Empty;
        private int firstClassSeatCount = 0;
        [NonSerialized]
        private bool hasTicket = false;
        private bool isCRH = false;
       // private BuyLinkJsContent jsContent = new BuyLinkJsContent();
        [NonSerialized]
       // private JsonTrain jsonTrainData;
       // [NonSerialized]
        private DateTime lastSubmitRequest = DateTime.MinValue;
        private string[] leftTicketStrAndToken = null;
        private string noneSeat = string.Empty;
        private int noneSeatCount = 0;
        private string number = string.Empty;
        private string otherSeat = string.Empty;
       
        [NonSerialized]
       // private TicketPriceInfomation price;
        private string replaceSteatTypes = string.Empty;
        private DateTime saleDate = DateTime.MinValue;
        private string seat = string.Empty;
        private int seatCount = 0;
        private string seatType = string.Empty;
        private string secondClassSeat = string.Empty;
        private int secondClassSeatCount = 0;
        private string simpleDate = string.Empty;
        private string sleeper = string.Empty;
        private int sleeperCount = 0;
        private string softSeat = string.Empty;
        
       
       
        private string startStation = string.Empty;
        private DateTime startTime = DateTime.Now;
        [NonSerialized]
        private string[] stopHover;
        private string string_0 = string.Empty;
        private string superClassSeat = string.Empty;
        private int superClassSeatCount = 0;
        [NonSerialized]
        //private FreightHepler.TicketPrice ticketPrice;
        private float totalHour = 0f;
        private string trainType = string.Empty;
        private string usedHour = string.Empty;
        private string ip = string.Empty;
        public string Ip
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }
        public TrainInformation()
        {
            //this.buyLink = new BuyLinkEditValue(this);
        }

        
        private int GetTicketCount(string value)
        {
            if (value == "有")
            {
                return 100;
            }
            if ((value.Length > 0) && char.IsNumber(value, 0))
            {
                return int.Parse(value);
            }
            return 0;
        }
       
    
       

        public string AdvancedSoftSleeper
        {
            get
            {
                return this.advancedSoftSleeper;
            }
            set
            {
                this.advancedSoftSleeper = value;
                this.advancedSoftSleeperCount = this.GetTicketCount(value);
                this.hasTicket = this.hasTicket || (this.advancedSoftSleeperCount > 0);
            }
        }

       

        public string ArrivedTime
        {
            get
            {
                return this.arrivedTime;
            }
            set
            {
                this.arrivedTime = value;
            }
        }

       

       
        public int BusinessSeatCount
        {
            get
            {
                return this.businessSeatCount;
            }
            set
            {
                this.businessSeatCount = value;
            }
        }
        public string PurposeCodes
        {
            get
            {
                return this.purpose_codes;
            }
            set
            {
                this.purpose_codes = value;
            }
        }
       

        public string BuyLinkText
        {
            get
            {
                return this.buyLinkText;
            }
            set
            {
                this.buyLinkText = value;
            }
        }

        public bool[] CheckedListSeatType
        {
            get
            {
                return this.checkedListSeatType;
            }
            set
            {
                this.checkedListSeatType = value;
            }
        }

     

        public string DisplayDate
        {
            get
            {
                return this.displayDate;
            }
            set
            {
                this.displayDate = value;
            }
        }

        public string DisplayEndStation
        {
            get
            {
                return this.displayEndStation;
            }
            set
            {
                this.displayEndStation = value;
            }
        }

        public string DisplayStartStation
        {
            get
            {
                return this.displayStartStation;
            }
            set
            {
                this.displayStartStation = value;
            }
        }

        public string DrvingTime
        {
            get
            {
                return this.drvingTime;
            }
            set
            {
                this.drvingTime = value;
            }
        }

        public string[] DynamicOrderArgs
        {
            get
            {
                return this.dynamicOrderArgs;
            }
            set
            {
                this.dynamicOrderArgs = value;
            }
        }

        public string EndStation
        {
            get
            {
                return this.endStation;
            }
            set
            {
                this.endStation = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        public DateTime EndTimeSort
        {
            get
            {
                return this.endTimeSort;
            }
            set
            {
                this.endTimeSort = value;
            }
        }

        public string FirstClassSeat
        {
            get
            {
                return this.firstClassSeat;
            }
            set
            {
                this.firstClassSeat = value;
                this.firstClassSeatCount = this.GetTicketCount(value);
                this.hasTicket = this.hasTicket || (this.firstClassSeatCount > 0);
            }
        }

        public string FirstClassSeatChecked
        {
            get
            {
                return this.CheckedListSeatType[2].ToString();
            }
        }

        public int FirstClassSeatCount
        {
            get
            {
                return this.firstClassSeatCount;
            }
            set
            {
                this.firstClassSeatCount = value;
            }
        }

        public bool HasTicket
        {
            get
            {
                return this.hasTicket;
            }
            set
            {
                this.hasTicket = value;
            }
        }

        public string ID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public bool IsCRH
        {
            get
            {
                return this.isCRH;
            }
            set
            {
                this.isCRH = value;
            }
        }

       

        public DateTime LastSubmitRequest
        {
            get
            {
                return this.lastSubmitRequest;
            }
            set
            {
                this.lastSubmitRequest = value;
            }
        }

        public string[] LeftTicketStrAndToken
        {
            get
            {
                return this.leftTicketStrAndToken;
            }
            set
            {
                this.leftTicketStrAndToken = value;
            }
        }

        public string NoneSeat
        {
            get
            {
                return this.noneSeat;
            }
            set
            {
                this.noneSeat = value;
                this.noneSeatCount = this.GetTicketCount(value);
                this.hasTicket = this.hasTicket || (this.noneSeatCount > 0);
            }
        }

        public string NoneSeatChecked
        {
            get
            {
                return this.CheckedListSeatType[8].ToString();
            }
        }

        public int NoneSeatCount
        {
            get
            {
                return this.noneSeatCount;
            }
        }

     
     
   

        public DateTime SaleDate
        {
            get
            {
                return this.saleDate;
            }
            set
            {
                this.saleDate = value;
            }
        }

   

        public string SeatChecked
        {
            get
            {
                return this.CheckedListSeatType[6].ToString();
            }
        }

        public int SeatCount
        {
            get
            {
                return this.seatCount;
            }
        }

        public string SeatType
        {
            get
            {
                return this.seatType;
            }
            set
            {
                this.seatType = value;
            }
        }

      

        public string SecondClassSeatChecked
        {
            get
            {
                return this.CheckedListSeatType[3].ToString();
            }
        }

        public int SecondClassSeatCount
        {
            get
            {
                return this.secondClassSeatCount;
            }
        }

        public string SimpleDate
        {
            get
            {
                return this.simpleDate;
            }
            set
            {
                this.simpleDate = value;
            }
        }

     

   

     
        public string SoftSeatChecked
        {
            get
            {
                return this.CheckedListSeatType[7].ToString();
            }
        }

    



        public string StartStation
        {
            get
            {
                return this.startStation;
            }
            set
            {
                this.startStation = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        public string[] StopHover
        {
            get
            {
                return this.stopHover;
            }
            set
            {
                this.stopHover = value;
            }
        }

        public string SuperClassSeat
        {
            get
            {
                return this.superClassSeat;
            }
            set
            {
                this.superClassSeat = value;
                this.superClassSeatCount = this.GetTicketCount(value);
                this.hasTicket = this.hasTicket || (this.superClassSeatCount > 0);
            }
        }

        public string SuperClassSeatChecked
        {
            get
            {
                return this.CheckedListSeatType[1].ToString();
            }
        }

        public int SuperClassSeatCount
        {
            get
            {
                return this.superClassSeatCount;
            }
            set
            {
                this.superClassSeatCount = value;
            }
        }

       

        public float TotalHour
        {
            get
            {
                return this.totalHour;
            }
            set
            {
                this.totalHour = value;
            }
        }

        public string TrainType
        {
            get
            {
                return this.trainType;
            }
            set
            {
                this.trainType = value;
            }
        }

        public string UsedHour
        {
            get
            {
                return this.usedHour;
            }
            set
            {
                this.usedHour = value;
            }
        }
    }
}

