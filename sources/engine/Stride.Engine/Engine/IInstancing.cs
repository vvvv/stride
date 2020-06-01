using System;
using System.Collections.Generic;
using System.Text;
using Stride.Core.Mathematics;

namespace Stride.Engine
{
    public interface IInstancing
    {
        void Update();
    }

    public interface IInstancingMany : IInstancing
    {
        int InstanceCount { get; }

        BoundingBox BoundingBox { get; }
    }
}
