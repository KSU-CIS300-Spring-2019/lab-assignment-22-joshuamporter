using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// The bool for whether the string is empty
        /// </summary>
        private bool _isEmptyString;
        /// <summary>
        /// The child
        /// </summary>
        private ITrie _onlyChild;
        /// <summary>
        /// The label
        /// </summary>
        private char _label;

        /// <summary>
        /// The add method for 1 child
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmptyString = true;

            }
            else if (s != "" && s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                
            }
            else if (s != "" && s[0] != _label)
            {
                return new TrieWithManyChildren(s, _isEmptyString, _label, _onlyChild);
            }
            return this;
        }

        /// <summary>
        /// The contains method fro 1 child
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmptyString;
            }
            else if (s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
                
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        /// <param name="childLabel">The label of the child.</param>
        /// <param name="child">The child labeled childLabel.</param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] > 'z' || s[0] < 'a')
            {
                throw new ArgumentException();
            }
            _isEmptyString = hasEmpty;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }
    }
}
