using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class FoodMeter : MonoBehaviour
{
    static public float health = 3;
    public RectTransform foodMeter;
    private float currentHealth = health;
    private float originalHealth;
    public GameObject parentAnimal;

    void Start()
    {
        foodMeter = GetComponent<RectTransform>();
        originalHealth = health;
    }
    void Update()
    {
        if (currentHealth != health)
        {
            foodMeter.sizeDelta = new Vector2(100 * (health / originalHealth), foodMeter.sizeDelta.y);
            if (health == 0)
            {
                Destroy(parentAnimal);
            }
        }
    }
}
