﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Util
{
    public class StringDistanceCalculator
    {

        public int GetClosestIndex(List<string> values, List<string> options)
        {
            var closest = GetClosestIndex(values[0], options);
            for (int i = 1; i < values.Count; i++)
            {
                var item = GetClosestIndex(values[i], options);
                if (item.Item2 < closest.Item2)
                    closest = item;
            }
            return closest.Item1;
        }

        public Tuple<int, int> GetClosestIndex(string value, List<string> options)
        {
            var closestIndex = 0;
            var closest = options[0];
            var closestDistance = GetLevenshteinDistance(value, closest);
            for (int i = 1; i < options.Count; i++)
            {
                var item = options[i];
                var distance = GetLevenshteinDistance(value, item);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            return new Tuple<int, int>(closestIndex, closestDistance);
        }

        public string GetClosest(List<string> values, List<string> options)
        {
            return options[GetClosestIndex(values, options)];
        }

        public static int GetLevenshteinDistance(String s, String t)
        {
            if (s == null || t == null)
            {
                throw new ArgumentException("Strings must not be null");
            }

            /*
              The difference between this impl. and the previous is that, rather 
               than creating and retaining a matrix of size s.length()+1 by t.length()+1, 
               we maintain two single-dimensional arrays of length s.length()+1.  The first, d,
               is the 'current working' distance array that maintains the newest distance cost
               counts as we iterate through the characters of String s.  Each time we increment
               the index of String t we are comparing, d is copied to p, the second int[].  Doing so
               allows us to retain the previous cost counts as required by the algorithm (taking 
               the minimum of the cost count to the left, up one, and diagonally up and to the left
               of the current cost count being calculated).  (Note that the arrays aren't really 
               copied anymore, just switched...this is clearly much better than cloning an array 
               or doing a System.arraycopy() each time  through the outer loop.)

               Effectively, the difference between the two implementations is this one does not 
               cause an out of memory condition when calculating the LD over two very large strings.  		
            */

            int n = s.Length; // length of s
            int m = t.Length; // length of t

            if (n == 0)
            {
                return m;
            }
            else if (m == 0)
            {
                return n;
            }

            int[] p = new int[n + 1]; //'previous' cost array, horizontally
            int[] d = new int[n + 1]; // cost array, horizontally
            int[] _d; //placeholder to assist in swapping p and d

            // indexes into strings s and t
            int i; // iterates through s
            int j; // iterates through t

            char t_j; // jth character of t

            int cost; // cost

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                t_j = t[j - 1];
                d[0] = j;

                for (i = 1; i <= n; i++)
                {
                    cost = s[i - 1] == t_j ? 0 : 1;
                    // minimum of cell to the left+1, to the top+1, diagonally left and up +cost				
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }

                // copy current distance counts to 'previous row' distance counts
                _d = p;
                p = d;
                d = _d;
            }

            // our last action in the above loop was to switch d and p, so p now 
            // actually has the most recent cost counts
            return p[n];
        }

    }
}
