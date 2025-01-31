using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool cooldown;
    public float cooldownTimer;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cooldown == false)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                cooldown = true;
                Invoke("ResetCooldown", cooldownTimer);
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
