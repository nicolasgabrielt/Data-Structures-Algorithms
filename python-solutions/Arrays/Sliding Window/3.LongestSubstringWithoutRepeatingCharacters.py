'''
Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/
Author: Nicolas Gabriel
Date: 14/02/21
'''
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
            
        
        
        
        