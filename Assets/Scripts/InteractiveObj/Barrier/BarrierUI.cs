using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarrierUI : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _buttonText;

    public Button Button => _button;

    public void ShowButton(string buttonText)
    {
        _buttonText.text = buttonText;
        _button.gameObject.SetActive(true);
    }

    public void HideButton() => _button.gameObject.SetActive(false);
}
