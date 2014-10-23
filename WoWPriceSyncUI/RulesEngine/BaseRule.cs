using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI.RulesEngine
{
    public class BaseRule
    {
        public enum RuleOperator { LessThan, LessThanOrEqualTo, EqualTo, GreaterThan, GreaterThanOrEqualTo, NotEqualTo };
        
        private string propertyName;
        private RuleOperator ruleOperator;
        private double value;

        public BaseRule(string propertyName, RuleOperator ruleOperator, double value)
        {
            this.propertyName = propertyName;
            this.ruleOperator = ruleOperator;
            this.value = value;
        }

        public BaseRule()
        {
            propertyName = string.Empty;
            ruleOperator = RuleOperator.EqualTo;
            value = 0.0;
        }

        public void SetPropertyName(string pName)
        {
            propertyName = pName;
        }

        public void SetRuleOperator(RuleOperator pOp)
        {
            ruleOperator = pOp;
        }

        public void SetValue(double pVal)
        {
            value = pVal;
        }

        public bool IsMatch(ItemHelper item)
        {
            throw new NotImplementedException();
        }

        public static string[] GetOperators()
        {
            var ops = Enum.GetValues(typeof(BaseRule.RuleOperator)).Cast<BaseRule.RuleOperator>().ToList();
            List<string> lOps = new List<string>();
            foreach (BaseRule.RuleOperator rOp in ops)
            {
                lOps.Add(Enum.GetName(typeof(BaseRule.RuleOperator), rOp));
            }
            return lOps.ToArray();
        }
    }
}
