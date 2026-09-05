using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int P1Score, P2Score;

    public ScoreText scoreTextLeft, scoreTextRight;

    public System.Action onReset;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnScoreZoneReached(int id)
    {
        if (onReset != null)
            {
                onReset.Invoke();
            }

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

    public void UpdateScoreText()
    {
        scoreTextLeft.ScoreUpdate(P1Score);
        scoreTextRight.ScoreUpdate(P2Score);
    }
    }
