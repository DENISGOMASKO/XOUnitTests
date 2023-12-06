using WpfLibrary.Core;

namespace TestProject
{
    public class UnitTest3
    {
        [Fact]
        public void Test1()
        {
            WpfLibrary.Contexts.ApplicationContext.ChangedXO = PlayingFieldStatus.X;
            Assert.Equal(WpfLibrary.Contexts.ApplicationContext.EnemyXO, PlayingFieldStatus.O);
        }
        [Fact]
        public void Test2()
        {
            WpfLibrary.Contexts.ApplicationContext.ChangedXO = PlayingFieldStatus.O;
            Assert.Equal(WpfLibrary.Contexts.ApplicationContext.EnemyXO, PlayingFieldStatus.X);
        }
    }
}