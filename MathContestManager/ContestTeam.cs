using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class ContestTeam
    {
        private IEnumerable<ContestTaskScore> _taskScores;

        /// <summary>
        /// Returns the team current score
        /// </summary>
        public int Score
        {
            get { return (int)_taskScores?.Sum((t) => t.CurrentScore); }
        }

        /// <summary>
        /// Team's name
        /// </summary>
        public string Name { get; set; }

        public IEnumerable<ContestTaskScore> Tasks
        {
            get { return _taskScores; }
            set { _taskScores = value.ToList(); }
        }
    }
}
