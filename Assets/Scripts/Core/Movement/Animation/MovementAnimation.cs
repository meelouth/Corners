using DG.Tweening;
using UnityEngine;

namespace Core.Movement.Animation
{
    [CreateAssetMenu (menuName = "Movement/Animation/Base")]
    public class MovementAnimation : ScriptableObject, IMovementAnimation
    {
        [SerializeField] protected float duration;

        public virtual void Move(Transform transform, Vector3 position)
        {
            transform.DOMove(position, duration);
        }
    }
}
