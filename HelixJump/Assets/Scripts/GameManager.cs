using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int best;
    [HideInInspector]
    public int score;
    [SerializeField]
    public static int currentStage = 0;

    public static GameManager singleton;

	[SerializeField]
	public Text textPlus1;

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

        best = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }
    public void RestartLevel()
    {

        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        //Reload Stage
    }

	/// <summary>
	/// Add the score and also animation +1
	/// </summary>
	/// <param name="scoreToAdd"></param>
    public void AddScore(int scoreToAdd)
    {

		textPlus1.GetComponent<Animation>().Play();
        score += scoreToAdd;
        if (score>best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore",score);
            //Store highscore
        }
    }
}
