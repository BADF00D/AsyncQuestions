using System;
using System.Threading.Tasks;

namespace AsyncQuestions.Utils
{
    internal interface ITaskRunner
    {
        Task Delay(TimeSpan timeout);
    }
}