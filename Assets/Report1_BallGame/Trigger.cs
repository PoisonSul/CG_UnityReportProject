using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("qqq");
        switch (other.name.ToString())
        {
            case "BaDak +point":
                //Debug.Log("10point");
                score.AddToScore(10);
                break;

            case "BaDak -point":
                score.AddToScore(-5);
                break;

            default:
                break;
        }
    }
}
