using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            GameControl.instance.ballOutside();
            Destroy(other.GetComponent<Ball>());
        }
    }
}
