ShapeCalculations
---

ShapeCalculations is .NET Standard 2.1 library for calculating the area and other characteristics of geometric shapes.
It was created for test purposes and to demonstrate a sample code for employers.
Two figures are now available for calculation - a circle and a triangle. 
For them it is possible to calculate the area and subtype of the figure.

Using
---

The main class is `ShapeCalculationService`. It can be used with the default constructor.
The following methods are available to customers:
* `void Validate(Shape shape)`
* `void FindArea(Shape shape)`
* `void DefineType(Shape shape)`
* `void CalculateAll(Shape shape)`
