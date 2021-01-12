public class Trie {
  public Trie[] Children = new Trie[26];
  public bool EndOfWord;

  public bool Search(string word, int start) {
    var current = this;
    for (int i = start; i < word.Length; i++) {
      var ch = word[i];
        
      if (ch == '.') {
        foreach(var trie in current.Children) {
          //Recursive call
          //If any of the Search call return true then we return true and stop
          if (trie != null && trie.Search(word, i + 1))
            return true;
        }
        return false;
      } 
      else {
        if (current.Children[ch - 'a'] == null) return false;
          
        current = current.Children[ch - 'a'];
      }
    }
    return current != null && current.EndOfWord;
  }
}

public class WordDictionary {
  Trie root = new Trie();

  public void AddWord(string word) {
    var current = root;
    foreach(var ch in word) {
      if (current.Children[ch - 'a'] == null)
        current.Children[ch - 'a'] = new Trie();

      current = current.Children[ch - 'a'];
    }

    //Mark end of the word
    current.EndOfWord = true;
  }

  public bool Search(string word) {
    return root.Search(word, 0);
  }
}