using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent OnScoreUpdated;

    private int score;

    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score++;
        OnScoreUpdated?.Invoke();
    }
}
