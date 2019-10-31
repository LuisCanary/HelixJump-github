using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{

    private Vector2 lastTapPos;
    private Vector3 startRotation;

	[SerializeField]
	private float sensibility = 0;
 
    public Transform topTransform;
    [SerializeField]
    public Transform goalTransform;
    [SerializeField]
    private GameObject helixLevelPrefab=null;

    public List<Stage> allStages = new List<Stage>();
    private float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();


    private void Awake()
    {
        startRotation = transform.localEulerAngles;

        helixDistance = topTransform.localPosition.y - goalTransform.localPosition.y-0.1f;

        LoadStage(0);
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float delta = lastTapPos.x - currentTapPos.x;

            lastTapPos = currentTapPos;

            transform.Rotate(Vector3.up * delta* sensibility);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }

    }

    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];

        if (stage==null)
        {
            Debug.Log("No stage" + stageNumber + " found in allStages List. Are all stages assigned in the List?");
            return;
        }

        //Change color of the ball
        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;

		//Reset helix rotation
		transform.localEulerAngles = startRotation;

        //Destroy old levels if there are any
        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        //Create new level
        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            //Create level within the scene
            GameObject level = Instantiate(helixLevelPrefab, transform);
            Debug.Log("Levels Spawned");
            level.transform.localPosition = new Vector3(0,spawnPosY,0);
            spawnedLevels.Add(level);

            //Creating the Gaps
            int partsToDisable = 12 - stage.levels[i].partCount;

            List<GameObject> disabledParts = new List<GameObject>();

            while (disabledParts.Count<partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }
         
            List<GameObject> leftParts = new List<GameObject>();
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }

            }


            //Creating the death parts
            List<GameObject> deathParts = new List<GameObject>();

            while (deathParts.Count<stage.levels[i].deathPartCount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];

                if (!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(randomPart);
                }
            }
        }



    }





}
