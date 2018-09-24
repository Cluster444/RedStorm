using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Mathf;
using static RedStorm.Mathf;

namespace RedStorm
{
    public class DebugCamera : MonoBehaviour
    {
        private SphericalPosition position;
        private FocalPoint focalPoint;

        private void Awake()
        {
            position = new SphericalPosition
            {
                Value = new SVector(20, 45 * Deg2Rad, 0)
            };


            focalPoint = new FocalPoint
            {
                Position = new float3(0, 0, 0)
            };

            transform.position = position.Value.ToCartesian().xzy;
        }

        private void Update()
        {
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
            bool inScreen = screenRect.Contains(Input.mousePosition);

            if (!inScreen) return;

            float3 axis = new float3
            {
                x = -Input.GetAxis(MouseAxis.x) / 20,
                y = Input.GetAxis(MouseAxis.y) / 20,
                z = Input.GetAxis(MouseAxis.z)
            };

            bool leftDown = Input.GetMouseButton(MouseButton.Left);
            bool rightDown = Input.GetMouseButton(MouseButton.Right);
            bool zooming = math.abs(axis.z) > Epsilon;
            bool moving = leftDown || rightDown || zooming;

            if (!moving) return;

            Debug.Log("Moving");

            if (rightDown)
            {
                position.Value.azimuth = ClampRadiansTwoPI(position.Value.azimuth + axis.x);
                position.Value.polar = Clamp(position.Value.polar + axis.y, 1 * Deg2Rad, 179 * Deg2Rad);
                position.Value.radius = Max(position.Value.radius + axis.z, 1);
            }
            else if (leftDown)
            {
                focalPoint.Position.x += axis.x;
                focalPoint.Position.y += -axis.y;
            }

            transform.position = focalPoint.Position.xzy - position.Value.ToCartesian().xzy;
            transform.rotation = Quaternion.LookRotation(focalPoint.Position.xzy - (float3) transform.position);
        }
    }
}
