using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script prevents the object from being destroyed and keeps the global data storage
 */
public class DontDestroy : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        if (player == null)
        {
            player = gameObject;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
