using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class ContestTask
    {
        public int Answer { get; set; }
        public int CorrectScore { get; set; }
        public int WrongScore { get; set; } = 10;

        /// <summary>
        /// Answer to this task
        /// </summary>
        /// <param name="answer">The answer</param>
        /// <returns>True if it's correct</returns>
        public bool InsertAnswer(int answer)
        {
            return answer == Answer;
        }
    }
}
