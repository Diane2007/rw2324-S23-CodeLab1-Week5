using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()            //make a singleton
    {
        if (instance == null)   //if the instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);      //don't destroy GameObjectHolder when loading a new scene
            instance = this;    //set instance to this game object
        }
        else
        {                   //if there is already an instance set
            Destroy(gameObject);    //destroy this game object
        }
    }


}
