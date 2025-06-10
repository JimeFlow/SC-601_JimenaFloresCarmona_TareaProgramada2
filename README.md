# **Tarea Programada 2 - Calculadora de Triángulos en ASP.NET MVC**

## **Universidad Fidélitas**  
**Curso:** SC-601 - Programación Avanzada 

**Profesor:** Rojas Matey, Luis Andrés 
**Estudiante FH23014559:** Flores Carmona, Jimena 

**Laboratorio:** M (6PM - 9PM) 
**Grupo:** No. 9 
**Cuatrimestre:** II - 2025  

**Fecha de Entrega:** Miércoles 11 de junio 2025, 6pm

---

## Introducción

El presente proyecto forma parte de la **Tarea Programada 2** del curso de **Programación Avanzada (SC-701)**. Se ha desarrollado una **aplicación web interactiva** utilizando **ASP.NET MVC** sobre **.NET Framework 4.8.1**, permitiendo calcular diversas propiedades de un triángulo basándose en sus **longitudes y ángulos**.  

---

## Especificaciones Funcionales Implementadas

La aplicación se ejecuta en un entorno web, accesible desde cualquier navegador. Se adhiere estrictamente a las siguientes especificaciones funcionales:

* **Formulario de Entrada de Datos:**
    * La interfaz inicial presenta un formulario que permite al usuario ingresar tres valores numéricos, los cuales representan las longitudes de los lados `a`, `b` y `c` de un triángulo.
    * Cada campo de entrada está claramente identificado con su etiqueta correspondiente (`a`, `b`, `c`).
    * Un botón de `submit` ("Calcular") habilita el envío de la información al servidor mediante una solicitud HTTP POST.

* **Proceso de Cálculo:** Una vez que el usuario activa el botón de `submit`, el sistema ejecuta los siguientes pasos en el orden especificado:

    *  **Validación de Datos Introducidos:**
        * **Validación de Rango:** Se verifica que las longitudes de los lados `a`, `b` y `c` sean valores numéricos válidos y estrictamente mayores que cero. Esta validación se implementa utilizando `DataAnnotations` en el modelo y se refuerza con validación del lado del servidor.
        * **Validación de Desigualdad Triangular:** Se comprueba que la suma de las longitudes de los dos lados más cortos sea estrictamente mayor que la longitud del lado más largo. Si esta condición no se cumple, se considera que los lados no pueden formar un triángulo válido.
        * En caso de que alguna de estas validaciones falle, se mostrarán mensajes de error claros y concisos al usuario en la misma página del formulario, sin procesar los cálculos.

    *  **Cálculo de Propiedades del Triángulo:** Si todos los datos son válidos y forman un triángulo, se calculan las siguientes propiedades:
        * **Perímetro (P):** La suma de las longitudes de los tres lados: $P = a + b + c$. El resultado se expresa en unidades lineales (u).
        * **Semiperímetro (S):** La mitad del perímetro: $S = P / 2$. El resultado se expresa en unidades lineales (u).
        * **Área (A):** Calculada mediante la fórmula de Herón: $A = \sqrt{S(S-a)(S-b)(S-c)}$. El resultado se expresa en unidades cuadráticas (u²).
        * **Tipo de Triángulo:** El triángulo se clasifica e indica como:
            * **Equilátero:** Si los tres lados son de igual longitud.
            * **Isósceles:** Si exactamente dos lados son de igual longitud.
            * **Escaleno:** Si los tres lados tienen longitudes diferentes.

    *  **Cálculo de los Ángulos Internos:** Se calculan los valores de los tres ángulos internos del triángulo utilizando la Ley de Cosenos:
        * Ángulo $\alpha$ (opuesto al lado $a$): $\cos \alpha = \frac{b^2 + c^2 - a^2}{2bc}$
        * Ángulo $\beta$ (opuesto al lado $b$): $\cos \beta = \frac{a^2 + c^2 - b^2}{2ac}$
        * Ángulo $\gamma$ (opuesto al lado $c$): $\cos \gamma = \frac{a^2 + b^2 - c^2}{2ab}$
        Los resultados de los ángulos se presentan en grados ($^\circ$), no en radianes.

    ### 📏 Fórmulas Matemáticas
    1.  **Perímetro (P)**  
       \[
       P = a + b + c
       \]
     2.  **Semiperímetro (S)**  
       \[
       S = \frac{P}{2}
       \]
     3. **Área (A)** usando **Herón**  
       \[
       A = \sqrt{S (S-a) (S-b) (S-c)}
       \]
     4. **Cálculo de Ángulos** usando la **Ley de Cosenos**  
       \[
       \cos(\alpha) = \frac{b^2 + c^2 - a^2}{2bc}
       \]

