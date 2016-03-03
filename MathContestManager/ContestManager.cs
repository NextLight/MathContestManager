using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class ContestManager
    {
        /// <summary>
        /// List of teams in the match
        /// </summary>
        public List<Team> Teams { get; set; }

        public ContestManager(IEnumerable<Team> teams)
        {
            Teams = teams.ToList();
        }

        /// <summary>
        /// Insert the answer for a task given from a team
        /// </summary>
        /// <param name="teamName">Name of the team wich gave the answer</param>
        /// <param name="taskId">Index of the task</param>
        /// <param name="answer">Answer</param>
        public void InsertAnswer(string teamName, int taskId, int answer)
        {
            var tasks = Teams.First(x => x.Name == teamName).Tasks;
            if (!tasks.Any(t => t.Id == taskId))
                tasks.Add(new Task(taskId));
            tasks.First(t => t.Id == taskId).InsertAnswer(answer);
        }
    }
}
