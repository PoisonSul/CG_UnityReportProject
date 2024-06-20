using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TileLooping : MonoBehaviour
{
    public float endPos = -26f;
    public float startPos = 26f;
    public float speed = 5f;
    // Start is called before the first frame update
    //void Start()
    //{
    //    Camera camera = GetComponent<Camera>();
    //    camera.backgroundColor = new Color(255, 255, 255);
    //}

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= endPos)
        {
            transform.position = new Vector3(startPos, 0, 0);
        }
        else
        {
            Move();
        }
    }

    public void Move()
    {
        if (this.transform.position.x > endPos) //?
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void SpeedChange(float speedAdd)
    {
        //speed = Mathf.Lerp(speed, endPos, speed); invoke?
        speed += speedAdd;
    }

    public void SpeedReverse()
    {
        Debug.Log("qq");
        speed *= -1;
    }

    public void SpeedStop()
    {
        speed = 0;
    }
}
