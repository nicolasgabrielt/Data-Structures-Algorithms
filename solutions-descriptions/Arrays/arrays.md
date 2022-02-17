### Arrays

- [Sliding Window]((https://github.com/nicolasgabrielt/Data-Structures-Algorithms/blob/main/solutions-descriptions/Arrays/arrays.md#sliding-window))
- Two Pointers
- Prefix Sum
- Merge Intervals
- Subsets
- Sliding Window
- K way Merge
- Binary Search

#### Sliding Window
##### [3. Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/)

```
Technique: Sliding Window
DataStructures: Dictionary
Time Complexity: O(n)
Space Complexity: O(1), because we will have at maximum 128 chars (Unicode) or 256 chars (ASCII)
```

###### C# Solution
```C#
public int LengthOfLongestSubstring(string s) {
    if(s.Length == 0) return 0;
    
    Dictionary<char, int> charPos = new Dictionary<char,int>();
    int maxLength = 0, start = 0;
    
    for(var end = 0; end < s.Length; end++){
        char currChar = s[end];
        int lastPos = charPos.ContainsKey(currChar) ? charPos[currChar] : -1;
        
        start = Math.Max(start, lastPos + 1);
        maxLength = Math.Max(maxLength, end - start + 1);
        charPos[currChar] = end;
    }    
    
    
    return maxLength;
}
```

###### Python Solution
```python
def lengthOfLongestSubstring(self, s: str) -> int:
    if(len(s) == 0): return 0
    
    start, maxLength = 0, 0
    charPos = {}
    
    for end in range(len(s)):
        currChar = s[end]
        lastPos = charPos.get(currChar, -1)
        
        start = max(start, lastPos + 1)
        maxLength = max(maxLength , end - start + 1)
        charPos[currChar] = end
        
    return maxLength
```

##### [76. Minimum Window Substring](https://leetcode.com/problems/minimum-window-substring/)

```
Technique: Sliding Window
DataStructures: Dictionary
Time Complexity: O(N + M), where N is the size of S and M is the size of t
Space Complexity: O(N + M)
```

###### C# Solution
```C#
public string MinWindow(string s, string t) {
    var counterT = new Dictionary<char, int>();

    foreach(var curr in t)
    {
        if(counterT.ContainsKey(curr)){
            counterT[curr]++;
        }else{
            counterT.Add(curr, 1);
        }
    }

    var filteredS = new List<(char c, int pos)>();
    for(var index = 0; index < s.Length; index++){
        var curr = s[index];
        if(counterT.ContainsKey(curr)){
            filteredS.Add((curr, index));
        }
    }

    var left = 0;
    var answer = (size: s.Length + 1, start: 0, end: 0);
    var counterS = new Dictionary<char,int>();
    var matches = 0;

    for(int right= 0; right < filteredS.Count; right++){
        (char c, int pos) = filteredS[right];
        
        int currCount;
        if(counterS.ContainsKey(c)){
            counterS[c]++;
            currCount = counterS[c];
        }else{
            currCount = 1;
            counterS.Add(c, currCount);
        }
        
        if(currCount == counterT[c]) matches++;
        
        while(left <= right && matches == counterT.Count){
            var firstChar = filteredS[left];
            var currSize = pos - firstChar.pos + 1;
            
            if(currSize <= answer.size){
                answer = (currSize, firstChar.pos, pos);
            }
            
            
            if(counterS[firstChar.c] == counterT[firstChar.c]) matches--;
            counterS[firstChar.c]--;
            left++;
            
        }
        
    }

    if(answer.size > s.Length) return "";

    return s.Substring(answer.start, answer.size);
}
```

###### Python Solution
```python
def minWindow(self, s: str, t: str) -> str:
    counter_t = {}

    for char in t:
        counter_t[char] = counter_t.get(char, 0) + 1


    filtered_s = []
    for index, char in enumerate(s):
        if char in counter_t:
            filtered_s.append((index, char))
            

    required_matches = len(counter_t)
    left, char_matches = 0, 0
    counter_s = {}

    answer = len(s), - 1, -1

    for right in range(len(filtered_s)):
        s_index, curr_char = filtered_s[right]
        
        counter_s[curr_char] = counter_s.get(curr_char, 0) + 1
        
        if counter_s[curr_char] == counter_t[curr_char]: 
            char_matches += 1
        
        while left <= right and char_matches == required_matches:
            curr_size = s_index - filtered_s[left][0] + 1
            
            if answer[0] >= curr_size:
                answer = curr_size, filtered_s[left][0], s_index
            
            
            first_char = filtered_s[left][1]
            
            if counter_s[first_char] == counter_t[first_char]:
                char_matches -= 1
            
            counter_s[first_char] -= 1
            left += 1
            
    return s[answer[1]: answer[2] + 1]
```
