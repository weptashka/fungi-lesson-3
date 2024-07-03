using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public static class Vector3Extension
    {
        public static float DistancePow(this Vector3 a, Vector3 b)
        {
            float num1 = a.x - b.x;
            float num2 = a.y - b.y;
            float num3 = a.z - b.z;
            return num1 * num1 + num2 * num2 + num3 * num3;
        }
    }
}