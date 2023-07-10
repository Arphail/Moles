using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup _leaderBoardView;
    [SerializeField] private LeaderBoardUnit _thePlayer;

    public LeaderBoardUnit ThePlayer => _thePlayer;

    public void ShowPlayer()
    {
        Leaderboard.GetPlayerEntry("1", (result) =>
        {
            _thePlayer.SetValues(null, result.rank, result.player.publicName, result.score);
        });
    }
}
