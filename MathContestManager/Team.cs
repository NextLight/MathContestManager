using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class Team
    {
        public Team()
        {
            Tasks = new List<Task>();
        }
        /// <summary>
        /// Team's tasks status
        /// </summary>
        public List<Task> Tasks { get; private set; }

        /// <summary>
        /// Team's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get the current team' score
        /// </summary>
        public int Score
        {
            get
            {
                return Tasks.Sum(t => t.TotalScore);
            }
        }
    }
}
