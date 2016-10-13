using System;
using System.Threading.Tasks;

namespace AsyncQuestions.Utils
{
    internal class TaskRunner : ITaskRunner
    {
        public Task Delay(TimeSpan timeout)
        {
            return Task.Delay(timeout);
        }
    }
}