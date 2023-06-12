using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_and_Action_Delegates
{
    
	public class GreetUser
	{
        private readonly Action<string> _greetUser;

        public GreetUser(Action<string> greetUser)
        {
            _greetUser = greetUser;
        }

        public void SayHi(string message)
        {
            _greetUser(message);
        }
    }
    
}
