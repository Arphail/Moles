using UnityEngine;

public class LevelFinishUi : MonoBehaviour
{
    public void ShowUI() => gameObject.SetActive(true);

    public void HideUI() => gameObject.SetActive(false);
}
