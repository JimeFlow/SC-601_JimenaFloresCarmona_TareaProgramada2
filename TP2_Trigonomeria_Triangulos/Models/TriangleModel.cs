using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP2_Trigonometria_Triangulos.Models
{
    public class TriangleModel
    {
        [Required(ErrorMessage = "Side 'A' is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The 'A' side must be greater than zero.")] // Use 0.0001 to allow small decimals and enforce "greater than zero".
        public double A { get; set; }

        [Required(ErrorMessage = "Side 'B' is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The 'B' side must be greater than zero.")]
        public double B { get; set; }

        [Required(ErrorMessage = "Side 'C' is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The 'C' side must be greater than zero.")]
        public double C { get; set; }


        // Method to validate if the triangle is valid based on the triangle inequality theorem
        public bool IsTriangleValid()
        {
            return A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
        }

        // Properties for the results initialized to avoid null errors in future calculations
        public double Perimetro = 0.0;
        public double Semiperimetro = 0.0;
        public double Area = 0.0;
        public string TipoTriangulo = "Unknown";
        public double AnguloAlfa = 0.0; // In degrees
        public double AnguloBeta = 0.0; // In degrees
        public double AnguloGamma = 0.0; // In degrees
    }
}
