namespace MotoApp.NUnitTests
{
    public class Tests
    {
        [Test]
        public void WhenPushThreeElements_ShouldPopTheLastOnePushed()
        {
            //arrange
            var stack = new BasicStack<double>();

            //act
            stack.Push(4.5);
            stack.Push(43);
            stack.Push(333.6);

            //assert
            Assert.AreEqual(333.6, stack.Pop());
        }
    }
}