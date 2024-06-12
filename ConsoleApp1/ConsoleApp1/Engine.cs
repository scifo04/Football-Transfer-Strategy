using System;
using System.Collections.Generic;

namespace Football {
    public class Engine {
        public static void Start() {
            List<String> pos = new List<String>();
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
                    Console.Write("Choose your priority positions [#"+(i+1)+"]: ");
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
            if (method.Equals("Greedy")) {
                ITraverse searche = new Greedy();
                List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> solutions = searche.getSolutions(pos,prio,budget);
                for (int i = 0; i < solutions.Count; i++) {
                    for (int j = 0; j < solutions[i].Count; j++) {
                        Console.WriteLine(solutions[i][j]);
                    }
                }
            } else {
                ITraverse searche = new DynamicProgramming();
                List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> solutions = searche.getSolutions(pos,prio,budget);
            }
        }
    }
}