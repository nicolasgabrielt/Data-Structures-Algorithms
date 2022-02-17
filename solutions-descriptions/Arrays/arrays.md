### Arrays

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
public class Solution {
    
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
}
```

###### Python Solution
```python

class Solution:
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
