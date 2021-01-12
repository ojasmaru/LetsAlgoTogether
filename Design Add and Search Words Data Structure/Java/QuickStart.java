class Trie {
  public Trie[] children = new Trie[26];
  public boolean endOfWord;

  public boolean search(char[] chars, int start) {
    var current = this;
    for (var i = start; i < chars.length; i++) {
      var ch = chars[i];

      if (ch == '.') {
        for (var trie: current.children) {
          //Recursive call
          //If any of the Search call return true then we return true and stop
          if (trie != null && trie.search(chars, i + 1)) return true;
        }
        return false;
      }
      else {
        if (current.children[ch - 'a'] == null) return false;

        current = current.children[ch - 'a'];
      }
    }
    return current != null && current.endOfWord;
  }
}

class WordDictionary {
  Trie root = new Trie();

  public void addWord(String word) {
    var current = root;
    for (char ch: word.toCharArray()) {
      if (current.children[ch - 'a'] == null) {
        current.children[ch - 'a'] = new Trie();
      }
      current = current.children[ch - 'a'];
    }
    //Mark end of the word
    current.endOfWord = true;
  }

  public boolean search(String word) {
    return root.search(word.toCharArray(), 0);
  }
}