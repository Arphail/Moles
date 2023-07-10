using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUnit : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TMP_Text _rank; 
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void SetValues(Image avatar, float rank, string name, float score)
    {
        _rank.text = rank.ToString();
        _avatar = avatar;
        _name.text = name;
        _score.text = score.ToString();
    }
}
