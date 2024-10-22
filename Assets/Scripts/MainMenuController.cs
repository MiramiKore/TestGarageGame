using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

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
#endif
    }
}