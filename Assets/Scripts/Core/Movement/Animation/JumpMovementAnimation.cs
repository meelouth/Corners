using DG.Tweening;
using UnityEngine;

namespace Core.Movement.Animation
{
    [CreateAssetMenu (menuName = "Movement/Animation/Jump")]
    public class JumpMovementAnimation : MovementAnimation
    {
        [SerializeField] private float jumpPower = 5f;
        [SerializeField] private int jumpNumbers = 1;
        
        public override void Move(Transform transform, Vector3 position)
        {
            transform.DOJump(position, jumpPower, jumpNumbers, duration);
        }
    }
}
