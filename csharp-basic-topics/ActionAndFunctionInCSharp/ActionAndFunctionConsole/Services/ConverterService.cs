using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFunctionConsole.Services
{
    public  class ConverterService
    {
        Func<string, string> _converter;
        public Action beforeAction;

        public ConverterService(Func<string, string> converter)
        {
            _converter = converter;
        }


        public string Convert(string convertParameter)
        {
            if (beforeAction != null)
            {
                beforeAction.Invoke();
            }
            return _converter.Invoke(convertParameter);
        }
    }
}
