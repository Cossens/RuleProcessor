using System;
using System.Collections.Generic;
using System.Text;

namespace RulesExecutor.Models
{
    public class Rule
    {
        public string Message { get; set; }
        public Func<int, bool> ApplyRule { get; set; }
    }
}
