// See https://aka.ms/new-console-template for more information
using Action_and_Function_Delegates;


int x = Convert.ToInt32(Console.ReadLine());


switch (x)
{
    case 1:
        Services.RunSimpleDelegateExample();
        break;
    case 2:
        Services.RunMultiCastDelegate(); 
        break;
    case 3:
        DelegateSample.TestDelegate(); 
        break;
    default:
        break;
}