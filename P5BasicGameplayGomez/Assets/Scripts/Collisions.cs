using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collisions : MonoBehaviour
{
    public bool isProjectile;
    private void OnTriggerEnter(Collider other)
    {
        //destroys if collides with another object w/rigidbody (if its the player, score does not increase
        if (other.gameObject.tag.Equals("Player") == false)
        {
            PlayerController.Score();
            Destroy(gameObject);
        }

                
    }
}
