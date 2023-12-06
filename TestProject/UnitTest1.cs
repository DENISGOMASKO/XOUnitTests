using WpfLibrary.Core;

namespace TestProject
{
    public class UnitTest1
    {
        private List<PlayingFieldStatus> allPlayers = new List<PlayingFieldStatus>() { PlayingFieldStatus.X, PlayingFieldStatus.O };
        [Fact]
        public void Test1()
        {
            var str1 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str2 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str3 = new List<PlayingFieldStatus>() { PlayingFieldStatus.X,       PlayingFieldStatus.X,       PlayingFieldStatus.X        };
            var Status = new List<List<PlayingFieldStatus>>() { str1, str2, str3 };
            var result = WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
            Assert.Equal(result, PlayingFieldStatus.X);
        }
        [Fact]
        public void Test2()
        {
            var str1 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str2 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str3 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var Status = new List<List<PlayingFieldStatus>>() { str1, str2, str3 };
            var result = WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
            Assert.Equal(result, PlayingFieldStatus.Null);
        }
        [Fact]
        public void Test3()
        {
            var str1 = new List<PlayingFieldStatus>() { PlayingFieldStatus.X,       PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str2 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.X,       PlayingFieldStatus.Empty    };
            var str3 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty,   PlayingFieldStatus.O        };
            var Status = new List<List<PlayingFieldStatus>>() { str1, str2, str3 };
            var result = WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
            Assert.Equal(result, PlayingFieldStatus.Null);
        }
        [Fact]
        public void Test4()
        {
            var str1 = new List<PlayingFieldStatus>() { PlayingFieldStatus.O,       PlayingFieldStatus.O,       PlayingFieldStatus.X        };
            var str2 = new List<PlayingFieldStatus>() { PlayingFieldStatus.X,       PlayingFieldStatus.O,       PlayingFieldStatus.O        };
            var str3 = new List<PlayingFieldStatus>() { PlayingFieldStatus.X,       PlayingFieldStatus.X,       PlayingFieldStatus.O        };
            var Status = new List<List<PlayingFieldStatus>>() { str1, str2, str3 };
            var result = WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
            Assert.Equal(result, PlayingFieldStatus.Empty);
        }
        [Fact]
        public void Test5()
        {
            var str1 = new List<PlayingFieldStatus>() { PlayingFieldStatus.O,       PlayingFieldStatus.Empty,   PlayingFieldStatus.Empty    };
            var str2 = new List<PlayingFieldStatus>() { PlayingFieldStatus.Empty,   PlayingFieldStatus.O,       PlayingFieldStatus.Empty    };
            var str3 = new List<PlayingFieldStatus>() { PlayingFieldStatus.X,       PlayingFieldStatus.X,       PlayingFieldStatus.O        };
            var Status = new List<List<PlayingFieldStatus>>() { str1, str2, str3 };
            var result = WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
            Assert.Equal(result, PlayingFieldStatus.O);
        }
    }
}