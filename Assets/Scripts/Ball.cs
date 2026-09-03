using UnityEngine;

public class Ball : MonoBehaviour
{
    // Khai báo biến gameManager để truy cập vào GameManager
    public GameManager gameManager;
    // Khai báo biến Rigidbody2D để truy cập vào thành phần vật lý của quả bóng
    public Rigidbody2D rb2d;
    // Khai báo biến moveSpeed để thiết lập tốc độ di chuyển của quả bóng
    public float moveSpeed;
    // Khai báo biến maxIntialAngle để giới hạn góc ban đầu của quả bóng
    public float maxIntialAngle = 0.67f;
    // Khai báo biến maxStartY để giới hạn vị trí y ban đầu của quả bóng
    public float maxStartY = 4f;
    // Khai báo biến startX để lưu trữ vị trí x ban đầu của quả bóng
    private float startX = 0f;
    // Hàm Start được gọi khi đối tượng được khởi tạo
    private void Start()
    {
        // Thiết lập vận tốc ban đầu cho quả bóng
        Vector2 dir = Vector2.left;
        dir.y = Random.Range(-maxIntialAngle, maxIntialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }
    // Hàm để reset vị trí của quả bóng về vị trí ban đầu
    private void ResetBall()
    {
        float posY = UnityEngine.Random.Range(-maxStartY, maxStartY);
        Vector2 startPosition = new Vector2(startX, posY);
        transform.position = startPosition;
    }
    // Hàm xử lý va chạm với các đối tượng khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Gọi hàm của ScoreZone khi va chạm với nó
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            // Gọi hàm OnScoreZoneReached của GameManager để cập nhật điểm số
            gameManager.OnScoreZoneReached(scoreZone.id);
            Debug.Log("Score!");
            ResetBall();
        }
    }
}
