using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_Trigonometria_Triangulos.Models;

namespace TP2_Trigonometria_Triangulos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Initializing the model on page load so that the view and form work correctly, avoiding errors
            return View(new TriangleModel());
        }

        // POST: Home/TriangleCalculator
        // Execution of the method when the user submits the form
        [HttpPost] // Responding to HTTP POST requests
        [ValidateAntiForgeryToken] // Protecting against cross-site request forgery (CSRF) attacks


        public ActionResult CalculateTriangle(TriangleModel triangle)
        {
            // 1. Validate the data entered

            // Validation of the DataAnnotations defined in TriangleModel (values ​​> 0)
            if (ModelState.IsValid) // False if any of these validations fail
            {
                // Validation of the Triangular Inequality: "La suma de los dos valores menores debe ser mayor que el tercer valor."
                // If the sum of the two shorter sides is not greater than or equal to the longest side, a triangle is not formed
                if (triangle.A + triangle.B <= triangle.C || triangle.A + triangle.C <= triangle.B || triangle.B + triangle.C <= triangle.A)
                {
                    ModelState.AddModelError("", "The sum of the two shorter sides must be greater than the third side (triangular inequality).");
                    return View("Index", triangle);
                }
            }
            else
            {
                // If the model state is invalid, we return the view with the current model to show validation errors
                return View("Index", triangle);
            }


            // °°°°° If the validations are successful, we proceed to calculate the properties of the triangle °°°°°


            // 2. Calculate the Perimeter, the Semiperimeter, the Area and indicate the Type

            // - Perimeter (P): P = a + b + c 
            triangle.Perimetro = triangle.A + triangle.B + triangle.C;

            // - Semiperimeter (S): S = P / 2 
            triangle.Semiperimetro = triangle.Perimetro / 2;

            // - Area (A) using Heron's formula: A = √[S(S - a)(S - b)(S - c)]
            double s = triangle.Semiperimetro;
            triangle.Area = Math.Sqrt(s * (s - triangle.A) * (s - triangle.B) * (s - triangle.C));

            // - Determine the type of triangle based on the values ​​of its sides
            if (triangle.A == triangle.B && triangle.B == triangle.C)
            {
                triangle.TipoTriangulo = "Equilátero"; // Equal sides
            }
            else if (triangle.A == triangle.B || triangle.A == triangle.C || triangle.B == triangle.C)
            {
                triangle.TipoTriangulo = "Isósceles"; // Two equal sides 
            }
            else
            {
                triangle.TipoTriangulo = "Escaleno"; // Different sides
            }


            // °°°°° Now we proceed to calculate the angles of the triangle if the validation was successful °°°°°


            // 3. Calculate the angles

            // Ley de Cosenos: cos(ángulo) = (lado1^2 + lado2^2 - ladoOpuesto^2) / (2 * lado1 * lado2) 
            // a² = b² + c² - 2bc * cos(A)

            try
            {
                // Ángulo Alfa (α): Opposite side a and formed by sides b and c
                double cosAlfa = (Math.Pow(triangle.B, 2) + Math.Pow(triangle.C, 2) - Math.Pow(triangle.A, 2)) / (2 * triangle.B * triangle.C);
                // Ángulo Beta (β): Opposite side b and formed by sides a and c 
                double cosBeta = (Math.Pow(triangle.A, 2) + Math.Pow(triangle.C, 2) - Math.Pow(triangle.B, 2)) / (2 * triangle.A * triangle.C);
                // Ángulo Gamma (γ): Opposite side c and formed by sides a and b
                double cosGamma = (Math.Pow(triangle.A, 2) + Math.Pow(triangle.B, 2) - Math.Pow(triangle.C, 2)) / (2 * triangle.A * triangle.B);

                // Math.Acos returns the angle in radians and converts it to degrees
                triangle.AnguloAlfa = (cosAlfa >= -1 && cosAlfa <= 1) ? Math.Acos(cosAlfa) * (180 / Math.PI) : 0.0;
                triangle.AnguloBeta = (cosBeta >= -1 && cosBeta <= 1) ? Math.Acos(cosBeta) * (180 / Math.PI) : 0.0;
                triangle.AnguloGamma = (cosGamma >= -1 && cosGamma <= 1) ? Math.Acos(cosGamma) * (180 / Math.PI) : 0.0;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error in angle calculation: " + ex.Message);
            }

            // Returns the 'Index' view with the updated model, including the calculated results
            return View("Index", triangle);
        }
    }
}