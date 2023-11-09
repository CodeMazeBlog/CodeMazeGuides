namespace ReflectionInCSharp;

public interface IMotionSensor 
{
    void Observe();
    void Observe(string direction);
}