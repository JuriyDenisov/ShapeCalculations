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

`Shape` is abstract class. The real objects can be `Circle` or `Triangle`.
To calculate the shape, the dimensions must be specified — the radius of the circle and the sides of the triangle.
If an incorrect model is passed to any of the methods, an exception will be thrown.

After calculation, the model of the figure is enriched with the calculated value.

**Additional features:**

It is possible to use the `ShapeCreator` class to create a particular class of shape by transferring only one or more its sizes.
Method signature:
```
Shape GetShape(params double[] shapeSizes)
```
The resulting figure can be transferred for calculation to the class `ShapeCalculationService`.
