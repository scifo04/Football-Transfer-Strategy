using System;
using System.Collections.Generic;
using System.Linq;
using Football;

public class Greedy : ITraverse {
    public List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> getSolutions(List<string> pos, int prios, int budget) {
        int used = 0;
        List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> sent = new List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>();
        List<double> weightSum = new List<double>();
        for (int i = 0; i < prios; i++) {
            List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> filtere = Util.filterPosition(pos[i]);
            filtere.RemoveAll(x => (used+x.market_value+x.agent_fee > budget && x.is_free == false) || Util.availCheck(sent,x));
            var maxFilter = filtere
                .Select(x => (x, weightSum: Util.WeightSumModel(x.rating, x.market_value, x.agent_fee, x.age)))
                .OrderByDescending(x => x.weightSum)
                .FirstOrDefault()
                .x;
            used += maxFilter.market_value+maxFilter.agent_fee;
            if (maxFilter.id == 0) {
                break;
            }
            sent.Add(maxFilter);
        }
        List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> a = new List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>>();
        a.Add(sent);
        return a;
    }
}