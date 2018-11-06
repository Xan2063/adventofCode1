using System.Collections.Generic;
using _1;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using NUnit.Framework;

[TestFixture]
public class Test{

    [Test]
    public void Decompose_ShouldReturn(){
        (int length, Angle directionChange) = Program.Decompose("L5");
        Assert.That(length, Is.EqualTo(5));

        
        Assert.That(directionChange, Is.EqualTo(90));
    }

    [Test]
    public void Decompose_ShouldReturnRight4(){
        (int length, Angle directionChange) = Program.Decompose("R4");
        Assert.That(length, Is.EqualTo(4));
  
        
        Assert.That(directionChange, Is.EqualTo(-90));
    }

    [Test]
    public void upShouldGetRight(){
        var vector = new Vector2D(0,1);
        var matrix = Program.createTurnRight();
        var result = vector.TransformBy(matrix);
        Assert.That(result, Is.EqualTo(new Vector2D(1,0)));
    }

    [Test]
    public void Test2(){
        var set = new List<Vector2D>();
        set.Add(new Vector2D(1,2));
        var result = set.Contains(new Vector2D(1,2));
    }
}