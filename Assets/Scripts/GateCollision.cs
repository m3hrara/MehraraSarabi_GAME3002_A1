using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
           UIText.score++;
        }
    }
}
