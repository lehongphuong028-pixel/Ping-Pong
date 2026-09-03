using UnityEngine;

public class GameManager : MonoBehaviour
{
// Khai báo biến P1Score và P2Score để lưu trữ điểm số của người chơi 1 và người chơi 2
   public int P1Score, P2Score;
// Khai báo biến scoreTextLeft và scoreTextRight để truy cập vào các đối tượng ScoreText
   public ScoreText scoreTextLeft, scoreTextRight;
   // Hàm OnScoreZoneReached được gọi khi quả bóng chạm vào ScoreZone
   public void OnScoreZoneReached(int id)
   {
       if (id == 1)
       {
           P1Score++;
       }
       else if (id == 2)
       {
           P2Score++;
       }
       UpdateScoreText();
   }
   // Hàm UpdateScoreText được gọi để cập nhật điểm số hiển thị trên màn hình
   public void UpdateScoreText()
   {
       scoreTextLeft.ScoreUpdate(P1Score);
       scoreTextRight.ScoreUpdate(P2Score);
   }
}
