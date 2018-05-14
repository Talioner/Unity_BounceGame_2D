using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public GameObject wallPrefab;
    public float wallLifeTime = 0.2f;

    private GameObject wall;
    private Vector2 wallPosition = new Vector2(-0.02f, -1.85f);
    private Vector2 spawnPosition = new Vector2(-15f, -25f);
    private float timeSinceClicked;

	// Use this for initialization
	void Start () {
        timeSinceClicked = 0;
        wall = (GameObject)Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) && timeSinceClicked > 0.4f)
        {
            wall.transform.position = wallPosition;
            timeSinceClicked = 0f;
        }
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began && timeSinceClicked > 0.4f)
                {
                    wall.transform.position = wallPosition;
                    timeSinceClicked = 0f;
                }
            }
        }

        timeSinceClicked += Time.deltaTime;
        if (timeSinceClicked > wallLifeTime)
        {
            wall.transform.position = spawnPosition;
        }
    }
}
