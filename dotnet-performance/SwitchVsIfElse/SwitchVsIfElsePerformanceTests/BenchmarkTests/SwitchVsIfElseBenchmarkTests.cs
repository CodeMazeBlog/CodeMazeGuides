using BenchmarkDotNet.Attributes;

namespace SwitchVsIfElsePerformanceTests.BenchmarkTests;

public class SwitchVsIfElseBenchmarkTests
{
    private readonly int _iterations;
    private readonly int[] _inputData;
    
    public SwitchVsIfElseBenchmarkTests()
    {
        _iterations = 1000;
        _inputData = new int[_iterations];
        
        for (int i = 0; i < _iterations; i++)
        {
            _inputData[i] = i % 10;
        }
    }

    [Benchmark]
    public void IfElseWithOneCondition()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            if (_inputData[i] == 1)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
        }
    }

    [Benchmark]
    public void SwitchWithOneCase()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            switch (_inputData[i])
            {
                case 1: 
                    result = 1;
                    break;
                default: 
                    result = -1;
                    break;
            }
        }
    }
    
    [Benchmark]
    public void SwitchExpressionWithOneCase()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            result = _inputData[i] switch
            {
                1 => 1,
                _ => -1
            };
        }
    }
    
    [Benchmark]
    public void IfElseWithTwoConditions()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            if (_inputData[i] == 1)
            {
                result = 1;
            }
            else if (_inputData[i] == 2)
            {
                result = 2;
            }
            else
            {
                result = -1;
            }
        }
    }

    [Benchmark]
    public void SwitchWithTwoCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            switch (_inputData[i])
            {
                case 1: 
                    result = 1;
                    break;
                case 2: 
                    result = 2;
                    break;
                default: 
                    result = -1;
                    break;
            }
        }
    }
    
    [Benchmark]
    public void SwitchExpressionWithTwoCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            result = _inputData[i] switch
            {
                1 => 1,
                2 => 2,
                _ => -1
            };
        }
    }
    
    [Benchmark]
    public void IfElseWithFiveConditions()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            if (_inputData[i] == 1)
            {
                result = 1;
            }
            else if (_inputData[i] == 2)
            {
                result = 2;
            }
            else if (_inputData[i] == 3)
            {
                result = 3;
            }
            else if (_inputData[i] == 4)
            {
                result = 4;
            }
            else if (_inputData[i] == 5)
            {
                result = 5;
            }
            else
            {
                result = -1;
            }
        }
    }

    [Benchmark]
    public void SwitchWithFiveCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            switch (_inputData[i])
            {
                case 1: 
                    result = 1;
                    break;
                case 2: 
                    result = 2;
                    break;
                case 3: 
                    result = 3;
                    break;
                case 4: 
                    result = 4;
                    break;
                case 5: 
                    result = 5;
                    break;
                default: 
                    result = -1;
                    break;
            }
        }
    }
    
    [Benchmark]
    public void SwitchExpressionWithFiveCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            result = _inputData[i] switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                _ => -1
            };
        }
    }
    
    [Benchmark]
    public void IfElseWithTenConditions()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            if (_inputData[i] == 1)
            {
                result = 1;
            }
            else if (_inputData[i] == 2)
            {
                result = 2;
            }
            else if (_inputData[i] == 3)
            {
                result = 3;
            }
            else if (_inputData[i] == 4)
            {
                result = 4;
            }
            else if (_inputData[i] == 5)
            {
                result = 5;
            }
            else if (_inputData[i] == 6)
            {
                result = 6;
            }
            else if (_inputData[i] == 7)
            {
                result = 7;
            }
            else if (_inputData[i] == 8)
            {
                result = 8;
            }
            else if (_inputData[i] == 9)
            {
                result = 9;
            }
            else if (_inputData[i] == 0)
            {
                result = 0;
            }
            else
            {
                result = -1;
            }
        }
    }

    [Benchmark]
    public void SwitchWithTenCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            switch (_inputData[i])
            {
                case 1: 
                    result = 1;
                    break;
                case 2: 
                    result = 2;
                    break;
                case 3: 
                    result = 3;
                    break;
                case 4: 
                    result = 4;
                    break;
                case 5: 
                    result = 5;
                    break;
                case 6: 
                    result = 6;
                    break;
                case 7: 
                    result = 7;
                    break;
                case 8: 
                    result = 8;
                    break;
                case 9: 
                    result = 9;
                    break;
                case 0: 
                    result = 0;
                    break;
                default: 
                    result = -1;
                    break;
            }
        }
    }
    
    [Benchmark]
    public void SwitchExpressionWithTenCases()
    {
        int result;
        
        for (int i = 0; i < _iterations; i++)
        {
            result = _inputData[i] switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                7 => 7,
                8 => 8,
                9 => 9,
                0 => 0,
                _ => -1
            };
        }
    }
}