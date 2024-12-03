using System;

namespace GeometryApp
{
    public class Program
    {
        // Constants per a literals utilitzats en el codi
        const string RectangleWidthPrompt = "Introdueix l'amplada del rectangle:";
        const string RectangleHeightPrompt = "Introdueix l'altura del rectangle:";
        const string CircleRadiusPrompt = "Introdueix el radi del cercle:";
        const string AreaGreaterThan50Message = "L'àrea és més gran de 50";
        const string AreaBetween20And50Message = "L'àrea és entre 20 i 50";
        const string AreaLessOrEqualTo20Message = "L'àrea és menor o igual a 20";
        const string RectangleAreaMessage = "L'àrea del rectangle és: ";
        const string CircleCircumferenceMessage = "La circumferència del cercle és: ";
        const string InvalidNumberErrorMessage = "Error: L'entrada no és un número vàlid. Torna-ho a intentar.";
        const string OverflowErrorMessage = "Error: El número és massa gran o massa petit. Torna-ho a intentar.";
        const string UnexpectedErrorMessage = "Error inesperat: ";
        const double CircleMultiplier = 2.0;
        const double Pi = Math.PI; // Valor constant de π
        const double AreaThreshold1 = 50.0;
        const double AreaThreshold2 = 20.0;

        public static void Main(string[] args)
        {
            // Calcula l'àrea d'un rectangle
            double rectangleArea = CalculateRectangleArea();
            Console.WriteLine(RectangleAreaMessage + rectangleArea);

            // Calcula la circumferència d'un cercle
            double circleCircumference = CalculateCircleCircumference();
            Console.WriteLine(CircleCircumferenceMessage + circleCircumference);

            // Mostra un missatge segons l'àrea
            DisplayAreaEvaluation(rectangleArea);
        }

        public static double GetDouble(string prompt)
        {
            bool flag = false;
            double value = 0;
            while (flag)
            {
                try
                {
                    Console.WriteLine(prompt);
                    value = Convert.ToDouble(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine(InvalidNumberErrorMessage);
                }
                catch (OverflowException)
                {
                    Console.WriteLine(OverflowErrorMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(UnexpectedErrorMessage + ex.Message);
                }
            }
            return value;
        }

        public static double CalculateRectangleArea()
        {
            double rectangleWidth = GetDouble(RectangleWidthPrompt);
            double rectangleHeight = GetDouble(RectangleHeightPrompt);
            return rectangleWidth * rectangleHeight;
        }

        public static double CalculateCircleCircumference()
        {
            double circleRadius = GetDouble(CircleRadiusPrompt);
            return CircleMultiplier * Pi * circleRadius;
        }

        public static void DisplayAreaEvaluation(double rectangleArea)
        {
            if (rectangleArea > AreaThreshold1)
            {
                Console.WriteLine(AreaGreaterThan50Message);
            }
            else if (rectangleArea > AreaThreshold2)
            {
                Console.WriteLine(AreaBetween20And50Message);
            }
            else
            {
                Console.WriteLine(AreaLessOrEqualTo20Message);
            }
        }
    }
}
