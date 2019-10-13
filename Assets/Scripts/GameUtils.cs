using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUtils : MonoBehaviour
{
    private static GameUtils _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        DontDestroyOnLoad(_instance);
        DontDestroyOnLoad(_gameOverCanvas);

        _reloadButton.onClick.AddListener(() => GameStart());
    }

    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private Button _reloadButton;

    public static void GameStart(bool restart = true)
    {
        Time.timeScale = 1f;
        Stats.Sheeps = 0;

        if (restart)
            _instance.StartCoroutine(ReloadScene());
        else
            _instance.ShowCanvas(false);
    }

    public static void GameOver()
    {
        Time.timeScale = 0f;
        Handheld.Vibrate();
        _instance.ShowCanvas(true);
    }

    private void ShowCanvas(bool mode)
    {
        _gameOverCanvas.gameObject.SetActive(mode);
    }

    private static IEnumerator ReloadScene()
    {
        var scene = SceneManager.GetActiveScene().name;
        yield return SceneManager.UnloadSceneAsync(scene);
        yield return new WaitForSeconds(0.1f);
        yield return SceneManager.LoadSceneAsync(scene);
        _instance.ShowCanvas(false);
    }
}
