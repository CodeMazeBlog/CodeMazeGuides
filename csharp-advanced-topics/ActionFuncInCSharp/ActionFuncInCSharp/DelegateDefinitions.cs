public delegate void BasicCalcPrintDelegate(int numberOne, int numberTwo);

public delegate void BasicCalcPrintDelegate<T>(T numberOne, T numberTwo);

public delegate void IntBasicCalcDelegate(int numberOne, int numberTwo);

public delegate T BasicCalcDelegate<T>(T numberOne, T numberTwo);