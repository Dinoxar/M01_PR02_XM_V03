using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Up_Behavior : MonoBehaviour 
{
    public GameBehavior gameManager;
    public PlayerBehavior playerBehavior;
    void Start()
    {              
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        playerBehavior = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }    
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name == "Player")
        {

            Destroy(this.transform.parent.gameObject);

            Debug.Log("Item collected! Jump");

            playerBehavior.isCollected = true;

            gameManager.Items += 1;
        }
    }
} 
