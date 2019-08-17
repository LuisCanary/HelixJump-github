using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int best;
    [HideInInspector]
    public int score;
    [SerializeField]
    private int currentStage = 0;

    public static GameManager singleton;


    private void Awake()
    {
        if (singleton==null)
        {
            singleton = this;
        }
        else if (singleton!=this)
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {

    }
    public void RestartLevel()
    {

    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score>best)
        {
            best = score;
            //Store highscore
        }
    }
}
