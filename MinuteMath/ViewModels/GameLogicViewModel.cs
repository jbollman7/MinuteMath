using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using MinuteMath.Models;
using MinuteMath.Pages;
using Plugin.SimpleAudioPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MinuteMath.ViewModels
{
    public class GameLogicViewModel : INotifyPropertyChanged
    {
        private readonly ISimpleAudioPlayer correctDing;
        private readonly Stopwatch gameStopWatch;
        private readonly int gameTimer = 59;
        private readonly ISimpleAudioPlayer incorrectQuack;

        private readonly Operators operators;
        private int _blueChoice;
        private int _greenChoice;
        private int _indigoChoice;

        private int _orangeChoice;

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
        private string _sGameTimer;
        private List<int> _shuffledUpChoices;
        private int _yellowChoice;

        public int operandX;

        public int operandY;

        public string operatorSymbol;

        public int score;
        private string timer;


        public GameLogicViewModel()
        {
            resetScore();
            operators = new Operators();
            initialize();
            gameStopWatch = new Stopwatch();
            gameStopWatch.Start();


            CalculateCommand = new Command<string>(EvaluateUserChoice);

            var correctAssembly = typeof(App).GetTypeInfo().Assembly;
            var inCorrectAssembly = typeof(App).GetTypeInfo().Assembly;

            var correctAudioStream = correctAssembly.GetManifestResourceStream("MinuteMath.DingSound.wav");
            correctDing = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            correctDing.Load(correctAudioStream);


            var incorrectAudioStream = correctAssembly.GetManifestResourceStream("MinuteMath.duck.wav");
            incorrectQuack = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            incorrectQuack.Load(incorrectAudioStream);
        }

        public Command CalculateCommand { get; }

        public string Timer
        {
            // get => timer;
            get => _sGameTimer;
            set
            {
                timer = value;
                var args = new PropertyChangedEventArgs(nameof(Timer));
                PropertyChanged?.Invoke(this, args);
            }
        }

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

        public int OperandX
        {
            get => operandX;
            set
            {
                operandX = value;
                var args = new PropertyChangedEventArgs(nameof(OperandX));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int OperandY
        {
            get => operandY;
            set
            {
                operandY = value;
                var args = new PropertyChangedEventArgs(nameof(OperandY));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string OperatorSymbol
        {
            get => operatorSymbol;
            set
            {
                operatorSymbol = value;
                var args = new PropertyChangedEventArgs(nameof(OperatorSymbol));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int RedChoice
        {
            get => _redChoice;
            set
            {
                _redChoice = value;
                var args = new PropertyChangedEventArgs(nameof(RedChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int OrangeChoice
        {
            get => _orangeChoice;
            set
            {
                _orangeChoice = value;
                var args = new PropertyChangedEventArgs(nameof(OrangeChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int YellowChoice
        {
            get => _yellowChoice;
            set
            {
                _yellowChoice = value;
                var args = new PropertyChangedEventArgs(nameof(YellowChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int GreenChoice
        {
            get => _greenChoice;
            set
            {
                _greenChoice = value;
                var args = new PropertyChangedEventArgs(nameof(GreenChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int BlueChoice
        {
            get => _blueChoice;
            set
            {
                _blueChoice = value;
                var args = new PropertyChangedEventArgs(nameof(BlueChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int IndigoChoice
        {
            get => _indigoChoice;
            set
            {
                _indigoChoice = value;
                var args = new PropertyChangedEventArgs(nameof(IndigoChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void resetScore()
        {
            var scoreKey = Preferences.ContainsKey(nameof(Score));
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
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
                case "Orange":
                    if (OrangeChoice == operators.ExpressionSolution)
                    {
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
                case "Yellow":
                    if (YellowChoice == operators.ExpressionSolution)
                    {
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
                case "Green":
                    if (GreenChoice == operators.ExpressionSolution)
                    {
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
                case "Blue":
                    if (BlueChoice == operators.ExpressionSolution)
                    {
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
                case "Indigo":
                    if (IndigoChoice == operators.ExpressionSolution)
                    {
                        correctDing.Play();
                        Score += 1;
                        initialize();
                        break;
                    }
                    else
                    {
                        incorrectQuack.Play();
                        Score -= 1;
                        break;
                    }
            }
        }


        public void GameTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                _sGameTimer = (gameTimer - gameStopWatch.Elapsed.Seconds).ToString();
                Timer = _sGameTimer;
                //Timer = sixtyStopWatch.Elapsed.Seconds.ToString();
                if (gameTimer - gameStopWatch.Elapsed.Seconds > 0) return true;

                CompareScores();
                Application.Current.MainPage = new NavigationPage(new EndPage());
                return false;
                // Code for end screen
            });
        }

        public void CompareScores()
        {
            if (Score > HighScore)
                HighScore = Score;
        }

        public void GetNumbers()
        {
            operators.GetOperands();
            _shuffledUpChoices = operators.Shuffle(operators.ChoiceGenerator());
            operators.ConvertOperatorToSymbol();
        }
    }
}