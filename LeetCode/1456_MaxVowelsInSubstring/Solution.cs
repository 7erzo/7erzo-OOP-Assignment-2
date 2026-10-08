public class Solution {
    public int MaxVowels(string s, int k) {
        bool IsVowel(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';

        int currentVowels = 0;

        for (int i = 0; i < k; i++) {
            if (IsVowel(s[i])) {
                currentVowels++;
            }
        }

        int maxVowels = currentVowels;

        for (int i = k; i < s.Length; i++) {
            if (IsVowel(s[i])) {
                currentVowels++;
            }
            if (IsVowel(s[i - k])) {
                currentVowels--;
            }

            if (currentVowels > maxVowels) {
                maxVowels = currentVowels;
            }

            if (maxVowels == k) {
                return maxVowels;
            }
        }

        return maxVowels;
    }
}