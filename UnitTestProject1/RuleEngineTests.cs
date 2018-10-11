using System;
using NUnit.Framework;
using RulesExecutor.Processors;
using System.Linq;
using System.Collections.Generic;
using RulesExecutor.Models;

namespace RulesExecutorTests
{
    [TestFixture]
    public class RuleEngineTests
    {
        private RulesProcessor _rulesProcessor;
        private int _start;
        private int _end;

        [SetUp]
        public void Init()
        {
            _rulesProcessor = new RulesProcessor();

            _start = 1;
            _end = 100;
        }

        [Test]
        public void Should_Iterate_Over_Range()
        {
            //arrange
            var rule = new Rule()
            {
                Message = null,
                ApplyRule = x => false
            };

            var rules = new List<Rule>() { rule };

            //act
            var output = _rulesProcessor.ProcessRules(_start, _end, rules);

            //assert
            Assert.AreEqual(_end-_start+1, output.Count());
        }

        [Test]
        public void Should_Execute_Rule_On_Range()
        {
            //arrange

            var rule = new Rule()
            {
                Message = " multiple of 3",
                ApplyRule = x => x % 3 == 0
            };
            var rules = new List<Rule>() { rule };

            //act
            var output = _rulesProcessor.ProcessRules(_start, _end, rules);

            //assert
            Assert.Contains("3 multiple of 3", output.ToList());
        }

        [Test]
        public void Should_Execute_Multiple_Rules_On_Range()
        {
            //arrange
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

            //act
            var output = _rulesProcessor.ProcessRules(_start, _end, rules);

            //assert
            Assert.Contains("3 multiple of 3", output.ToList());
            Assert.Contains("6 multiple of 3, ends in 6", output.ToList());
        }
    }
}
