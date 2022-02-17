/** 
Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/
Author: Nicolas Gabriel
Date: 16/02/21
**/
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