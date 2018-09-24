using Unity.Mathematics;
using UnityEngine;
using static Unity.Mathematics.math;
using static UnityEngine.Mathf;
using static RedStorm.Mathf;

namespace RedStorm
{
    // A vector that implements spherical mapping to or from
    // cartesian mapping.
    public struct SVector
    {
        public float radius;
        public float polar;
        public float azimuth;

        public SVector(float radius, float polar, float azimuth)
        {
            this.radius = radius;
            this.polar = polar;
            this.azimuth = azimuth;
        }

        public float3 ToCartesian()
        {
            return new float3 {
                x = radius * cos(azimuth) * sin(polar),
                y = radius * sin(azimuth) * sin(polar),
                z = radius * cos(polar)
            };
        }

        public static SVector ToSpherical(Vector3 v)
        {
            if (v.x == 0) v.x = Epsilon;
            float radius = Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            float polar = Atan(v.z / v.x);
            if (v.x < 0) polar += (float) math.PI;
            float azimuth = asin(v.y / radius);

            return new SVector
            {
                radius = radius,
                polar = polar,
                azimuth = azimuth
            };
        }
    }
}
