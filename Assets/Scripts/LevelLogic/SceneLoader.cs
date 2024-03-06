using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelLogic
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadLevel()
            => SceneManager.LoadScene(Constants.ForestLevel);
    }
}
