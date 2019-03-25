using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Checks whether the empty string is stored at the trie rooted at this node
        /// </summary>
        private bool _isEmptyString = false;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmptyString = true;
            }
            else
            {
                return new TrieWithOneChild(s, _isEmptyString);
            }
            return this;

        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmptyString;
            }
            
            else return false;
        }
    }
}
