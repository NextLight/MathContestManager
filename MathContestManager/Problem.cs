using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    class Problem
    {
        static private int _errorScore;
        static private string[] _answers;
        static private int[] _scores;

        private int _errors = 0;

        /// <summary>
        /// The problem's identifier
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// True if the right answer is given
        /// </summary>
        public bool IsRight { private set; get; }

        /// <summary>
        /// Score to show in the ranking
        /// </summary>
        public int Score
        {
            get
            {
                if (IsRight)
                    return _scores[ID];

                return _errorScore * _errors;
            }
        }

        /// <summary>
        /// Total score for this problem (including errors)
        /// </summary>
        public int TotalScore
        {
            get
            {
                return _errorScore * _errors + (IsRight ? _scores[ID] : 0);
            }
        }

        /// <summary>
        /// Answer the problem
        /// </summary>
        /// <param name="ans">Answer</param>
        public void InsertAnswer(string ans)
        {
            IsRight = ans == _answers[ID];
        }

        /// <summary>
        /// Sets problems' datas
        /// </summary>
        /// <param name="ans">Vector of 4-digits strings, the answers to the problems</param>
        /// <param name="sco">Vector of ints, the score assigned when the right answer si given</param>
        /// <param name="errSco">Score to be subtracted from the total score when a wrong answer is given</param>
        public void SetValues(string[] ans, int[] sco, int errSco)
        {
            _answers = ans;
            _scores = sco;
            _errorScore = -errSco;
        }
    }
}
