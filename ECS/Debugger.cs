using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ECS
{
    class Debugger
    {
        public static void Debug()
        {
            // ----- TOTAL ENTITIES -----
            Console.WriteLine($"Total number of entities : {EntityManager.numOfEntitiesInWorld}");
            Console.WriteLine($"\n\nEntites : \n");

            // ----- FIND ENTITIES AND THEIR COMPONENTS -----
            foreach (Entity entry in EntityManager.entities)
            {
                Console.WriteLine($"Entity ID : { entry.id }");
                Console.WriteLine("\nComponents :");

                foreach (int component in entry.componentTypes)
                    Console.WriteLine(ComponentManager.componentTypes.FirstOrDefault(x => x.Value == component).Key.ToString());

                Console.WriteLine("\n");
            }

            // ----- FIND ENTITY BY COMPONENT -----
            Entity[] tFoundEntities = EntityManager.GetAllEntitiesWithComponents(typeof(MovementComponent));
            Console.WriteLine($"\nNumber of entites with Movement & Transform Component : { tFoundEntities.Length }\n\n");


            // ----- GETTING / SETTING COMPONENT DATA -----
            MovementComponent tMovementComponent = (MovementComponent)EntityManager.GetComponent(ref tFoundEntities[0], typeof(MovementComponent));
            Console.WriteLine($"Movement Component");
            Console.WriteLine($"Speed : { tMovementComponent.speed }");
            Console.WriteLine($"Move Direction : { tMovementComponent.moveDirection }");

            tMovementComponent.speed = 20.0f;
            tMovementComponent.moveDirection = new Vector3(5.0f, 1.0f, 0.0f);

            EntityManager.SetEntityData(ref tFoundEntities[0], tMovementComponent);

            Console.WriteLine("\nUpdated Movement Component");
            Console.WriteLine($"Movement Component");
            Console.WriteLine($"Speed : { tMovementComponent.speed }");
            Console.WriteLine($"Move Direction : { tMovementComponent.moveDirection }");
        }
    }
}
