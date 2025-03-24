namespace Perfume.Models
{
    public class TrieModel
    {
        public Dictionary<char, TrieModel> Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieModel()
        {
            Children = new Dictionary<char, TrieModel>();
            IsEndOfWord = false;
        }
    }
}
