using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLibrary.Contexts;
using WpfApp.Core;
using WpfLibrary.Core;

namespace WpfApp.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PlayingField.xaml
    /// </summary>
    public partial class PlayingField : UserControl
    {
        public PlayingField()
        {
            InitializeComponent();
            Status = PlayingFieldStatus.Empty;
            _changedPlayingFieldStatus = ApplicationContext.ChangedXO;
            _enemyFieldStatus = ApplicationContext.EnemyXO;
        }

        private PlayingFieldStatus _changedPlayingFieldStatus;
        private PlayingFieldStatus _enemyFieldStatus;
        private static void StatusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlayingField playingField)
            {      
                switch (playingField.Status)
                {
                    case PlayingFieldStatus.X:
                        playingField.Field.Content = "X";
                        break;
                    case PlayingFieldStatus.O:
                        playingField.Field.Content = "O";
                        break;
                    default:
                        playingField.Field.Content = "";
                        break;
                }
            }       
        }
        public PlayingFieldStatus Status
        {
            get
            {
                return (PlayingFieldStatus)GetValue(StatusProperty);
            }
            set
            {

                SetValue(StatusProperty, value);
            }
        }

        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(PlayingFieldStatus), typeof(PlayingField),
                new FrameworkPropertyMetadata(PlayingFieldStatus.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    StatusPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));



        private void Field_Click(object sender, RoutedEventArgs e)
        {            
            Status = _changedPlayingFieldStatus;
            OnPressCommand?.Execute(CommandParameter);
        }

        private void UpdateOnPressCommand()
        {
            //Trace.WriteLine("CommandChanged");
        }

        private static void OnPressCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlayingField playingField)
            {
                playingField.UpdateOnPressCommand();
            }
        }

        public ICommand OnPressCommand
        {
            get { return (ICommand)GetValue(OnPressCommandProperty); }
            set { SetValue(OnPressCommandProperty, value); }
        }

        public static readonly DependencyProperty OnPressCommandProperty =
            DependencyProperty.Register("OnPressCommand", typeof(ICommand), typeof(PlayingField),
                new FrameworkPropertyMetadata(new ActionCommand(() => { }), FrameworkPropertyMetadataOptions.Journal,
                    OnPressCommandPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

        

        public object CommandParameter
        {
            get { return (ICommand)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(PlayingField), new PropertyMetadata());


        private void UpdateReadOnly()
        {
            Field.IsEnabled = !ReadOnly;
        }

        private static void ReadOnlyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlayingField playingField)
            {
                playingField.UpdateReadOnly();
            }
        }

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty) || (Status != PlayingFieldStatus.Empty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(PlayingField),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal,
                    ReadOnlyPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

    }
}
