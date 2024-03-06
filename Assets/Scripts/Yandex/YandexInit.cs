using System.Collections;
using Agava.YandexGames;
using Data;
using Lean.Localization;
using UnityEngine;

namespace Yandex
{
    public class YandexInit : MonoBehaviour
    {
        [SerializeField] private LeanLocalization _localization;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize();

            if (YandexGamesSdk.Environment.i18n.lang == "en")
                _localization.SetCurrentLanguage(Constants.English);

            if (YandexGamesSdk.Environment.i18n.lang == "ru")
                _localization.SetCurrentLanguage(Constants.Russian);

            if (YandexGamesSdk.Environment.i18n.lang == "tr")
                _localization.SetCurrentLanguage(Constants.Turkish);
        }
    }
}