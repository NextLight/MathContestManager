using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathContestManager
{
    public class ContestTaskScore
    {
        private int _wrongAnswers = 0;
        private int _correctAnswers = 0;

        public readonly ContestTask ParentTask;

        /// <summary>
        /// The current score for this team on this task
        /// </summary>
        public int CurrentScore
        {
            get
            {
                return ParentTask.CorrectScore * _correctAnswers - ParentTask.WrongScore * _wrongAnswers;
            }
        }

        /// <summary>
        /// True if a correct answer has been given
        /// </summary>
        public bool IsCorrect
        {
            get { return _correctAnswers > 0; }
        }

        public ContestTaskScore(ContestTask pt)
        {
            ParentTask = pt;
        }

        /// <summary>
        /// Answer to this task
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool InsertAnswer(int answer)
        {
            if (_correctAnswers == 0)
            {
                bool isCorrect = ParentTask.InsertAnswer(answer);
                if (isCorrect)
                    _correctAnswers++;
                else
                    _wrongAnswers++;
                return isCorrect;
            }
            return true;
        }
    }
}
