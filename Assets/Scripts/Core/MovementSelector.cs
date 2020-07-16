using System;
using System.Collections.Generic;
using System.Linq;
using Core.Movement;
using Core.Movement.Animation;
using UnityEngine;

namespace Core
{
    public class MovementSelector : MonoBehaviour
    {
        [SerializeField] private List<MovementAnimation> movementAnimations = new List<MovementAnimation>();
        private Dictionary<Type, IMovementAnimation> _movementTypes = new Dictionary<Type, IMovementAnimation>();

        private void Start()
        {
            _movementTypes = new Dictionary<Type, IMovementAnimation>()
            {
                {typeof(CheckersOverMovement), movementAnimations[1]},
                {typeof(HorizontalVerticalOverMovement), movementAnimations[1]},
                {typeof(StepMovement), movementAnimations[0]}
            };
        }

        public void AddMovement(int index)
        {
            var movementPair = _movementTypes.ElementAt(index);
            foreach (var figure in FindObjectsOfType<Figure>())
            {
                var movement = (IMovement) figure.gameObject.AddComponent(movementPair.Key);
                var movementAnimation = movementPair.Value;
                
                figure.SetMovement(movement, movementAnimation);
            }
        }
        
    }
    
}
