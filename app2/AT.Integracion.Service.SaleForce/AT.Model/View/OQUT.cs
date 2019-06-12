using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class OQUT
    {
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public string NumAtCard { get; set; }
        public double VatSum { get; set; }
        public double DiscSum { get; set; }
        public double DocTotal { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Comments { get; set; }
        public int SlpCode { get; set; }
        public int CntctCode { get; set; }
    }
}
