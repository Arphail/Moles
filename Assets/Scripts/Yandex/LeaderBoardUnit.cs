using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderBoardUnit : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TMP_Text _rank; 
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public Image Avatar => _avatar;
    
    public void SetValues(Image avatar, float rank, string name, float score)
    {
        _rank.text = rank.ToString();
        _avatar = avatar;
        _name.text = name;
        _score.text = score.ToString();
    }

    public void SetProfileImage(string imageUrl) => StartCoroutine(SetProfileImageCoroutine(imageUrl));

    public void SetDefaultProfilePicture(Sprite sprite) => _avatar.sprite = sprite;

    private IEnumerator SetProfileImageCoroutine(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log($"[download image error] {request.error}");
        }
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            _avatar.sprite = sprite;
        }
    }
}
