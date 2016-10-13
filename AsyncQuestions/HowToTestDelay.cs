using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncQuestions.Utils;

namespace AsyncQuestions
{
    internal class HowToTestDelay
    {
        private readonly ITaskRunner _task;

        public HowToTestDelay(ITaskRunner task)
        {
            _task = task;
        }

        public async Task<int> DoSomethingUsingTaskRunner()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            await _task.Delay(TimeSpan.FromSeconds(5));
            return 3;
        }

        public async Task<int> DoSomethingUsingTask()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            await Task.Delay(TimeSpan.FromSeconds(5));
            return 3;
        }
    } 
}
