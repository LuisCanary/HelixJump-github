using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;


    private void Update()
    {
        bestScoreText.text = GameManager.singleton.best.ToString();
        scoreText.text = GameManager.singleton.score.ToString();
    }




}
