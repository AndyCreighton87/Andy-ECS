using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ECS
{
    class IncreaseSpeedSystem : SystemBase
    {
        private float targetTime = 1.0f;
        private Stopwatch timer;

        public override void Init()
        {
            timer = new Stopwatch();
        }

        public override void Update()
        {
            if (!timer.IsRunning)
                timer.Start();

            if (timer.ElapsedMilliseconds / 1000.0f >= targetTime)
            {
                Entity[] tFoundEntities = EntityManager.GetAllEntitiesWithComponents(typeof(MovementComponent));

                for (int i = 0; i < tFoundEntities.Length; i++)
                {
                    //I don't like this casting.
                    MovementComponent tComponent = (MovementComponent)EntityManager.GetComponent(ref tFoundEntities[i], typeof(MovementComponent));
                    Console.WriteLine($"Speed : { tComponent.speed }");

                    tComponent.speed++;
                    EntityManager.SetEntityData(ref tFoundEntities[i], tComponent);
                }
                timer.Reset();
            }
        }
    }
}
