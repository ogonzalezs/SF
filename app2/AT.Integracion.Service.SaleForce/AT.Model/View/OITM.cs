using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class OITM
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double OnHand { get; set; }
        public double IsCommited { get; set; }
        public double OnOrder { get; set; }
        public string CardCode { get; set; }
        public string SuppCatNum { get; set; }
        public string BuyUnitMsr { get; set; }
        public double NumInBuy { get; set; }
        public string SalUnitMsr { get; set; }
        public double NumInSale { get; set; }
        public double SHeight1 { get; set; }
        public int SHght1Unit { get; set; }
        public double SHeight2 { get; set; }
        public int SHght2Unit { get; set; }
        public double SWidth1 { get; set; }
        public int SWdth1Unit { get; set; }
        public double SWidth2 { get; set; }
        public int SWdth2Unit { get; set; }
        public double SLength1 { get; set; }
        public int SLen1Unit { get; set; }
        public double Slength2 { get; set; }
        public int SLen2Unit { get; set; }
        public double SVolume { get; set; }
        public int SVolUnit { get; set; }
        public double SWeight1 { get; set; }
        public int SWght1Unit { get; set; }
        public double SWeight2 { get; set; }
        public int SWght2Unit { get; set; }
        public double BHeight1 { get; set; }
        public int BHght1Unit { get; set; }
        public double BHeight2 { get; set; }
        public int BHght2Unit { get; set; }
        public double BWidth1 { get; set; }
        public int BWdth1Unit { get; set; }
        public double BWidth2 { get; set; }
        public int BWdth2Unit { get; set; }
        public double BLength1 { get; set; }
        public int BLen1Unit { get; set; }
        public double Blength2 { get; set; }
        public int BLen2Unit { get; set; }
        public double BVolume { get; set; }
        public int BVolUnit { get; set; }
        public double BWeight1 { get; set; }
        public int BWght1Unit { get; set; }
        public double BWeight2 { get; set; }
        public int BWght2Unit { get; set; }
        public int FirmCode { get; set; }
        public string validFor { get; set; }
        public string frozenFor { get; set; }
    }
}
