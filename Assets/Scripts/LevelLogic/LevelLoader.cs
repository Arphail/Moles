using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Scene _currentScene;
    private int _randomIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _currentScene = SceneManager.GetActiveScene();
    }

    public void LoadNextLevel()
    {
        while (_randomIndex == _currentScene.buildIndex)
            _randomIndex = GetRandomIndex();

        _currentScene = SceneManager.GetActiveScene();

        if( _randomIndex != _currentScene.buildIndex)
            SceneManager.LoadScene(_randomIndex);

        print(SceneManager.GetActiveScene().buildIndex);
    }

    private int GetRandomIndex()
    {
        int randomSceneIndex = Random.Range(0, SceneManager.sceneCount);
        return randomSceneIndex;
    }
}
