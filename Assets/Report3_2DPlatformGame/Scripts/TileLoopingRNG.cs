using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileLoopingRNG : TileLooping
{
    //public float endPos = -20f;
    //public float startPos = 20f;
    //public float speed = 5f;
    private bool isInvoked = false;

    // Update is called once per frame
    public override void Update()
    {
        if (this.transform.position.x > endPos)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (this.transform.position.x < startPos && !isInvoked)
        {
            isInvoked = true;
            Invoke(nameof(RePlaceNow),Random.Range(0.1f, 2f));
            //InvokeRepeating(nameof(RePlaceNow
        }
    }

    private void RePlaceNow()
    {
        transform.position = new Vector3(startPos, 0, 0);
        isInvoked = false;
    }
}
