using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    class Task
    {
        private static int _errorScore;
        private static string[] _answers;
        private static int[] _scores;

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
                return IsRight ? _scores[Id] : _errorScore * _errors;
            }
        }

        /// <summary>
        /// Total score for this task (including errors)
        /// </summary>
        public int TotalScore
        {
            get
            {
                return _errorScore * _errors + (IsRight ? _scores[Id] : 0);
            }
        }

        /// <summary>
        /// Insert task's answer
        /// </summary>
        /// <param name="ans">Answer</param>
        public void InsertAnswer(string ans)
        {
            if (ans == _answers[Id])
                IsRight = true;
            else
                ++_errors;
        }

        /// <summary>
        /// Sets tasks' datas
        /// </summary>
        /// <param name="ans">Vector of 4-digits strings, the answers to the tasks</param>
        /// <param name="sco">Vector of ints, the score assigned when the right answer is given</param>
        /// <param name="errSco">Score to be subtracted from the total score when a wrong answer is given</param>
        public void SetValues(string[] ans, int[] sco, int errSco)
        {
            _answers = ans;
            _scores = sco;
            _errorScore = -errSco;
        }
    }
}
