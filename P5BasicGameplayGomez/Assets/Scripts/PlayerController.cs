using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 10;

    public GameObject foodProjectile;
    // Start is called before the first frame update
    void Start()
    {

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

        //horizontal movement using unity axi
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pizza shooting
            Instantiate(foodProjectile, transform.position, foodProjectile.transform.rotation);
        }
    }
}
