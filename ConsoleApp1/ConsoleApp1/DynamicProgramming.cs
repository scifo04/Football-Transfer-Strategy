using System;
using System.Collections.Generic;
using System.Linq;
using Football;

public class DynamicProgramming : ITraverse {
    public List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> getSolutions(List<string> pos, int prio, int budget) {
        HashSet<int> selectedIds = new HashSet<int>();
        var allSolutions = getSolutionsHelper(pos, pos.Count - 1, budget, selectedIds);
        return allSolutions.Select(solution => solution.players).ToList();
    }

    private List<(double weightSum, List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> players)> getSolutionsHelper(List<string> positions, int posIndex, int budget, HashSet<int> selectedIds) {
        if (posIndex < 0 || budget <= 0) {
            return new List<(double, List<(int, string, int, string, int, int, int, bool)>)> {
                (0, new List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>())
            };
        }

        string pos = positions[posIndex];
        var allSolutions = new List<(double, List<(int, string, int, string, int, int, int, bool)>)>();

        var withoutCurrentPlayer = getSolutionsHelper(positions, posIndex - 1, budget, new HashSet<int>(selectedIds));
        allSolutions.AddRange(withoutCurrentPlayer);

        foreach (var player in Util.filterPosition(pos)) {
            if (!selectedIds.Contains(player.id)) { 
                int cost = player.market_value + player.agent_fee;
                if (cost <= budget) {
                    var selectedIdsCopy = new HashSet<int>(selectedIds) { player.id };
                    var withCurrentPlayerLists = getSolutionsHelper(positions, posIndex - 1, budget - cost, selectedIdsCopy);

                    foreach (var (weightSum, withCurrentPlayer) in withCurrentPlayerLists) {
                        var newSolution = new List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>(withCurrentPlayer) {
                            player
                        };
                        var convertA = newSolution.Select(x => (x.rating, x.market_value, x.agent_fee, x.age)).ToList();
                        double newWeightSum = Util.WeightSumModel(convertA);
                        allSolutions.Add((newWeightSum, newSolution));
                    }
                }
            }
        }

        return allSolutions;
    }
}
