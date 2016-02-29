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
        /// 
        /// </summary>
        /// <param name="name">The name of the team</param>
        /// <param name="tasks">Tasks for the team</param>
        public Team(string name, Task[] tasks)
        {
            Name = name;
            Tasks = tasks;
        }

        /// <summary>
        /// Team's tasks status
        /// </summary>
        public Task[] Tasks { get; private set; }

        /// <summary>
        /// Team's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the current team' score
        /// </summary>
        public int Score
        {
            get
            {
                return Tasks == null ? 0 : Tasks.Sum(x => x.TotalScore);
            }
        }
    }
}
