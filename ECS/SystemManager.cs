using System;
using System.Collections.Generic;
using System.Text;

namespace ECS
{
    class SystemManager
    {
        private static List<SystemBase> systems;

        public static void Init()
        {
            systems = new List<SystemBase>();

            systems.Add(new IncreaseSpeedSystem());

            foreach (SystemBase entry in systems)
                entry.Init();
        }

        public static void Update()
        {
            foreach (SystemBase entry in systems)
                entry.Update();
        }
    }
}
