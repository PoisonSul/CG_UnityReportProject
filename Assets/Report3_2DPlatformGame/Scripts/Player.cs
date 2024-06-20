using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    private bool jumping = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ParticleSystem particle;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.ShapeModule shapeModule;

    private Vector2 prePos;
    private bool onWater = false;
    private bool onGround = false;
    [SerializeField] float baseXPos = -2.7f;
    private float lerpXPos = 0f;
    public bool onFlank = false;

    [SerializeField] Camera Camera;
    [SerializeField] float baseCamSize = 2.5f;
    [SerializeField] float flankSpeedSize = 5f;
    private float lerpCamSize = 0f;


    // Start is called before the first frame update
    void Start()
    {
        emissionModule = particle.emission;
        shapeModule = particle.shape;
        prePos = transform.position;
        Camera.orthographicSize = baseCamSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumping)
            {
                jumping = true;
                animator.SetBool("jumpReady", true);
            }
        }
        else
        {
            if (jumping) //?
            {
                jumping = false;
                animator.SetBool("jumpReady", false);
                animator.SetBool("goingUp", true);
                emissionModule.rateOverTime = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, 7f), ForceMode2D.Impulse);
                //animator.SetBool("goingUp", true);
            }
        }



        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("flankSpeed", true);
            lerpCamSize = Mathf.Lerp(Camera.orthographicSize, flankSpeedSize , 1f * Time.deltaTime);
            Camera.orthographicSize = lerpCamSize;
            if (!onFlank)
            {
                onFlank = true;
                if(SpeedManager.Instance.reversing)
                { 
                    SpeedManager.Instance.AddSpeedToAll(-2f);
                }
                else
                {
                    SpeedManager.Instance.AddSpeedToAll(2f);
                }
            }
            //GameMAnager.Instance.BonusOn();
            //SpeedManager.Instance.AddSpeedToAll(2f);
        }
        else if (onFlank) //아마 문제있음
        {
            animator.SetBool("flankSpeed", false);
            //lerpCamSize = Mathf.Lerp(Camera.orthographicSize, baseCamSize, 5f * Time.deltaTime);
            //Camera.orthographicSize = lerpCamSize;
            if (SpeedManager.Instance.reversing)
            {
                SpeedManager.Instance.AddSpeedToAll(2f);
            }
            else
            {
                SpeedManager.Instance.AddSpeedToAll(-2f);
            }
            onFlank = false;
            //GameMAnager.Instance.BonusOn(false);
        }
        else
        {
            lerpCamSize = Mathf.Lerp(Camera.orthographicSize, baseCamSize, 5f * Time.deltaTime);
            Camera.orthographicSize = lerpCamSize;
        }

        //if (transform.position.y > prePos.y) //velocity는 중력값을 포함하므로 참고
        //{
        //    animator.SetBool("goingUp", false);
        //    animator.SetBool("goingDown", true);
        //}
        //if (transform.position.y <= prePos.y)
        //{
        //    animator.SetBool("goingDown", false);
        //}
        if (onWater)
        {
            animator.SetBool("goingDown", false);
        }
        else if (transform.position.y < prePos.y)
        {
            animator.SetBool("goingUp", false);
            animator.SetBool("goingDown", true);
        }

        if (transform.position.x < prePos.x)
        {
            Debug.LogWarning("going back");
            SpeedManager.Instance.ReverseSpeedToAll();
            shapeModule.angle = 90f;
            particle.Emit(10000);
            GameMAnager.Instance.UseLive();
            transform.position = new Vector2(-10f,-2f);
            shapeModule.angle = 11.87f;
            //particle.Emit(10000);
        }

        lerpXPos = Mathf.Lerp(transform.position.x,baseXPos, 1f * Time.deltaTime);

        if (transform.position.x <= baseXPos && !onGround)
        {
            transform.position = new Vector2(lerpXPos,transform.position.y);
        }

        prePos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onWater = true;
        //Debug.Log(collision.gameObject.name.ToString());
        if (collision.gameObject.name == "GroundCollision")
        {
            emissionModule.rateOverTime = 100;
            onGround = false;
        }
        else if (collision.gameObject.name == "ObjectLayer")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onWater = false;
    }


}
