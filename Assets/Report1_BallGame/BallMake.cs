using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMake : MonoBehaviour
{
    public GameObject gong;
    public float repeatRate = 0.5f;

    private float currentRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeBall), 0.5f, repeatRate);
        currentRate = repeatRate;
    }

    void Update()
    {
        if (currentRate != repeatRate)
        {
            CancelInvoke();
            InvokeRepeating(nameof(MakeBall), 0.5f, repeatRate);
            currentRate = repeatRate;
        }
    }

    void MakeBall()
    {
        Instantiate(gong,new Vector3(Random.Range(-6,6),gameObject.transform.position.y,gameObject.transform.position.z), Quaternion.identity , gameObject.transform);
    }
}
