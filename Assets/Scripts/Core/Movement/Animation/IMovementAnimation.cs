using UnityEngine;

namespace Core.Movement.Animation
{
    public interface IMovementAnimation
    {
        void Move(Transform transform, Vector3 position);
    }
}