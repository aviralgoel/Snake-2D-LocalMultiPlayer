using System;
using UnityEngine;
[System.Serializable]
public class PlayerStats
{

    [SerializeField] private bool isImmune;
    [SerializeField] private int initialSize;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private int score = 0;
    [SerializeField] private float scoreBoostMultiplier = 1f;

    // getters and setters
    public float Speed { get => speed; set => speed = value; }
    public float SpeedMultiplier { get => speedMultiplier; set => speedMultiplier = value; }
    public float ScoreBoostMultiplier { get => scoreBoostMultiplier; set => scoreBoostMultiplier = value; }
    public int Score { get => score; }

    public PlayerStats()
    {
        isImmune = false;
        initialSize = 4;
    }
    public void IncreaseScore(int _increment)
    {
        score += _increment;
    }
    public void DecreaseScore(int _increment)
    {
        score -= _increment;
    }
    public void setIsImmune(bool _isImmune)
    {
        isImmune = _isImmune;
    }
    public bool getIsImmune()
    {
        return isImmune;
    }
    public void setInitialSize(int _size)
    {
        initialSize = _size;
    }
    public int getInitialSize()
    {
        return initialSize;
    }
    
}
