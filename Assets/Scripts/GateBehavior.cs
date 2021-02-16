using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    private int scoreSystem;
    private Vector3 pos;
    private float speed;
    private float movingFactor;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        speed = 0.0f;
        movingFactor = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreSystem = UIText.score;

        // score 0 -> no movement
        // score 1 or 2 -> slow movement
        // score more than 2 -> fast movement


        if (scoreSystem == 0 )
        {
            speed = 0.0f;
        }
        else if (scoreSystem ==1)
        {
            speed = 5.0f;
        }
        else if (scoreSystem == 2)
        {
            speed = 8.0f;
        }
        else
        {
            speed = 12.0f;
        }

        if (transform.position.x > 20.0 || transform.position.x < -20.0)
        {
            movingFactor *= -1.0f;
        }

        pos.x += movingFactor * speed;
        transform.position = pos;

    }
   
}
