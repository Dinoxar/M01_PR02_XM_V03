using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onscreenDelay = 1.5f;
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }

    void Update()
    {
        
    }
}
