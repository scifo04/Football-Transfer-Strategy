using System;
using System.Collections.Generic;
using Football;

public class DynamicProgramming : ITraverse {
    public List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> getSolutions(List<string> pos, int prios, int budget) {
        List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> lists = new List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>>();
        List<double[,]> doubles = new List<double[,]>();
        for (int i = 0; i < prios; i++) {
            lists.Add(Util.filterPosition(pos[i]));
        }
        for (int i = 0; i < prios-1; i++) {
            doubles.Add(Util.createInfs(lists[i].Count,lists[i+1].Count));
        }
        for (int i = 0; i < prios-1; i++) {
            for (int j = 0; j < doubles[i].GetLength(0); j++) {
                for (int k = 0; k < doubles[i].GetLength(1); k++) {
                    doubles[i][j,k] = Util.WeightSumModel(lists[i][j].rating,lists[i][j].market_value,lists[i][j].agent_fee,lists[i][j].age);
                }
            }
        }
    }
}