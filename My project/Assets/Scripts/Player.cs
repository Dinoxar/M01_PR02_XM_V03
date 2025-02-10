using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour 
{

    private float vInput;
    private float hInput;

    private Rigidbody _rb;
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    //Bullet Variables
    public GameObject bullet;
    public float bulletSpeed = 100f;
    //Jump variables 
    public Vector3 jump;
    public float jumpVelocity = 10f;
    public bool isGrounded;
    public bool isCollected = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;


        /* 4
        this.transform.Translate(Vector3.forward * vInput * 
        Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,this.transform.position + new Vector3(1, 0, 0),this.transform.rotation) as GameObject;

            Rigidbody bulletRB =  newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
       
        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded && isCollected))
        {
            _rb.AddForce(jump * jumpVelocity, ForceMode.Impulse);
            isGrounded = false;
        }
    }
} 

