using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float bounceSpeed = 6f;

    private bool isOutside = false;
    private bool borderCollision = false;
    private bool wallCollision = false;
    private bool topWallCollision = false;
    private Rigidbody2D rb2d;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = new Vector2(Random.Range(-10, 10), -10);
        while(direction.y == 0)
        {
            direction.y = Random.Range(-10, 10);
        }
        direction.Normalize();
        rb2d = GetComponent<Rigidbody2D> ();
        rb2d.velocity = direction * bounceSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		if(isOutside == false)
        {
            if(borderCollision)
            {
                direction.x *= -1;
                rb2d.velocity = direction * bounceSpeed;
                borderCollision = false;
            }

            if (wallCollision)
            {
                direction.y *= -1;
                bounceSpeed += 0.3f;
                rb2d.velocity = direction * bounceSpeed;
                wallCollision = false;
            }

            if (topWallCollision)
            {
                direction.y *= -1;
                rb2d.velocity = direction * bounceSpeed;
                topWallCollision = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.transform.gameObject.name == "Border") { 
            borderCollision = true;
        }
        else if(target.transform.gameObject.name == "Wall(Clone)")
        {
            wallCollision = true;
            GameControl.instance.ballScored();
        }
        else if (target.transform.gameObject.name == "TopWall")
        {
            topWallCollision = true;
        }
    }
}
