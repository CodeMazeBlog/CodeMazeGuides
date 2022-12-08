using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaceMethod
{
    public class IDefaultInterfaceImplementation : IDefaultInterface
    {
        private int year;
        int IDefaultInterface.year { get => year; set => year = value; }
    }
}
