using Perfume.Models;

namespace Perfume.Services
{

    public class Trie
    {
        private readonly TrieModel root;

        public Trie()
        {
            root = new TrieModel();
        }
        public void Insert(string word)
        {
            var currentNode = root;
            foreach (var ch in word.ToLower()) 
            {
                if (!currentNode.Children.ContainsKey(ch))
                {
                    currentNode.Children[ch] = new TrieModel();
                }

                currentNode = currentNode.Children[ch];
            }

            currentNode.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            var currentNode = root;
            foreach (var ch in word.ToLower())
            {
                if (!currentNode.Children.ContainsKey(ch))
                {
                    return false;
                }

                currentNode = currentNode.Children[ch];
            }

            return currentNode.IsEndOfWord;
        }

        
        public List<string> StartsWith(string prefix)
        {
            var currentNode = root;
            foreach (var ch in prefix.ToLower())
            {
                if (!currentNode.Children.ContainsKey(ch))
                {
                    return new List<string>(); 
                }

                currentNode = currentNode.Children[ch];
            }

            var results = new List<string>();
            FindWords(currentNode, prefix.ToLower(), results);
            return results;
        }

        private void FindWords(TrieModel node, string prefix, List<string> results)
        {
            if (node.IsEndOfWord)
            {
                results.Add(prefix);
            }

            foreach (var child in node.Children)
            {
                FindWords(child.Value, prefix + child.Key, results);
            }
        }
    }
}
