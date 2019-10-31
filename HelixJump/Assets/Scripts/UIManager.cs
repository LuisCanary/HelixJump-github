using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text bestScoreText = null;
	[SerializeField]
	private Image progressSlider = null;
	[SerializeField]
	private Text actualLevel = null;
	[SerializeField]
	private Text nextLevel=null;

	[SerializeField]
	public Transform topTransform;
	[SerializeField]
	public Transform goalTransform;
	[SerializeField]
	public Transform ball;
	private void Update()
    {
        bestScoreText.text = GameManager.singleton.best.ToString();
        scoreText.text = GameManager.singleton.score.ToString();

		ChangeSliderLevelAndProgress();
	}

	/// <summary>
	/// Change the level text of the slider and the slider progress
	/// </summary>
	public void ChangeSliderLevelAndProgress()
	{
		actualLevel.text = ""+ (GameManager.currentStage+1);
		nextLevel.text = "" + (GameManager.currentStage + 2);

		float totalDistance = (topTransform.position.y - goalTransform.position.y );
		float distanceLeft = totalDistance-(ball.position.y-goalTransform.position.y);
		float value = (distanceLeft / totalDistance);

		progressSlider.fillAmount = Mathf.Lerp(progressSlider.fillAmount, value, 5 * Time.deltaTime);

	}
	

}
