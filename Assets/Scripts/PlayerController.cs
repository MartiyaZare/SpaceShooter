using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;// unity is intelligent enough to get shotSpawn.transform automatically (because type is transform)
    public float fireRate;

    private float nextFire;
    private float myTime = 0.0F;

    // before updating each frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            shoot(); // for AI
        }
        //if (Input.GetButton("Fire1") && myTime > nextFire)
        //{
        //    nextFire = myTime + fireRate;
        //    //newProjectile = 
        //    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        //    nextFire = nextFire - myTime;
        //    myTime = 0.0F;

        //    gameObject.GetComponent<AudioSource>().Play();
        //}
    }

    public void shoot()
    {
        if (myTime > nextFire){ 
            nextFire = myTime + fireRate;
            //newProjectile = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            nextFire = nextFire - myTime;
            myTime = 0.0F;

            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // for AI
    public void moveLeft(){
        Vector3 movement = new Vector3(-1, 0, 0);
        Rigidbody rigidbody = gameObject.GetComponent("Rigidbody") as Rigidbody;
        rigidbody.position += movement / 5;
        //rigidbody.AddForce(movement * speed);
    }

    // for AI
    public void moveRight()
    {
        Vector3 movement = new Vector3(1, 0, 0);
        Rigidbody rigidbody = gameObject.GetComponent("Rigidbody") as Rigidbody;
        rigidbody.position += movement / 5;
        //rigidbody.AddForce(movement * speed);
    }

    
    // before each physic step
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && myTime > nextFire)
        {
            moveRight(); // for AI
        }
        if (Input.GetKey(KeyCode.LeftArrow) && myTime > nextFire)
        {
            moveLeft(); // for AI
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {

        }
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Rigidbody rigidbody = gameObject.GetComponent("Rigidbody") as Rigidbody;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);// 0.0f is used for unity to know this is a float value
        //rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
            (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
            );

        //rigidbody.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.x * -tilt);
    }
}
