using UnityEngine;

public class Ball : MonoBehaviour
{
    // Khai báo biến Rigidbody2D để truy cập vào thành phần vật lý của quả bóng
    public Rigidbody2D rb2d;
    // Khai báo biến moveSpeed để thiết lập tốc độ di chuyển của quả bóng
    public float moveSpeed;
    // Khai báo biến maxIntialAngle để giới hạn góc ban đầu của quả bóng
    public float maxIntialAngle = 0.67f;

    public float maxStartY = 4f;
    private float startX = 0f;

    private void Start()
    {
        // Thiết lập vận tốc ban đầu cho quả bóng
        Vector2 dir = Vector2.left;
        dir.y = Random.Range(-maxIntialAngle, maxIntialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }

    private void ResetBall()
    {
        float posY = UnityEngine.Random.Range(-maxStartY, maxStartY);
        Vector2 startPosition = new Vector2(startX, posY);
        transform.position = startPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Gọi hàm của ScoreZone khi va chạm với nó
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            Debug.Log("Score!");
            ResetBall();
        }
    }
}
