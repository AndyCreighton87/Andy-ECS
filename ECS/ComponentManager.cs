using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECS
{
    class ComponentManager
    {
        public static Dictionary<Type, int> componentTypes;
        public static int componentIndex = 0;

        public static List<IComponent> allComponents;

        /* Not sure the best way to store componenets in memory. I originally had a list for each componenet
         * and then a list of lists, but surely this isn't right?
         * 
         * public static List<IComponent> MovementComponents;
         * public static List<IComponent> PhysicsComponents;
         * public static List<IComponent> TransformComponents;
         * public static List<List<IComponenent> AllComponenets;
         * */

        public static void Init()
        {
            componentTypes = new Dictionary<Type, int>();
            allComponents = new List<IComponent>();

            int tIndex = 0;

            componentTypes.Add(typeof(TransformComponent), tIndex++);
            componentTypes.Add(typeof(MovementComponent), tIndex++);
            componentTypes.Add(typeof(PhysicsComponent), tIndex++);
        }

        public static int GetNewComponentIndex()
        {
            return componentIndex++;
        }

        public static int GetComponentIndex(ref IComponent pComponent)
        {
            for (int i = 0; i < allComponents.Count; i++)
                if (allComponents[i] == pComponent)
                    return i;

            return 0;
        }

        public static void RemoveComponent(int tIndex)
        {
            allComponents.RemoveAt(tIndex);
        }

        public static int GetNumberOfComponentTypes()
        {
            return componentTypes.Count;
        }

        public static void CacheComponent(IComponent pComponent)
        {
            allComponents.Add(pComponent);

            //Type tComponentType = pComponent.GetType();
            //
            //foreach(List<IComponent> entry in listOfComponents)
            //{
            //    if (entry.GetType().GetGenericArguments().Single() == tComponentType)
            //        entry.Add(pComponent);
            //}
        }
    }
}
