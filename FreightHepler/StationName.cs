namespace FreightHepler
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class StationName
    {
        private string code;
        private string fullPy;
        [NonSerialized]
        private List<StationName> listGroupStation;
        private string name;
        private string simplePy;
        private int sortValue;
        private string string_0 = string.Empty;
        private string string_1;
        private string time = "其它";

        public override string ToString()
        {
            return this.Name;
        }

        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        public string FullPy
        {
            get
            {
                return this.fullPy;
            }
            set
            {
                this.fullPy = value;
            }
        }

        public string ID
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        public List<StationName> ListGroupStation
        {
            get
            {
                return this.listGroupStation;
            }
            set
            {
                this.listGroupStation = value;
            }
        }

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

        public string SimplePy
        {
            get
            {
                return this.simplePy;
            }
            set
            {
                this.simplePy = value;
            }
        }

        public int SortValue
        {
            get
            {
                return this.sortValue;
            }
            set
            {
                this.sortValue = value;
            }
        }

        public string Tag
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

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
    }
}

