using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 50.0f;
    private float lowerBound = -10;
    private float sideBounds = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If an object goes past the player's view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound || transform.position.x > sideBounds || transform.position.x < -sideBounds)
        {
            //if animal goes past view, lives -1
            PlayerController.minusLife();
            Destroy(gameObject);
        }
    }
}
