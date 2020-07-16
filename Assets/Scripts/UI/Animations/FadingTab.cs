using DG.Tweening;
using UnityEngine;

namespace UI.Animations
{
    public class FadingTab : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float duration = 0.6f;

        private const float MinValue = 0, MaxValue = 1;
        
        public void FadeIn()
        {
            canvasGroup.DOFade(MinValue, duration).OnComplete(Disable);
        }

        public void FadeOut()
        {
            Enable();
            canvasGroup.DOFade(MaxValue, duration);
        }

        private void Disable()
        {
            canvasGroup.gameObject.SetActive(false);
        }

        private void Enable()
        {
            canvasGroup.gameObject.SetActive(true);
        }
    }
}
