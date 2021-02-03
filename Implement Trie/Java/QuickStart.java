class Trie {
  public Trie[] children = new Trie[26];
  public boolean endOfWord;
  
  /** Initialize your data structure here. */
  public Trie() {

  }

  /** Inserts a word into the trie. */
  public void insert(String word) {
    var current = this;
    for (char ch: word.toCharArray()) {
      if (current.children[ch - 'a'] == null) {
        current.children[ch - 'a'] = new Trie();
      }
      current = current.children[ch - 'a'];
    }
    current.endOfWord = true;
  }

  /** Returns if the word is in the trie. */
  public boolean search(String word) {
    var current = this;
    for (char ch: word.toCharArray()) {
      current = current.children[ch - 'a'];
      
      if (current == null)
          return false;
    }
    return current.endOfWord;
  }

  /** Returns if there is any word in the trie that starts with the given prefix. */
  public boolean startsWith(String prefix) {
    var current = this;
    for (char ch: prefix.toCharArray()) {
      current = current.children[ch - 'a'];
      
      if (current == null)
          return false;
    }
    return true;
  }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.insert(word);
 * boolean param_2 = obj.search(word);
 * boolean param_3 = obj.startsWith(prefix);
 */