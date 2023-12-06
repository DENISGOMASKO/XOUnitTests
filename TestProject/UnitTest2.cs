using WpfLibrary.Core;

namespace TestProject
{
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {
            WpfLibrary.Contexts.ApplicationContext.Winner = PlayingFieldStatus.X;
            Assert.Equal(WpfLibrary.Contexts.ApplicationContext.WinnerText, "Победил КРЕСТИК");
        }
        [Fact]
        public void Test2()
        {
            WpfLibrary.Contexts.ApplicationContext.Winner = PlayingFieldStatus.O;
            Assert.Equal(WpfLibrary.Contexts.ApplicationContext.WinnerText, "Победил НОЛИК");
        }
        [Fact]
        public void Test3()
        {
            WpfLibrary.Contexts.ApplicationContext.Winner = PlayingFieldStatus.Empty;
            Assert.Equal(WpfLibrary.Contexts.ApplicationContext.WinnerText, "НИЧЬЯ");
        }
    }
}