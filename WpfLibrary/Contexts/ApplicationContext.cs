using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLibrary.Core;

namespace WpfLibrary.Contexts
{
    static public class ApplicationContext
    {
        static private PlayingFieldStatus _changedXO;
        static public PlayingFieldStatus ChangedXO
        {
            get { return _changedXO; }
            set { _changedXO = value; }
        }

        static public PlayingFieldStatus EnemyXO
        {
            get 
            {
                var _enemyXO = PlayingFieldStatus.Empty;
                switch (_changedXO)
                {
                    case PlayingFieldStatus.O:
                        _enemyXO = PlayingFieldStatus.X;
                        break;
                    case PlayingFieldStatus.X:
                        _enemyXO = PlayingFieldStatus.O;
                        break;
                }
                return _enemyXO; 
            }
        }

        static private Window _mWindow;
        static public Window MWindow
        {
            get { return _mWindow; }
            set { _mWindow = value; }
        }

        static public void SetWindwoSize(int heidht = 600, int width = 600)
        {
            _mWindow.Height = heidht;
            _mWindow.Width = width;
        }

        static public void SetWindwoSize(Window _mWindow, int heidht = 600, int width = 600)
        {
            _mWindow.Height = heidht;
            _mWindow.Width = width;
        }

        static private bool _isGame;
        static public bool IsGame
        {
            get { return _isGame; }
            set { _isGame = value; }
        }

        static private PlayingFieldStatus _winner;
        static public PlayingFieldStatus Winner
        {
            get { return _winner; }
            set { _winner = value; }
        }

        static public string WinnerText
        {
            get
            {
                string winnerText = "Победил ";
                switch (_winner)
                {
                    case PlayingFieldStatus.X:
                        winnerText = winnerText + "КРЕСТИК";
                        break;
                    case PlayingFieldStatus.O:
                        winnerText = winnerText + "НОЛИК";
                        break;
                    default:
                        winnerText = "НИЧЬЯ";
                        break;
                }

                return winnerText;
            }
        }
    }
}
