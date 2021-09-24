using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ECS
{
    public struct PhysicsComponent : IComponent
    {
        public float gravity;
        public Vector3 velocity;
        public float acceleration;
    }
}
