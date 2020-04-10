using System.ComponentModel;
using MinuteMath.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using System;

namespace MinuteMath.ViewModels
{
    public class GameLogicViewModel : INotifyPropertyChanged
    {

        Operators operators;
        List<int> shuffledUpChoices;
        Stopwatch gameStopWatch;
        string sGameTimer;
        int gameTimer = 59;
        string timer;

        public GameLogicViewModel()
        {
            this.operators = new Operators();
            initialize();


            CalculateCommand = new Command<string>(EvaluateUserChoice);

            // calculate Command, pass in command parameter to see what button was selected. less repeated code logic.
            /*
            CalculateCommand = new Command(() =>
            {
                if (RedChoice == operators.ExpressionSolution)
                {
                    Score += 1;
                    initialize();
                }
                   
                else
                {
                    Score -= 1;
                    initialize();
                }
                   
            });
            */
        }

        private void initialize()
        {
            GetNumbers();

            RedChoice = shuffledUpChoices[0];
            OrangeChoice = shuffledUpChoices[1];
            YellowChoice = shuffledUpChoices[2];
            GreenChoice = shuffledUpChoices[3];
            BlueChoice = shuffledUpChoices[4];
            IndigoChoice = shuffledUpChoices[5];
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
            gameStopWatch = new Stopwatch();
            gameStopWatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                sGameTimer = (gameTimer - gameStopWatch.Elapsed.Seconds).ToString();
                Timer = sGameTimer;
                //Timer = sixtyStopWatch.Elapsed.Seconds.ToString();
                if (gameTimer - gameStopWatch.Elapsed.Seconds > 0)
                    return true;
                else
                    return false;
            });
            
        }
        public string Timer
        {
            // get => timer;
            get { return sGameTimer; }
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
            get { return score; }
            set
            {
                score = value;
                var args = new PropertyChangedEventArgs(nameof(Score));
                PropertyChanged?.Invoke(this, args);

            } 
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
            this.shuffledUpChoices = operators.Shuffle(operators.ChoiceGenerator());
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
        


        public int redChoice;

        public int RedChoice
        {
            get { return redChoice; }
            set
            {
                redChoice = value;
                var args = new PropertyChangedEventArgs(nameof(RedChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int orangeChoice;

        public int OrangeChoice
        {
            get { return orangeChoice; }
            set
            {
                orangeChoice = value;
                var args = new PropertyChangedEventArgs(nameof(OrangeChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public int yellowChoice;

        public int YellowChoice
        {
            get { return yellowChoice; }
            set
            {
                yellowChoice = value;
                var args = new PropertyChangedEventArgs(nameof(YellowChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public int greenChoice;

        public int GreenChoice
        {
            get { return greenChoice; }
            set
            {
                greenChoice = value;
                var args = new PropertyChangedEventArgs(nameof(GreenChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public int blueChoice;

        public int BlueChoice
        {
            get { return blueChoice; }
            set
            {
                blueChoice = value;
                var args = new PropertyChangedEventArgs(nameof(BlueChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public int indigoChoice;

        public int IndigoChoice
        {
            get { return indigoChoice; }
            set
            {
                indigoChoice = value;
                var args = new PropertyChangedEventArgs(nameof(IndigoChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        //public Command RedCommand { get; }

    }
}
