using System;
using System.Collections.Generic;

namespace Football {
    public class Util {
        public static double WeightSumModel(int rating, int market_value, int agent_fee, int age) {
            double ratingNorm = (rating-Dictionary.MinRating) / (Dictionary.MaxRating-Dictionary.MinRating);
            double transferNorm = (Dictionary.MaxMarketValue-market_value) / (Dictionary.MaxMarketValue-Dictionary.MinMarketValue);
            double agentNorm = (Dictionary.MaxAgentFee-agent_fee) / (Dictionary.MaxAgentFee-Dictionary.MinAgentFee);
            double ageNorm = (Dictionary.MaxAge-age) / (Dictionary.MaxAge-Dictionary.MinAge);
            return ratingNorm*Dictionary.WeightRating+transferNorm*Dictionary.WeightTransfer+agentNorm*Dictionary.WeightAgent+ageNorm*Dictionary.WeightAge;
        }
        public static List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> filterPosition(string pos) {
            List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> filtered = new List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>();
            List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> full = DataReader.getData();
            for (int i = 0; i < full.Count; i++) {
                if (full[i].position.Equals(pos)) {
                    filtered.Add(full[i]);
                }
            }
            return filtered;
        }
        public static bool availCheck(List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> a, (int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free) b) {
            bool avail = false;
            for (int i = 0; i < a.Count; i++) {
                if (a[i].id.Equals(b.id)) {
                    avail = true;
                    return avail;
                }
            }
            return avail;
        }
        public static double[,] createInfs(int row, int col) {
            double[,] data = new double[row,col];
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; i++) {
                    data[i,j] = 0;
                }
            }
            return data;
        }
    }
}