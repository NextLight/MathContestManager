using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class ContestManager
    {
        private IEnumerable<ContestTask> _tasks;
        private IEnumerable<ContestTeam> _teams;

        /// <summary>
        /// List of teams in the match
        /// </summary>
        public IEnumerable<ContestTeam> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams != null)
                    throw new Exception("You can set teams only once!");
                _teams = value.ToList();
            }
        }

        public IEnumerable<ContestTask> Tasks
        {
            get { return _tasks; }
            set
            {
                if (Teams == null)
                    throw new Exception("You must set teams first!");
                if (_tasks != null)
                    throw new Exception("You can set tasks only once!");
                _tasks = value.ToList();
                foreach (ContestTeam team in Teams)
                    team.Tasks = _tasks.Select(task => new ContestTaskScore(task));
            }
        }
    }
}
