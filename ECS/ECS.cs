using System;
using System.Collections.Generic;
using System.Text;

namespace ECS
{
    class ECS
    {
        public static void Init()
        {
            EntityManager.Init();
            ComponentManager.Init();
            SystemManager.Init();
            CreateEntities();
            Debugger.Debug();
        }

        public static void Update()
        {
            SystemManager.Update();
        }
        private static void CreateEntities()
        {
            IComponent tMovementComponent;

            // ----- CREATE A NEW ENTITY AND ATTACH MOVEMENT COMPONENT -----
            Entity tNewEntity = new Entity();
            EntityManager.AddEntity(ref tNewEntity);
            tMovementComponent = new MovementComponent();
            EntityManager.AddComponentToEntity(ref tNewEntity, ref tMovementComponent);


            // ----- SET ENTITY DATA -----
            //***Could I combine this with add component??****
            EntityManager.SetEntityData(ref tNewEntity, new MovementComponent { speed = 10.0f });

            //tNewEntity = new Entity();
            //entityManager.AddEntity(ref tNewEntity);
            //tTransformComponent = new TransformComponent();
            //tMovementComponent = new MovementComponent();
            //tTransformComponent = new TransformComponent();
            //entityManager.AddComponentToEntity(ref tNewEntity, ref tTransformComponent);
            //entityManager.AddComponentToEntity(ref tNewEntity, ref tMovementComponent);
        }
    }
}
