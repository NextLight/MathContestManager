using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    class Team
    {
        /// <summary>
        /// Problems in the state related to the team
        /// </summary>
        public Problem[] Problems { get; set; }

        /// <summary>
        /// The name of the team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get the current score for the team
        /// </summary>
        public int Score
        {
            get
            {
                if (Problems == null)
                    return 0;

                return Problems.Sum(x => x.TotalScore);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the team</param>
        /// <param name="problems">Problems for the team</param>
        public Team(string name, Problem[] problems)
        {
            Name = name;
            Problems = problems;
        }
    }
}
