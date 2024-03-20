using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10f;
    private float xRange = 10;
    private float zRange = 10;
    public GameObject foodProjectile;
    public int lives = 3;
    public int score = 0;

    private void Start()
    {
        Debug.Log("Lives = " + lives);
        Debug.Log("Score = " + score);
    }
    // Update is called once per frame
    void Update()
    {
        //if player x is larger/smaller than xRange, teleports to x=10 (or x= -10 if negative)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        //horizontal movement using unity axi
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pizza shooting
            Instantiate(foodProjectile, transform.position, foodProjectile.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //makes it so colliding with pizza does not take lives
        if (other.gameObject.tag.Equals("projectile") == true)
        {
            return;
        }
        else
        {
            lives--;
            Debug.Log("Lives = " + lives);
            if (lives == 0)
            {
                Debug.Log("Game Over!");
            }
        }
    }

    public void Score()
    {
        score++;
        Debug.Log("Score = " + score);
    }
}
