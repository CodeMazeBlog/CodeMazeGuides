using System;
namespace CSConstructors
{
	public class SingletonClass
	{
		private static SingletonClass _singletonClass;

		private SingletonClass()
		{
		}

		public static SingletonClass getInstance()
        {
			if(_singletonClass == null)
            {
				_singletonClass = new SingletonClass();
            }
			return _singletonClass;
        }
	}
}

