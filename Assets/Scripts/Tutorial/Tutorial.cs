using System.Collections.Generic;
using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<Image> _tutorialPages;
    [SerializeField] private Button _nextPage;
    [SerializeField] private Button _previousPage;
    [SerializeField] private TMP_Text _currentPageVisual;
    [SerializeField] private Image _mobileControlsPage;
    [SerializeField] private Image _desktopControlsPage;

    private Image _currentPage;
    private int _currentPageIndex;

    private void Start()
    {
        if (Device.Type.ToString() == "Desktop")
            _tutorialPages[0] = _desktopControlsPage;
        else
            _tutorialPages[0] = _mobileControlsPage;

        _currentPage = _tutorialPages[0];
        _currentPageIndex = 0;
        _currentPage.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_currentPage != _tutorialPages[0] && _currentPage != _tutorialPages[_tutorialPages.Count - 1])
        {
            _nextPage.gameObject.SetActive(true);
            _previousPage.gameObject.SetActive(true);
        }

        if (_currentPage == _tutorialPages[0])
            _previousPage.gameObject.SetActive(false);

        if (_currentPage == _tutorialPages[_tutorialPages.Count - 1])
            _nextPage.gameObject.SetActive(false);

        _currentPageVisual.text = $"{_currentPageIndex + 1} / {_tutorialPages.Count}";
    }

    public void NextPage()
    {
        for (int i = 0; i < _tutorialPages.Count; i++)
        {
            if (_currentPage == _tutorialPages[i])
            {
                _currentPage.gameObject.SetActive(false);
                _tutorialPages[++i].gameObject.SetActive(true);
                _currentPage = _tutorialPages[i];
                _currentPageIndex = i;
            }
        }
    }

    public void PreviousPage()
    {
        for (int i = 0; i < _tutorialPages.Count; i++)
        {
            if (_currentPage == _tutorialPages[i])
            {
                _currentPage.gameObject.SetActive(false);
                _tutorialPages[--i].gameObject.SetActive(true);
                _currentPage = _tutorialPages[i];
                _currentPageIndex = i;
            }
        }
    }
}
