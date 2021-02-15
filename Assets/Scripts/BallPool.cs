using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public GameObject ball;
    public Queue<GameObject> m_ballPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBallPool();
    }

    private void _BuildBallPool()
    {
        m_ballPool = new Queue<GameObject>();

        for (int count = 0; count < 1; count++)
        {
            var tempBall = Instantiate(ball);
            tempBall.transform.SetParent(transform);
            tempBall.SetActive(false);
            m_ballPool.Enqueue(tempBall);
        }
    }

    public GameObject GetBall(Vector3 position)
    {
        GameObject newBall = null;
        newBall = m_ballPool.Dequeue();
        newBall.SetActive(true);
        newBall.transform.position = position;

        return newBall;
    }

    public bool HasBalls()
    {
        return m_ballPool.Count > 0;
    }

    public void ReturnBall(GameObject returnedBall)
    {
        returnedBall.SetActive(false);
        m_ballPool.Enqueue(returnedBall);
    }

}