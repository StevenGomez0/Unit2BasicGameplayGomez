using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collisions : MonoBehaviour
{
    public bool isProjectile;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //makes it so if the object is pizza, does not get destroyed upon contact w/player
        if (isProjectile == true)
        {
            return;
        }
        else
        {
            //destroys if collides with another collider w/rigidbody
            Destroy(gameObject);
        }
    }
}
