using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI Text;
// Hàm ScoreUpdate được gọi để cập nhật điểm số hiển thị trên màn hình
    public void ScoreUpdate(int score)
    {
        Text.text = score.ToString();
    }
}
