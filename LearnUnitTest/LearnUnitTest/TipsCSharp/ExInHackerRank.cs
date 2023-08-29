using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnUnitTest.TipsCSharp
{
    public class ExInHackerRank
    {
       public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();
            int rank = 1;
            foreach (int r in ranked)
            {
                if (!hm.ContainsKey(r))
                {
                    hm[r] = rank;
                    rank += 1;
                }
            }

            List<int> ans = new List<int>();
            int i = ranked.Count - 1;
            foreach (int play in player)
            {
                while (i >= 0)
                {
                    if (play == ranked[i])
                    {
                        ans.Add(hm[ranked[i]]);
                        break;
                    }
                    else if (play < ranked[i])
                    {
                        ans.Add(hm[ranked[i]] + 1);
                        break;
                    }
                    else if (i == 0)
                    {
                        ans.Add(1);
                        break;
                    }
                    else
                    {
                        hm[ranked[i]] += 1;
                        i -= 1;
                    }
                }
            }

            return ans;
        }

       
    }
}
