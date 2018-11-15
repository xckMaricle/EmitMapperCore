using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitMapperCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始测试");
            BasicTest.BasicCompare();
            Console.WriteLine("结束测试");
            Console.ReadLine();
        }
    }
}
