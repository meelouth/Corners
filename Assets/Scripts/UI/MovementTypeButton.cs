using Core;
using Map;
using UI.Animations;
using UnityEngine;

namespace UI
{
    public class MovementTypeButton : MonoBehaviour
    {
        [SerializeField] private GameMode gameMode;
        [SerializeField] private MovementSelector movementSelector;
        [SerializeField] private FadingTab movementSelectorTab;
        
        public void OnButtonClicked(int index)
        {
            gameMode.StartGameMode();
            movementSelector.AddMovement(index);
            movementSelectorTab.FadeIn();
        }
    }
}
