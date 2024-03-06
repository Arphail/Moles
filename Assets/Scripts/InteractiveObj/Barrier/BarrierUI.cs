using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractiveObj.Barrier
{
    public class BarrierUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;

        public void ShowButton(string buttonText)
        {
            _buttonText.text = buttonText;
            _button.gameObject.SetActive(true);
        }

        public void HideButton() => _button.gameObject.SetActive(false);
    }
}
