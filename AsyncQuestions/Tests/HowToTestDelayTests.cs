using System;
using System.Threading.Tasks;
using AsyncQuestions.Utils;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AsyncQuestions.Tests
{
    [TestFixture]
    public class HowToTestDelayTests
    {
        [Test]
        public async Task Testing_DoSomethingUsingTaskRunner()
        {
            //arrange
            var runner = A.Fake<ITaskRunner>();
            A.CallTo(() => runner.Delay(A<TimeSpan>._))
                .Returns(Task.FromResult(false));
            var sut = new HowToTestDelay(runner);

            //act
            var result = await sut.DoSomethingUsingTaskRunner();
            //assert

            //I can test time, if this is needed
            A.CallTo(() => runner.Delay(A<TimeSpan>.That.Matches(t => t.TotalSeconds == 5)))
                .MustHaveHappened(Repeated.Exactly.Once);

            result.ShouldBeEquivalentTo(3);
        }

        [Test]
        public async Task Testing_DoSomethingTask()
        {
            //arrange
            var sut = new HowToTestDelay(null);

            //act
            var result = await sut.DoSomethingUsingTask();
            
            //assert
            //I cant test the time
            result.ShouldBeEquivalentTo(3);
        }
    }
}