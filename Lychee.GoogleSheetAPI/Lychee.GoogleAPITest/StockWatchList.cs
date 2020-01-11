using System;

namespace Lychee.GoogleAPITest
{
    public class StockWatchList
    {
        public string StockCode { get; set; }
        public decimal Entry { get; set; }
        public decimal CutLoss { get; set; }
        public decimal Target { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
