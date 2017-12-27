using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public static class Distance
    {
        public static int CountDistance(string word1, string word2)
        {
            if ((word1 == null) || (word2 == null)) return -1;

            int len1 = word1.Length;
            int len2 = word2.Length;
            if ((len1 == 0) && (len2 == 0)) return 0;
            if (len1 == 0) return len2;
            if (len2 == 0) return len1;

            string str1 = word1.ToUpper();
            string str2 = word2.ToUpper();

            int[,] matrix = new int[len1 + 1, len2 + 1];
            for (int i = 0; i <= len1; i++) matrix[i, 0] = i;
            for (int j = 0; j <= len2; j++) matrix[0, j] = j;

            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int symbEqual = ((str1.Substring(i - 1, 1) == str2.Substring(j - 1, 1)) ? 0 : 1);
                    int I = matrix[i, j - 1] + 1; 
                    int D = matrix[i - 1, j] + 1; 
                    int S = matrix[i - 1, j - 1] + symbEqual;
                    matrix[i, j] = Math.Min(Math.Min(I, D), S);
                    if ((i > 1) && (j > 1) &&
                        (str1.Substring(i - 1, 1) == str2.Substring(j - 2, 1)) &&
                        (str1.Substring(i - 2, 1) == str2.Substring(j - 1, 1)))
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + symbEqual);
                    }
                }
            }
            return matrix[len1, len2];
        }
    }
}
