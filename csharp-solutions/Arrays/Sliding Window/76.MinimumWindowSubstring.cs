/** 
Link: https://leetcode.com/problems/minimum-window-substring/
Author: Nicolas Taveira
Date: 16/02/21
**/

namespace MinimumWindowSubstring{
   public class Solution {
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
}
}