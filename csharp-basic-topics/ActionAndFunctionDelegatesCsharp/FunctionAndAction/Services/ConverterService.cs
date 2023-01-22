using System;
namespace FunctionAndAction.Services
{
	public class ConverterService
	{
        Func<string, string> _converter;
		public Action beforeAction;

        public ConverterService(Func<string, string> converter)
		{
			_converter = converter;
		}
		

		public string  Convert(string convertParameter)
		{
			if (beforeAction != null)
			{
                beforeAction.Invoke();
			}
			return _converter.Invoke(convertParameter);
		}
	}
}

