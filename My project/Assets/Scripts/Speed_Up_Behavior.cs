using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Up_Behavior : MonoBehaviour 
{
    public GameBehavior gameManager;
    public PlayerBehavior playerBehavior;  // Store the reference to PlayerBehavior

    void Start()
    {               
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        playerBehavior = GameObject.Find("Player").GetComponent<PlayerBehavior>(); // Get the PlayerBehavior of the Player object
    }    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Item collected! Speed Up!");

            // Access moveSpeed via the instance of PlayerBehavior
            playerBehavior.moveSpeed += 10f; // Add 20 to the moveSpeed of the PlayerBehavior instance

            gameManager.Items += 1;
        }
    }
}
