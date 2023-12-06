using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Constants;
using WpfLibrary.Contexts;
using WpfApp.Core;
using WpfApp.View.Pages;
using WpfLibrary.Core;

namespace WpfApp.ViewModel
{
    internal class GamePageViewModel : BaseViewModel
    {
        private PlayingFieldStatus _changedPlayingFieldStatus;
        private static NavigationManager _navigationManager;
        List<PlayingFieldStatus> allPlayers = new List<PlayingFieldStatus> { PlayingFieldStatus.O, PlayingFieldStatus.X };
        Random rnd = new Random();
        Thread enemyTurnThread;
        public GamePageViewModel(NavigationManager navigationManager)
        {
            _changedPlayingFieldStatus = ApplicationContext.ChangedXO;
            _navigationManager = navigationManager;
            for (int i = 0; i < 3; i++)
            {
                var temp = new List<PlayingFieldStatus>();
                for (int j = 0; j < 3; j++)
                {
                    temp.Add(PlayingFieldStatus.Empty);
                }
                Status.Add(temp);
            }
            WhoseMove = PlayingFieldStatus.X;
            if (WhoseMove == ApplicationContext.EnemyXO)
                swichTurnToEnemy();
            ApplicationContext.IsGame = true;
        }

        private PlayingFieldStatus _whoseMove;
        public PlayingFieldStatus WhoseMove
        {
            get { return _whoseMove; }
            set { 
                _whoseMove = value; 
                OnPropertyChanged(); 
                OnPropertyChanged("IsNotPlayerTurn");

            }
        }

        private List<List<PlayingFieldStatus>> status = new List<List<PlayingFieldStatus>>();
        public List<List<PlayingFieldStatus>> Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

        private PlayingFieldStatus gameIsEnd()
        {
            return WpfLibrary.WinLogic.gameIsEnd(Status, allPlayers);
        }

        private void tryToEndGame()
        {
            var winner = gameIsEnd();
            ApplicationContext.Winner = winner;
            if (! allPlayers.Contains(winner) && winner != PlayingFieldStatus.Empty) return;         
            exit();
        }

        private async void swichTurnToEnemy()
        {
            tryToEndGame();
            WhoseMove = ApplicationContext.EnemyXO;
            await Task.Run(enemyTurn);
            tryToEndGame();
        }

        private void swichTurnToPlayer()
        {
            WhoseMove = ApplicationContext.ChangedXO;
        }

        private async Task enemyTurn()
        {
            try
            {
                int value = rnd.Next(800, 2000);
                Thread.Sleep(value);
                makeRandomTurn();
                swichTurnToPlayer();
                return;
            }
            catch (ThreadInterruptedException)
            {
                ;
            } 
        }

        private bool makeRandomTurn() 
        {
            int emptyCount = 0;
            (int, int) pos = (0, 0);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Status[i][j] == PlayingFieldStatus.Empty)
                    {
                        emptyCount += 1;
                        pos.Item1 = i;
                        pos.Item2 = j;
                    }
            if (emptyCount == 0)
                return false;
            else if (emptyCount == 1)
                makeTurnAsEnemy(pos.Item1, pos.Item2);

            while (true) {
                int i = rnd.Next(0, 3);
                int j = rnd.Next(0, 3);
                if (Status[i][j] == PlayingFieldStatus.Empty)
                {
                    makeTurnAsEnemy(i, j);
                    break;
                }
            }
            return true;
        }

        private void makeTurnAsEnemy(int i, int j)
        {
            Status[i][j] = ApplicationContext.EnemyXO;
            OnPropertyChanged("Status");  
        }

        private void exit()
        {
            if (ApplicationContext.IsGame == false) return;
            if (enemyTurnThread != null)
                enemyTurnThread.Interrupt();
            ApplicationContext.SetWindwoSize(500, 700);

            _navigationManager.Navigate(NavigationKeys.EndGamePage, new EndGamePage());


            ApplicationContext.IsGame = false;

        }


        public ActionCommand Exit
        {
            get
            {
                return new ActionCommand(exit);
            }
        }
        
        public bool IsNotPlayerTurn
        {
            get { return (_changedPlayingFieldStatus != _whoseMove); }
        }

        public ActionCommand PressCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    swichTurnToEnemy();
                });
            }
        }

    }
}
