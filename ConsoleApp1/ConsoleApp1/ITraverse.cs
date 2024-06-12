using System;
using System.Collections.Generic;

public interface ITraverse {
    List<List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>> getSolutions(List<string> pos, int prios, int budget);
}