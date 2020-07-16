using TMPro;
using UI.Animations;
using UnityEngine;

namespace UI.Views
{
    public class WinPageView : FadingTab
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private FadingTab fadingTab;
        
        public void Show(string playerNickname)
        {
            fadingTab.FadeOut();
            text.text = $"Игрок <color={"yellow"}>{playerNickname}</color> победил!";
        }
    }
}
