using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ECS
{
    class Program
    {
        public static bool isDone = false;

        static void Main(string[] args)
        {
            ECS.Init();

            while(!isDone)
                ECS.Update();
        }
    }
}
