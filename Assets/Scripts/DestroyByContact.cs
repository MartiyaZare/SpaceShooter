using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        if(other.tag != "Player") { // changed for learning
            Destroy(other.gameObject);//does not immediately destroy, marks to destroy in end of frame, so destroy sequence is not important
            Destroy(gameObject);
            gameController.addScore(scoreValue);
        }
        

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
    }
}
