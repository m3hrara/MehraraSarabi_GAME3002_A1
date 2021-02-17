using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject followCamera;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float angle;
    [SerializeField]
    private Transform ballSpawn;
    //private GameObject target;
    private Rigidbody m_rigidbody;
    private Vector3 initialVelocity;
    private int tries = 0;
    private bool isGrounded = true;
    //private Vector3 targetPos;
    private int frameCounter = 0;    // to respawn the ball
    // Start is called before the first frame update
    void Start()
    {
        //CreateTarget();
        m_rigidbody = GetComponent<Rigidbody>();
        transform.position = ballSpawn.position;
    }
    //void CreateTarget()
    //{
    //    target = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    //    target.transform.position = Vector3.zero;
    //    target.transform.localScale = new Vector3(3.0f, 0.1f, 3.0f);
    //    target.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

    //    target.GetComponent<Renderer>().material.color = Color.red;
    //    target.GetComponent<Collider>().enabled = false;
    //}
    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Acos(Vector3.Dot(followCamera.transform.forward, Vector3.right) / (followCamera.transform.forward.magnitude) * (Vector3.right.magnitude));
        //targetPos.x = 2 * velocity * velocity * Mathf.Cos(angle) * Mathf.Sin(angle) / Mathf.Abs(Physics.gravity.y);
        //targetPos.y = 1.0f;
        //targetPos.z = 2 * velocity * velocity * Mathf.Cos(angle) * Mathf.Sin(angle) /Physics.gravity.y * Mathf.Cos(angle);
        //target.transform.position = targetPos;
        if (Input.GetMouseButtonUp(1) && isGrounded && tries < 5) // right click to launch the ball, 5 tries
        {
            LaunchBall();
            isGrounded = false;
        }
        if (tries == 5)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void LaunchBall()
    {
        // compute angle
        // a.b = abcos 
        // cos = a.b/ ab
        //angle = arcCos(a.b/ab)
       
        // vx, vy, vz
        initialVelocity.x = velocity * Mathf.Cos(angle);
        initialVelocity.y = velocity * Mathf.Sin(angle) * 0.5f;
        initialVelocity.z = velocity * Mathf.Sin(angle);
        m_rigidbody.velocity = initialVelocity;
        
    }
    void FixedUpdate()
    {
        CheckFrame(); // check to see if its time for respawning the ball yet
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 15 );
        Gizmos.DrawLine(followCamera.transform.position, followCamera.transform.position + followCamera.transform.forward * 15);
    }
    private void CheckFrame()
    {
        if (!isGrounded)
        {
            frameCounter++;
        }
        if (frameCounter >= 280)
        {
            transform.position = ballSpawn.position;
            m_rigidbody.velocity = Vector3.zero;
            isGrounded = true;
            tries++;
            frameCounter = 0;
        }
    }
}
