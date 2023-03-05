using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBurger : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D burgerCol)
    {
        GameManager.instance.GetComponent<ASCIILevelLoader>().EatBurger();
    }
}
