using BenchmarkDotNet.Attributes;
using SwitchVsIfElsePerformanceTests.Models;

namespace SwitchVsIfElsePerformanceTests.BenchmarkTests;

public class PatternMatchingVsComplexIfElseBenchmarkTests
{
    private object[] _shapes = {
        new Circle { Radius = 12 },
        new Circle { Radius = 4 },
        new Rectangle { Width = 4, Height = 4 },
        new Rectangle { Width = 4, Height = 10 },
        new Line { Length = 10 },
    };
    
    [Params(1000)]
    public int N;
    
    [Benchmark]
    public void IfElseWithComplexConditions()
    {
        string shapeName;
        
        foreach (object shape in _shapes)
        {
            shapeName = ClassifyShapeWithIfElse(shape);
        }
    }

    [Benchmark]
    public void SwitchExpressionWithPatternMatching()
    {
        string shapeName;
        
        foreach (object shape in _shapes)
        {
            shapeName = ClassifyShapeWithPatternMathing(shape);
        }
    }

    private string ClassifyShapeWithIfElse(object shape)
    {
        if (shape is Circle)
        {
            if (((Circle)shape).Radius > 10)
            {
                return "Large Circle";
            }

            return "Circle";
        }
        if (shape is Rectangle)
        {
            var rectangle = shape as Rectangle;
            
            if (rectangle.Height == rectangle.Width)
            {
                return "Square";
            }

            return "Rectangle";
        }

        return "Unknown Shape";
    }
    
    
    private string ClassifyShapeWithPatternMathing(object shape) => 
        shape switch
        {
            Circle { Radius: > 10 } => "Large Circle",
            Circle => "Circle",
            Rectangle { Width: var w, Height: var h } when w == h => "Square",
            Rectangle => "Rectangle",
            _ => "Unknown Shape"
        };
}