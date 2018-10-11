using RulesExecutor.Models;
using System;
using System.Collections.Generic;

namespace RulesExecutor.Processors
{
    public interface IRulesProcessor
    {
        IEnumerable<string> ProcessRules(int start, int end, List<Rule> rules);
    }
}