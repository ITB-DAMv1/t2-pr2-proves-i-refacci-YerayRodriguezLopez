using System;
using GeometryApp;
using Xunit;

namespace GeometryApp.Tests
{
    public class ProgramTests
    {
        // Test per calcular l'àrea del rectangle
        [Fact]
        public void CalculateRectangleArea_ShouldReturnCorrectArea()
        {
            // Arrange
            double width = 5;
            double height = 10;

            // Act
            double result = Program.CalculateRectangleArea(width, height);

            // Assert
            Assert.Equal(50, result); // L'àrea d'un rectangle de 5x10 ha de ser 50
        }

        // Test per calcular la circumferència del cercle
        [Fact]
        public void CalculateCircleCircumference_ShouldReturnCorrectCircumference()
        {
            // Arrange
            double radius = 7;

            // Act
            double result = Program.CalculateCircleCircumference(radius);

            // Assert
            Assert.Equal(2 * Math.PI * radius, result, 5); // El resultat ha de ser aproximadament 43.9823
        }

        // Test per a DisplayAreaEvaluation (cal comprobar els missatges)
        [Theory]
        [InlineData(60, "L'àrea és més gran de 50")]
        [InlineData(30, "L'àrea és entre 20 i 50")]
        [InlineData(10, "L'àrea és menor o igual a 20")]
        public void DisplayAreaEvaluation_ShouldPrintCorrectMessage(double area, string expectedMessage)
        {
            // Arrange
            // Per a aquest test, no podem capturar directament la sortida de la consola,
            // així que haurem d'utilitzar un mètode per capturar la sortida de la consola

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.DisplayAreaEvaluation(area);

                // Assert
                string output = sw.ToString().Trim(); // Capturem la sortida de la consola
                Assert.Equal(expectedMessage, output); // Verifiquem que es mostra el missatge esperat
            }
        }

        // Test per validar l'entrada
        [Theory]
        [InlineData("5", 5)]  // Test amb un valor vàlid
        [InlineData("10", 10)] // Test amb un altre valor vàlid
        public void GetDouble_ShouldReturnValidNumber(string input, double expected)
        {
            // Per aquest test, hauries de fer un mètode per injectar l'entrada
            // L'entrada normalment es fa amb la consola, però és difícil testejar-la directament
            // Així que aquest test només s'ha de referir a lògica específica per a GetDouble
        }
    }
}
