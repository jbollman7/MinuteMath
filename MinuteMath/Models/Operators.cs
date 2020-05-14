using System;
using System.Collections.Generic;

namespace MinuteMath.Models
{
    public enum OperatorsList
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class Operators
    {
        public int OperandX { get; private set; }
        public int OperandY { get; private set; }
        public OperatorsList Operator { get; private set; }
        public string OperatorSymbol { get; private set; }
        public int ExpressionSolution { get; private set; }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int Multiplication(int x, int y)
        {
            return x * y;
        }

        public static int Division(int x, int y)
        {
            return x / y;
        }


        private OperatorsList GetOperator()
        {
            var values = Enum.GetValues(typeof(OperatorsList));
            var random = new Random();
            var randomOperator = (OperatorsList) values.GetValue(random.Next(values.Length));
            Operator = randomOperator;
            return randomOperator;
        }

        public void GetOperands()
        {
            var operatorSelection = GetOperator();

            switch (operatorSelection)
            {
                case OperatorsList.Addition:
                    AdditionOperandRange();
                    IsItAInt();
                    break;
                case OperatorsList.Subtraction:
                    SubtractionOperandRange();
                    IsItAInt();
                    break;
                case OperatorsList.Multiplication:
                    MultiplicationOperandRange();
                    IsItAInt();
                    break;
                case OperatorsList.Division:
                    DivisionOperandRange();
                    while (!IsItAInt()) DivisionOperandRange();
                    break;
            }
        }

        private void AdditionOperandRange()
        {
            var random = new Random();
            OperandX = random.Next(0, 50);
            OperandY = random.Next(0, 50);
        }

        public void SubtractionOperandRange()
        {
            var random = new Random();
            OperandX = random.Next(25, 50);
            OperandY = random.Next(0, 25);
        }

        private void MultiplicationOperandRange()
        {
            var random = new Random();
            OperandX = random.Next(1, 11);
            OperandY = random.Next(1, 11);
        }

        private void DivisionOperandRange()
        {
            var random = new Random();
            OperandX = random.Next(1, 100);
            OperandY = random.Next(1, 12);
        }

        private bool IsItAInt()
        {
            switch (Operator)
            {
                case OperatorsList.Addition:
                    ExpressionSolution = Add(OperandX, OperandY);
                    break;

                case OperatorsList.Subtraction:
                    ExpressionSolution = Subtract(OperandX, OperandY);
                    break;

                case OperatorsList.Multiplication:
                    ExpressionSolution = Multiplication(OperandX, OperandY);
                    break;

                case OperatorsList.Division:
                    if (OperandX % OperandY != 0) return false;
                    ExpressionSolution = Division(OperandX, OperandY);
                    return true;
            }

            return true;
        }

        public List<int> ChoiceGenerator()
        {
            var choices = new List<int>
            {
                ExpressionSolution + 2,
                ExpressionSolution,
                ExpressionSolution + 3,
                ExpressionSolution - 1,
                ExpressionSolution - 2,
                ExpressionSolution + 1
            };
            return choices;
        }

        public List<T> Shuffle<T>(List<T> list)
        {
            var rnd = new Random();
            for (var i = 0; i < list.Count; i++)
            {
                var k = rnd.Next(0, i);
                var value = list[k];
                list[k] = list[i];
                list[i] = value;
            }

            return list;
        }

        public string ConvertOperatorToSymbol()
        {
            switch (Operator)
            {
                case OperatorsList.Addition:
                    return OperatorSymbol = "+";

                case OperatorsList.Subtraction:
                    return OperatorSymbol = "-";

                case OperatorsList.Multiplication:
                    return OperatorSymbol = "*";

                case OperatorsList.Division:
                    return OperatorSymbol = "/";


                default:
                    return OperatorSymbol = "Error, could not convert Operator enum to symbol";
            }
        }
    }
}