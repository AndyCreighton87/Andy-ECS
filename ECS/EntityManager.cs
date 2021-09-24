using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Linq;

namespace ECS
{
    class EntityManager
    {
        private static UInt32 entityID = 0;
        public static List<Entity> entities;

        private const int MAX_ENTITES = 1000;
        private const int MAX_COMPONENTS_PER_ENTITY = 32;

        public static int numOfEntitiesInWorld
        {
            get { return entities.Count; }
        }

        public static void Init()
        {
            entities = new List<Entity>(MAX_ENTITES);
        }

        public static void AddEntity(ref Entity pEntity)
        {
            //This could be replaced with a pooling system, so we reuse IDs
            pEntity.id = entityID++;
            pEntity.componentTypes = new List<int>(ComponentManager.GetNumberOfComponentTypes());
            pEntity.componentData = new List<int>(MAX_COMPONENTS_PER_ENTITY);
            entities.Add(pEntity);
        }

        public static void RemoveEntity(ref Entity pEntity)
        {
            entities.Remove(pEntity);
        }

        public static void AddComponentToEntity(ref Entity pEntity, ref IComponent pComponent)
        {
            ComponentManager.CacheComponent(pComponent);

            Type tType = pComponent.GetType();
            ComponentManager.componentTypes.TryGetValue(tType, out int tID);
            pEntity.componentTypes.Add(tID);
            pEntity.componentData.Add(ComponentManager.GetComponentIndex(ref pComponent));
        }

        public static void RemoveComponentFromEntity(ref Entity pEntity, ref IComponent pComponent)
        {
            Type tType = pComponent.GetType();
            ComponentManager.componentTypes.TryGetValue(tType, out int tID);
            pEntity.componentTypes.Remove(tID);

            int tComponentIndex = ComponentManager.GetComponentIndex(ref pComponent);
            pEntity.componentData.Remove(tComponentIndex);
            ComponentManager.RemoveComponent(tComponentIndex);
        }

        //public IComponent GetComponent(ref Entity pEntity, Type pComponentType)
        //{
        //    //I think this will be much easier in C++, returning a pointer to the component.
        //
        //    ComponentManager.componentTypes.TryGetValue(pComponentType, out int tID);
        //    //tID = component type. Now what?
        //    for (int i = 0; i < pEntity.componentData.Count; i++)
        //    {
        //        //for each component data, check the type, then check if the type matches argument
        //        if (ComponentManager.allComponents[pEntity.componentData[i]].GetType() == pComponentType)
        //        {
        //            //This will not work because it is a list. An array would work.
        //            return ref ComponentManager.allComponents[pEntity.componentData[i]]
        //        }
        //    }
        //
        //    return tComponent;
        //}

        public static IComponent GetComponent(ref Entity pEntity, Type pComponentType)
        {
            for (int i = 0; i < pEntity.componentData.Count; i++)
            {
                int tIndex = pEntity.componentData[i];
                if (ComponentManager.allComponents[tIndex].GetType() == pComponentType)
                    return ComponentManager.allComponents[tIndex];
            }

            return null;
        }

        public static void SetEntityData(ref Entity pEntity, IComponent pComponentData)
        {
            for(int i = 0; i < pEntity.componentData.Count; i++)
            {
                int tIndex = pEntity.componentData[i];

                if (ComponentManager.allComponents[tIndex].GetType() == pComponentData.GetType())
                    ComponentManager.allComponents[tIndex] = pComponentData;
            }
        }

        public static Entity[] GetAllEntitiesWithComponents(params Type[] pComponents)
        {
            List<Entity> tEntitiesWithComponents = new List<Entity>();
            List<int> tComponentIDs = new List<int>();

            foreach(Type entry in pComponents)
            {
                ComponentManager.componentTypes.TryGetValue(entry, out int tID);
                tComponentIDs.Add(tID);
            }

            foreach(var entry in entities)
            {
                if (tComponentIDs.All(x => entry.componentTypes.Contains(x)))
                    tEntitiesWithComponents.Add(entry);
            }

            return tEntitiesWithComponents.ToArray();
        }
    }
}
