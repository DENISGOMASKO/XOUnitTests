using WpfApp.Core;

namespace GameLogic
{
    public class WinLogic
    {
        public PlayingFieldStatus gameIsEnd()
        {
            bool isEnd = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Status[i][j] == PlayingFieldStatus.Empty)
                        isEnd = false;

            foreach (PlayingFieldStatus player in allPlayers)
            {
                // Проверяем строки
                for (int row = 0; row < 3; row++)
                {
                    if (Status[row][0] == player && Status[row][1] == player && Status[row][2] == player)
                    {
                        return player;
                    }
                }

                // Проверяем столбцы
                for (int col = 0; col < 3; col++)
                {
                    if (Status[0][col] == player && Status[1][col] == player && Status[2][col] == player)
                    {
                        return player;
                    }
                }

                // Проверяем диагонали
                if (Status[0][0] == player && Status[1][1] == player && Status[2][2] == player)
                {
                    return player;
                }

                if (Status[0][2] == player && Status[1][1] == player && Status[2][0] == player)
                {
                    return player;
                }
            }
            if (isEnd)
            {
                return PlayingFieldStatus.Empty;
            }
            return PlayingFieldStatus.Null;
        }
    }
}