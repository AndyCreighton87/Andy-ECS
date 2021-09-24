using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ECS
{
    //Entity class. Holds the ID of the entity. In C++ I should be able to use an alias to make the class itself an int.
    //e.g. using Entity = System.UInt32 works, but is not global. It needs to be in each script that uses Entity.
    //In C++ we can using Entity = std::uint32_t or use bitsets.
    public struct Entity
    {
        public UInt32 id;

        public List<int> componentTypes;
        public List<int> componentData;
    }
}
