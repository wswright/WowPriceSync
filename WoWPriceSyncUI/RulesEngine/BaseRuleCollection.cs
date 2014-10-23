using Scott.WoWAPI.APIModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI.RulesEngine
{
    public class BaseRuleCollection : IList<BaseRule>
    {
        private Item _item;
        public List<BaseRule> rules;
        private ItemHelper component;

        private List<BaseRule> failedRules;

        public BaseRuleCollection(Item item)
        {
            _item = item;
            rules = new List<BaseRule>();
            component = new ItemHelper(_item);
        }

        public bool IsMatch()
        {
            failedRules = new List<BaseRule>();
            bool success = true;

            foreach (BaseRule bRule in rules)
                if (!bRule.IsMatch(component))
                {
                    success = false;
                    failedRules.Add(bRule);
                }
            return success;
        }

        public BaseRule[] GetFailedRules()
        {
            return failedRules.ToArray();
        }

        #region IList<BaseRule> Interface

        public int IndexOf(BaseRule item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, BaseRule item)
        {
            rules.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            rules.RemoveAt(index);
        }

        public BaseRule this[int index]
        {
            get
            {
                return rules[index];
            }
            set
            {
                rules[index] = value;
            }
        }

        public void Add(BaseRule item)
        {
            rules.Add(item);
        }

        public void Clear()
        {
            rules.Clear();
        }

        public bool Contains(BaseRule item)
        {
            return rules.Contains(item);
        }

        public void CopyTo(BaseRule[] array, int arrayIndex)
        {
            rules.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return rules.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(BaseRule item)
        {
            return rules.Remove(item);
        }

        public IEnumerator<BaseRule> GetEnumerator()
        {
            return rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return rules.GetEnumerator();
        }

        #endregion IList<BaseRule> Interface
    }
}
