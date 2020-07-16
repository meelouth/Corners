using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private void OnEnable() => GetComponent<Button>().onClick.AddListener(Restart);

        private void OnDisable() => GetComponent<Button>().onClick.AddListener(Restart);

        private static void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
