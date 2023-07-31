using UnityEngine;
using Agava.YandexGames;
using Lean.Localization;

public class AutoLocalization : MonoBehaviour
{
    [SerializeField] private LeanLocalization _localization;

    private void Start()
    {
        if (YandexGamesSdk.Environment.i18n.lang == "en")
            _localization.SetCurrentLanguage(Constants.English);

        if (YandexGamesSdk.Environment.i18n.lang == "ru")
            _localization.SetCurrentLanguage(Constants.Russian);

        if (YandexGamesSdk.Environment.i18n.lang == "tr")
            _localization.SetCurrentLanguage(Constants.Turkish);
    }
}
