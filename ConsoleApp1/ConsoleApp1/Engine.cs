using System;
using System.Collections.Generic;
using System.Linq;

namespace Football {
    public class Engine {
        public static void Start() {
            List<string> pos = new List<string>();
            Console.WriteLine("==============================");
            Console.WriteLine("= Football Transfer Strategy =");
            Console.WriteLine("==============================");
            Console.WriteLine("\n");
            int prio = 0;
            int budget = 0;
            string temp_choice = " ";
            string method = " ";
            while (true) {
                Console.Write("Insert how many players that you need (Max 10): ");
                prio = Convert.ToInt32(Console.ReadLine());
                if (prio > 0 && prio <= 10) {
                    break;
                }
            }
            for (int i = 0; i < prio; i++) {
                while (true) {
                    Console.Write("Choose your priority positions [#" + (i + 1) + "]: ");
                    temp_choice = Convert.ToString(Console.ReadLine());
                    if (Dictionary.LegalPos().IndexOf(temp_choice) != -1) {
                        break;
                    }
                }
                pos.Add(temp_choice);
            }
            while (true) {
                Console.Write("Insert your budget (Max 300 million): ");
                budget = Convert.ToInt32(Console.ReadLine());
                if (budget > 0 && budget <= 300000000) {
                    break;
                }
            }
            while (true) {
                Console.Write("Choose your search method (Greedy/Dynamic Programming): ");
                method = Convert.ToString(Console.ReadLine());
                if (method.Equals("Greedy") || method.Equals("Dynamic Programming")) {
                    break;
                }
            }

            ITraverse searche = method.Equals("Greedy") ? new Greedy() : new DynamicProgramming();
            List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> solutions = searche.getSolutions(pos, prio, budget);

            HashSet<string> uniqueSolutions = new HashSet<string>();
            Random random = new Random();
            int solutionCount = 0;
            const int maxSolutions = 5;

            Console.WriteLine();

            foreach (var solution in solutions) {
                if (solution.Count == prio) {
                    string solutionKey = string.Join(",", solution.Select(player => player.id));
                    if (!uniqueSolutions.Contains(solutionKey)) {
                        Console.WriteLine(solutionCount+1);
                        uniqueSolutions.Add(solutionKey);
                        solutionCount++;
                        foreach (var player in solution) {
                            Console.WriteLine(player.name+": ");
                            Console.WriteLine("    Rating:        "+player.rating);
                            Console.WriteLine("    Market Value:  "+player.market_value);
                            Console.WriteLine("    Agents Fee:    "+player.agent_fee);
                            Console.WriteLine("    Age:           "+player.age);
                            Console.WriteLine("    Free Transfer: "+player.is_free);
                        }
                        Console.WriteLine();

                        if (solutionCount >= maxSolutions) {
                            break;
                        }
                    }
                }
            }
        }
    }
}
