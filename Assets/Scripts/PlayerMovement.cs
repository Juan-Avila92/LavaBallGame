using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D rb;
    
    public Vector2 currentPosition;
    public Vector2 initialPosition;
    
    public float distanceY;
    

    //public Animator anim;
    // Update is called once per frame
    int movState;
    int freState;
    int movStateJ;

    public GameObject groundPoint;

    void Start()
    {
        /*initialPosition.x = 1.96f;
        initialPosition.y = -2.73F;*/
        movStateJ = 2;
        movState = 0;
        freState = 0;
        List<string> a = new List<string>();
        
        FindObjectOfType<AudioManager>().Play("Music");
    }
    // rb.velocity = new Vector2(0, -rb.mass* rb.gravityScale);


    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "Plat")
        {
            if (movState == 1)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                movState = 0;
                freState = 0;

            }
            if (freState == 2)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                movState = 0;
                freState = 0;
                Debug.Log("PUTO");
            }



        }


        if (coll.gameObject.tag == "PlatBlock")
        {
            
            movState = 1;
        }
        Debug.Log(movState);

        if (coll.gameObject.tag == "PlatThr")
        {

            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            movState = 0;
            freState = 2;
            Debug.Log(movState);


        }



        if (coll.gameObject.tag == "EdgeR")
        {
            rb.velocity = new Vector2(-1.8f, 0);
        }



        if (coll.gameObject.tag == "EdgeL")
        {

            rb.velocity = new Vector2(1.8f, 0);
            

        }
    }

    



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlatThr")
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            movState = 1;
            freState = 2;
            Debug.Log("Estado" + movState);
            
            
        }

        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlatThr")
        {

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            movState = 1;
            col.isTrigger = false;


        }


    }




    void FixedUpdate ()
    {

        //
        if (Input.GetKey("d") && movState == 0)
        {
           
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(2.5f, 2);
           
            movState = 1;
            freState = 1;
            Debug.Log(rb.velocity.x);

        }

        if (Input.GetKey("a") && movState == 0)
        {
            
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(-2.5f, 2);
            movState = 1;
            freState = 1;
            Debug.Log(rb.velocity.x);
        }

        if (Input.GetKey(KeyCode.W) && movState == 0 )
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = new Vector2(0, distanceY);
            movState = 1;
            freState = 2;
            

            Debug.Log(Input.GetKey("w"));
        }


        
    }
}
