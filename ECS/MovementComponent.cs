using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ECS
{
    public struct MovementComponent : IComponent
    {
        public float speed;
        public Vector3 moveDirection;
    }
}
