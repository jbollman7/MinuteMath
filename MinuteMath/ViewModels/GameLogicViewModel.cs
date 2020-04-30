using System.ComponentModel;
using MinuteMath.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;
using System;
using MinuteMath.Pages;
using System.Reflection;
using System.IO;
using Plugin.SimpleAudioPlayer;

namespace MinuteMath.ViewModels
{
    public class GameLogicViewModel : INotifyPropertyChanged
    {

        Operators operators;
        List<int> _shuffledUpChoices;
        Stopwatch gameStopWatch;
        string _sGameTimer;
        int gameTimer = 59;
        string timer;
       ISimpleAudioPlayer  player;
        

        public GameLogicViewModel()
        {
            resetScore();
            this.operators = new Operators();
            initialize();
            gameStopWatch = new Stopwatch();
            gameStopWatch.Start();


            CalculateCommand = new Command<string>(EvaluateUserChoice);

            var assembly = typeof(App).GetTypeInfo().Assembly;
            
            Stream audioStream = assembly.GetManifestResourceStream("MinuteMath.DingSound.wav");
            
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            player.Load(audioStream);

        }

        private void resetScore()
        {
            bool scoreKey = Preferences.ContainsKey(nameof(Score));
            if (scoreKey)
                Preferences.Remove(nameof(Score));
        }

        private void initialize()
        {
            GetNumbers();

            RedChoice = _shuffledUpChoices[0];
            OrangeChoice = _shuffledUpChoices[1];
            YellowChoice = _shuffledUpChoices[2];
            GreenChoice = _shuffledUpChoices[3];
            BlueChoice = _shuffledUpChoices[4];
            IndigoChoice = _shuffledUpChoices[5];
            OperandX = operators.OperandX;
            OperandY = operators.OperandY;
            OperatorSymbol = operators.OperatorSymbol;
            GameTimer();
        }

       public void EvaluateUserChoice(string choice)
        {
            switch (choice)
            {
                case "Red":
                    if (RedChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }
                case "Orange":
                    if (OrangeChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }
                case "Yellow":
                    if (YellowChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }
                case "Green":
                    if (GreenChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }
                case "Blue":
                    if (BlueChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }
                case "Indigo":
                    if (IndigoChoice == operators.ExpressionSolution)
                    {
                        player.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        Score -= 1;
                        break;
                    }

            }

        }

        public Command CalculateCommand { get;  }

       
        public void GameTimer()
        {
            
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                _sGameTimer = (gameTimer - gameStopWatch.Elapsed.Seconds).ToString();
                Timer = _sGameTimer;
                //Timer = sixtyStopWatch.Elapsed.Seconds.ToString();
                if (gameTimer - gameStopWatch.Elapsed.Seconds > 0)
                {
                    return true;
                }
                else
                {
                    CompareScores();
                    App.Current.MainPage = new NavigationPage(new EndPage());
                    return false;
                    // Code for end screen
                }

            });
            
        }
        public string Timer
        {
            // get => timer;
            get { return _sGameTimer; }
            set
            {
                timer = value;
                var args = new PropertyChangedEventArgs(nameof(Timer));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int score;
        public int Score
        {
            get => Preferences.Get(nameof(Score), 0);
            set
            {
                Preferences.Set(nameof(Score), value);
                var args = new PropertyChangedEventArgs(nameof(Score));
                PropertyChanged?.Invoke(this, args);

            } 
        }
        public int HighScore
        {
            get => Preferences.Get(nameof(HighScore), 0);
            set
            {
                 Preferences.Set(nameof(HighScore), value);
                 var args = new PropertyChangedEventArgs(nameof(HighScore));
                 PropertyChanged?.Invoke(this, args);
            }
        }
        public void CompareScores()
        {
            if (Score > HighScore)
                HighScore = Score;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public int operandX;

        public int OperandX
        {
            get { return operandX; }
            set
            {
                operandX = value;
                var args = new PropertyChangedEventArgs(nameof(OperandX));
                PropertyChanged?.Invoke(this,args);
            }
        }
        
        public int operandY;

        public int OperandY
        {
            get { return operandY; }
            set
            {
                operandY = value;
                var args = new PropertyChangedEventArgs(nameof(OperandY));
                PropertyChanged?.Invoke(this,args);
            }
        }

        public string operatorSymbol;

        public string OperatorSymbol
        {
            get { return operatorSymbol; }
            set
            {
                operatorSymbol = value;
                var args = new PropertyChangedEventArgs(nameof(OperatorSymbol));
                PropertyChanged?.Invoke(this,args);
            }
        }

        public void GetNumbers()
        {
            
            operators.GetOperands();
            this._shuffledUpChoices = operators.Shuffle(operators.ChoiceGenerator());
            operators.ConvertOperatorToSymbol();
        }

        /*
        public List<int> DisplayChoices()     
        {
            get => shuffledUpChoices;
            set
            {
                if (shuffledUpChoices != value)
                   shuffledUpChoices = value;

                var args = new PropertyChangedEventArgs(nameof(DisplayChoices)); //name of the method here.

                PropertyChanged?.Invoke(this, args);        //? is sugar to check if its null
            }
        }
        */
        


        private int _redChoice;

        public int RedChoice
        {
            get { return _redChoice; }
            set
            {
                _redChoice = value;
                var args = new PropertyChangedEventArgs(nameof(RedChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private int _orangeChoice;

        public int OrangeChoice
        {
            get { return _orangeChoice; }
            set
            {
                _orangeChoice = value;
                var args = new PropertyChangedEventArgs(nameof(OrangeChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        private int _yellowChoice;

        public int YellowChoice
        {
            get { return _yellowChoice; }
            set
            {
                _yellowChoice = value;
                var args = new PropertyChangedEventArgs(nameof(YellowChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        private int _greenChoice;

        public int GreenChoice
        {
            get { return _greenChoice; }
            set
            {
                _greenChoice = value;
                var args = new PropertyChangedEventArgs(nameof(GreenChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        private int _blueChoice;

        public int BlueChoice
        {
            get { return _blueChoice; }
            set
            {
                _blueChoice = value;
                var args = new PropertyChangedEventArgs(nameof(BlueChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        private int _indigoChoice;

        public int IndigoChoice
        {
            get { return _indigoChoice; }
            set
            {
                _indigoChoice = value;
                var args = new PropertyChangedEventArgs(nameof(IndigoChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        

    }
}
