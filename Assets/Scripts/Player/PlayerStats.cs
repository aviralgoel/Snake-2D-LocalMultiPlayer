using System;
using UnityEngine;
[System.Serializable]
public class PlayerStats
{

    [SerializeField] private bool isImmune;
    [SerializeField] private int initialSize;
    [SerializeField] private float movespeed = 1f;
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreBoostMultiplier = 1;
    [SerializeField] private bool isDead = false;

    // getters and setters
    public float MoveSpeed { get => movespeed; set => movespeed = value; }
    public int ScoreBoostMultiplier { get => scoreBoostMultiplier; set => scoreBoostMultiplier = value; }
    public int Score { get => score; }
    public bool IsDead { get => isDead; set => isDead = value; }

    public PlayerStats()
    {
        isImmune = false;
        initialSize = 4;
    }
    public void IncreaseScore(int _increment)
    {
        score += (_increment * scoreBoostMultiplier);
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
    public void ResetScore()
    {
        score = 0;
    }
    
}
