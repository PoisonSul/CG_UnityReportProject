using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileLoopingForObj : TileLoopingRNG //���� ����� ����̴�
{
    [SerializeField] float[] objectYPos;
    public override void Update()
    {
        base.Update();
        if (replacing)
        {
            int nextObj = Random.Range(0, objectYPos.Count());
            transform.position = new Vector3(transform.position.x, objectYPos[nextObj], 0);
        }
        else
        {
            //Debug.Log("qqqqqqqqqqqqqqqqqqqq");
        }
    }
}
