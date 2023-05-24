using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Scene _currentScene;

    void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    public void LoadNextScene()
    {
        if (_currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(_currentScene.buildIndex + 1);
    }
}
