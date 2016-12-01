using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreightHepler
{
    public class UnitPrice
    {
        private string dm = string.Empty;
        public string DM
        {
            get { return dm; }
            set { dm = value; }
        }

        private string mc = string.Empty;
        public string MC
        {
            get { return mc; }
            set { mc = value; }
        }

        private string unit_pinyin = string.Empty;
        public string UNIT_PINYIN
        {
            get { return unit_pinyin; }
            set { unit_pinyin = value; }
        }

        public UnitPrice()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
