'''
Link: https://leetcode.com/problems/minimum-window-substring/
Author: Nicolas Taveira
Date: 16/02/21
'''

class Solution:
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