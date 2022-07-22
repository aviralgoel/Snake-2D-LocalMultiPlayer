using System;
using UnityEngine;
[System.Serializable]
public class PlayerStats
{

    [SerializeField] private bool isImmune;
    [SerializeField] private int initialSize;
    [SerializeField] private float movespeed;
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreBoostMultiplier = 1;
    [SerializeField] private bool isDead = false;
    [SerializeField] private float defaultSpeed = 0.06f;
    [SerializeField] public int playerID;

    // getters and setters
   
    public int ScoreBoostMultiplier { get => scoreBoostMultiplier; set => scoreBoostMultiplier = value; }
    public int Score { get => score; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public float Movespeed { get => movespeed; set => movespeed = value; }
    public float DefaultSpeed { get => defaultSpeed; set => defaultSpeed = value; }

    public PlayerStats()
    {
        isImmune = false;
        initialSize = 4;
        movespeed = 0.06f;
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
