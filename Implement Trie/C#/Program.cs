public class Trie {
    
  public Trie[] Children = new Trie[26];
  public bool EndOfWord;

  /** Initialize your data structure here. */
  public Trie() {
  }

  /** Inserts a word into the trie. */
  public void Insert(string word) {
    var current = this;
    foreach(var ch in word) {
      if (current.Children[ch - 'a'] == null) {
        current.Children[ch - 'a'] = new Trie();
      }
      current = current.Children[ch - 'a'];
    }
    current.EndOfWord = true;
  }

  /** Returns if the word is in the trie. */
  public bool Search(string word) {
    var current = this;
    foreach(var ch in word) {   
      current = current.Children[ch - 'a'];
      if (current == null)
        return false;
    }
    return current.EndOfWord;
  }

  /** Returns if there is any word in the trie that starts with the given prefix. */
  public bool StartsWith(string prefix) {
    var current = this;
    foreach(var ch in prefix) {   
      current = current.Children[ch - 'a'];

      if (current == null)
          return false;
    }
    return true;
  }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */