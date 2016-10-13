using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace AsyncQuestions.Tests
{
    [TestFixture]
    public class SpotTheDifference
    {
        private readonly TimeSpan WaitTime = 999.Milliseconds();

        [Test]
        public void FailingWait()
        {
            var stopWatch = new Stopwatch();

            Task.Delay(WaitTime).GetAwaiter().GetResult();

            stopWatch.Stop();

            //schlägt bei WaitTime < 1000ms fehl => Warum?
            stopWatch.ElapsedMilliseconds.Should().BeGreaterOrEqualTo(WaitTime.Milliseconds);
        }

        [Test]
        public async Task SuccesfulWait()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await Task.Delay(WaitTime)
                .ContinueWith(t => stopWatch.Stop());

            stopWatch.ElapsedMilliseconds.Should().BeGreaterOrEqualTo(WaitTime.Milliseconds);
        }
    }
}