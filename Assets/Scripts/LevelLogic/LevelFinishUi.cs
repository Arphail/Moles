using UnityEngine;

namespace LevelLogic
{
    public class LevelFinishUi : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}
