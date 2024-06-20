using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileLoopingRNG : TileLooping
{
    //public float endPos = -20f;
    //public float startPos = 20f;
    //public float speed = 5f;
    public bool isInvoked = false;
    public bool replacing = false;

    // Update is called once per frame
    public virtual void Update()
    {
        //if (this.transform.position.x > endPos)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        //else if (this.transform.position.x < startPos && !isInvoked)
        //{
        //    isInvoked = true;
        //    Invoke(nameof(RePlaceNow),Random.Range(0.1f, 2f));
        //    //InvokeRepeating(nameof(RePlaceNow
        //}

        if(this.transform.position.x <= endPos && !isInvoked)
        {
            isInvoked = true;
            Invoke(nameof(RePlaceNow), Random.Range(0.1f, 4f));
            replacing = true;
            //InvokeRepeating(nameof(RePlaceNow
        }
        else
        {
           Move();
           replacing = false;
        }
    }

    private void RePlaceNow()
    {
        transform.position = new Vector3(startPos, transform.position.y, 0);
        isInvoked = false;
    }
}
