using RulesExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesExecutor.Processors
{
    public class RulesProcessor: IRulesProcessor
    {
        public IEnumerable<string> ProcessRules(int start, int end, List<Rule> rules)
        {
            var range = Enumerable.Range(start, end);

            var result = new List<string>();

            foreach (var item in range)
            {
                var responses = new List<string>();
                foreach (var rule in rules)
                {
                    if(rule.ApplyRule(item))
                    {
                        responses.Add(rule.Message);
                    }                 
                }
                    
                result.Add($"{item}{string.Join(',', responses)}");
            }
            return result;
        }
    }
}