---

## Especificaciones Técnicas

* **Lenguaje de Programación:** C#
* **Arquitectura:** ASP.NET MVC
* **Framework de Desarrollo:** .NET Framework 4.8.1
* **Entorno de Desarrollo Integrado (IDE):** Visual Studio Community 2022.
* **Clase Utilizada:** Se hace uso extensivo de la clase `System.Math` del .NET Framework para todas las operaciones matemáticas y trigonométricas, incluyendo `Math.Sqrt()`, `Math.Pow()`, `Math.Acos()`, y la constante `Math.PI`.
* **Estructura del Proyecto:** El proyecto está organizado dentro de una solución única (`.sln`), con el proyecto principal incluido y estructurado según el patrón MVC (Modelos, Vistas, Controladores).

---

## 📚 **Recursos de Apoyo y Referencias**
### Repositorio del proyecto: 
**Jimena Flores Carmona - FH23014559** 
* Link: https://github.com/JimeFlow/SC-601_JimenaFloresCarmona_TareaProgramada2.git
 
### Referencias y documentación
  1. Se exploro la mayoría de la información colocando en el buscador "Triangle Calculator Length and Angles in Visual Studio 2022 C#" o términos relacionados, además de los enlaces proporcionados en las instrucciones de la Tarea 2.
  2. "Propiedades de triángulos y trigonometría: suma ángulos, relación lados y ángulos, Ley de Senos, Ley de Cosenos, tipos (equilátero, rectángulo, isósceles)." answer generated by Gemini in Google
  3. Markdown para hacer el README.md: https://www.markdownguide.org/getting-started/
  4. Guía Markdown: https://github.com/mattcone/markdown-guide/blob/master/README.md
  
### Prompts de las consultas a chatbots de IA: _Copilot_
# Proyecto: Triangle Calculator en ASP.NET MVC

## 📌 Descripción
Aplicación web creada en **ASP.NET MVC** que calcula el **perímetro, semiperímetro, área y ángulos** de un triángulo basado en los valores de sus lados. Se han realizado mejoras en la estructura, validaciones y diseño visual para optimizar la presentación de resultados.

## 🚀 Mejoras Implementadas
1️⃣ **Corrección de errores y eliminación de dependencias innecesarias.**  
2️⃣ **Validaciones mejoradas en `TriangleModel.cs`.**  
3️⃣ **Optimización de cálculos en `HomeController.cs`.**  
4️⃣ **Diseño mejorado en `Index.cshtml`:**  
   - Tablas compactas con **bordes visibles** y texto **centrado**.  
   - Separación adecuada entre bloques de resultados.  
   - **Botón de cálculo redondeado y en color verde claro.**  
5️⃣ **Implementación de `_Layout.cshtml`** como diseño global, vinculando `_ViewStart.cshtml`.  

## 🎨 Diseño Mejorado
✔ **Tablas más compactas sin perder bordes.**  
✔ **Separación visual entre resultados y ángulos.**  
✔ **Botón grande, redondeado y verde claro para mejor accesibilidad.**  
✔ **Nombre de la aplicación corregido en `_Layout.cshtml`.**  

## 📂 Estructura del Proyecto
├── Controllers
│   ├── HomeController.cs
├── Models
│   ├── TriangleModel.cs
├── Views
│   ├── Home
│   │   ├── Index.cshtml
│   ├── Shared
│   │   ├── _Layout.cshtml
│   │   ├── _ViewStart.cshtml
