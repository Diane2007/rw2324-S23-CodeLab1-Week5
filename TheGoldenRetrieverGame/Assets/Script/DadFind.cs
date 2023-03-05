using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DadFind : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D dadCol)
    {
        if (dadCol.gameObject.name.Contains("Lulu"))
        {
            GameManager.instance.GetComponent<ASCIILevelLoader>().ResetDoggo();
        }
    }
}
