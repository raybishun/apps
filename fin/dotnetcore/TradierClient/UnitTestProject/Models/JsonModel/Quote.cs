namespace UnitTestProject.Models.JsonModel
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Exch { get; set; }
        public string Type { get; set; }
        public double Last { get; set; }
        public double Change { get; set; }
        public int Volume { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double ChangePercentage { get; set; }
        public int AverageVolume { get; set; }
        public int LastVolume { get; set; }
        public long TradeDate { get; set; }
        public double Prevclose { get; set; }
        public double Week52High { get; set; }
        public double Week52Low { get; set; }
        public int BidSize { get; set; }
        public string BidExch { get; set; }
        public long BidDate { get; set; }
        public int AskSize { get; set; }
        public string AskExch { get; set; }
        public long AskDate { get; set; }
        public string Rootsymbols { get; set; }
    }
}
