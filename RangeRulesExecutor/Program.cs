using RulesExecutor.Models;
using RulesExecutor.Processors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            var multipleOf3 = new Rule()
            {
                Message = " multiple of 3",
                ApplyRule = x => x % 3 == 0
            };

            var endsIn6 = new Rule()
            {
                Message = " ends in 6",
                ApplyRule = x => x % 10 == 6
            };

            var rules = new List<Rule>() { multipleOf3, endsIn6 };


            var rulesProcessor = new RulesProcessor();

            var output = rulesProcessor.ProcessRules(1, 100, rules);

            output.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("----Done----");
            Console.ReadKey();
        }
    }
}
