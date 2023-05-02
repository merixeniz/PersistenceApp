using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.Trees
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode currentNode = _root;
            foreach (char c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    currentNode.Children[c] = new TrieNode();
                }
                currentNode = currentNode.Children[c];
            }
            currentNode.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode currentNode = _root;
            foreach (char c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    return false;
                }
                currentNode = currentNode.Children[c];
            }
            return currentNode.IsEndOfWord;
        }
    }

}
