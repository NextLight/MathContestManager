using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    class ContestManager
    {
        /// <summary>
        /// List of teams in the match
        /// </summary>
        public List<Team> Teams { get; set; }

        public ContestManager()
        {
            Teams = new List<Team>();
        }

        /// <summary>
        /// Insert the answer for a task given from a team
        /// </summary>
        /// <param name="teamName">Name of the team wich gave the answer</param>
        /// <param name="task">Index of the task</param>
        /// <param name="answer">Answer</param>
        public void InsertAnswer(string teamName, int task, int answer)
        {
            try
            {
                Team team = Teams.Find(x => x.Name == teamName);
                team.Tasks[task].InsertAnswer(answer);
            }
            catch { }
        }
    }
}
