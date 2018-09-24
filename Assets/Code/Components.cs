using System;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.Experimental.Rendering;

namespace RedStorm
{
    // Components are organized by regions that deal with specific areas of the game. The regions should be sorted
    // alphabetically with a region for more general components at the top.

#region General
#endregion

#region Camera

    [Serializable]
    public struct FocalPoint : IComponentData
    {
        public float3 Position;
    }

    [Serializable]
    public struct SphericalPosition : IComponentData
    {
        public SVector Value;
    }

#endregion

#region Maps

    [Serializable]
    public struct TilePosition : IComponentData
    {
        public byte x;
        public byte y;
        public byte z;
    }

#endregion
}
