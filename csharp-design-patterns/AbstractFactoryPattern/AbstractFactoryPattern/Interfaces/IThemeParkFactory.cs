namespace AbstractFactoryPattern.Interfaces;

public interface IThemeParkFactory
{
    IRide CreateRide();
    IShow CreateShow();
}
