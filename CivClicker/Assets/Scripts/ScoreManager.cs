using System.Numerics;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TMP_Text PLAYER_SCORE_LABEL;
    public BigInteger PLAYER_SCORE_VALUE = 20000;
    private TMP_Text PLAYER_RATE_LABEL;
    public float PLAYER_RATE_VALUE = 0; // rate per second


    public static ScoreManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (PLAYER_SCORE_LABEL == null)
        {
            PLAYER_SCORE_LABEL = GameObject.Find("PLAYER_SCORE").GetComponent<TMP_Text>();
        }

        if (PLAYER_RATE_LABEL == null)
        {
            PLAYER_RATE_LABEL = GameObject.Find("RATE_PER_SECOND").GetComponent<TMP_Text>();
        }
    }

    private void Update()
    {
        PLAYER_SCORE_LABEL.text = PLAYER_SCORE_VALUE.ToString("N0"); 

        PLAYER_RATE_LABEL.text = $"per second: {PLAYER_RATE_VALUE}c";
    }

    public void PlayerClick()
    {
        PLAYER_SCORE_VALUE++;
    }

    public void IncreasePlayerScore(float amount)
    {
        PLAYER_SCORE_VALUE += (BigInteger)amount;
    }

    public void IncreasePlayerRate(float amount)
    {
        PLAYER_RATE_VALUE += amount;
        Debug.Log($"Run {amount}");
    }
}
