using System;
using System.Collections.Generic;

namespace Football {
    public class Dictionary {
        public const int MaxAge = 42;
        public const int MinAge = 15;
        public const int MaxRating = 100;
        public const int MinRating = 50;
        public const int MaxMarketValue = 200000000;
        public const int MinMarketValue = 0;
        public const int MaxAgentFee = 10000000;
        public const int MinAgentFee = 0;
        public const double WeightAge = 0.2;
        public const double WeightRating = 0.4;
        public const double WeightTransfer = 0.3;
        public const double WeightAgent = 0.1;
        public const double bound = -1000.0;
        public static List<String> LegalPos() {
            List<String> list = new List<String>();
            list.Add("ST");
            list.Add("CF");
            list.Add("LW");
            list.Add("RW");
            list.Add("CAM");
            list.Add("LM");
            list.Add("RM");
            list.Add("CM");
            list.Add("CDM");
            list.Add("LWB");
            list.Add("RWB");
            list.Add("LB");
            list.Add("RB");
            list.Add("CB");
            list.Add("GK");
            return list;
        }
    }
}