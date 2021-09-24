using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ECS
{
    struct TransformComponent : IComponent
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }
}
