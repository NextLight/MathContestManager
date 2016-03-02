using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class Solution
    {
        public int? Answer { get; set; }
        public int? Score { get; set; }
    }
    public class Task
    {
        private static int _errorScore = 10;
        private static Solution[] _solutions;

        private int _errors = 0;

        public Task(int id)
        {
            Id = id;
        }

        /// <summary>
        /// The task's identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// True if the right answer has been given
        /// </summary>
        public bool IsRight { get; private set; }

        /// <summary>
        /// Score to be shown in the ranking
        /// </summary>
        public int Score
        {
            get
            {
                return IsRight ? _solutions[Id].Score.Value : _errorScore * _errors;
            }
        }

        /// <summary>
        /// Total score for this task (including errors)
        /// </summary>
        public int TotalScore
        {
            get
            {
                return _errorScore * _errors + (IsRight ? _solutions[Id].Score.Value : 0);
            }
        }

        /// <summary>
        /// Insert task's answer
        /// </summary>
        /// <param name="ans">Answer</param>
        public void InsertAnswer(int ans)
        {
            if (ans == _solutions[Id].Answer)
                IsRight = true;
            else
                ++_errors;
        }

        /// <summary>
        /// Sets tasks' datas
        /// </summary>
        /// <param name="solutions">Array with the solution to each task.</param>
        /// <param name="errSco">Score to be subtracted from the total score when a wrong answer is given</param>
        public static void SetValues(IEnumerable<Solution> solutions, int errScore)
        {
            _solutions = solutions.ToArray();
            _errorScore = -errScore;
        }
    }
}
