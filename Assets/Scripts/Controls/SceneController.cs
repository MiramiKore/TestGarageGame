using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controls
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Button[] buttons; // Массив кнопок доступных для взаимодействия

        private void Awake()
        {
            buttons[0].onClick.AddListener(StartGame);
            buttons[1].onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("PrevewScene");
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            // Для редактора Unity останавливаем режим воспроизведения
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Для билда игры выполняем выход
            Application.Quit();
#endif
        }
    }
}
