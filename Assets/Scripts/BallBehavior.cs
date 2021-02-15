using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject followCamera;
    [SerializeField]
    private float velocity;

    private Rigidbody m_rigidbody;
    [SerializeField]
    Vector3 initialVelocity;
    [SerializeField]
    private float angle;

    public BallPool ballPool;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Acos(Vector3.Dot(followCamera.transform.forward, Vector3.right) / (followCamera.transform.forward.magnitude) * (Vector3.right.magnitude));

        if (Input.GetMouseButtonUp(0))
        {
            LaunchBall();
        }
        CheckBounds();
    }
    void LaunchBall()
    {
        // compute angle
        // a.b = abcos 
        // cos = a.b/ ab
        //angle = arcCos(a.b/ab)
       
        // vx, vy
        initialVelocity.x = velocity * Mathf.Cos(angle);
        initialVelocity.y = velocity * Mathf.Sin(angle);
        initialVelocity.z = velocity * Mathf.Sin(angle);

        m_rigidbody.velocity = initialVelocity;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 15 );
        Gizmos.DrawLine(followCamera.transform.position, followCamera.transform.position + followCamera.transform.forward * 15);
    }
    private void CheckBounds()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > 80)
        {
            ballPool.ReturnBall(this.gameObject);
        }
    }
}
