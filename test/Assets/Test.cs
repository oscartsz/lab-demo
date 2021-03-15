using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject player1;
    public Transform spawn;
    GameObject test;
    bool die = false;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        
        Instantiate(player1, spawn.transform.position, Quaternion.identity);
    }

    public void Die(int d)
    {
        if (d == 1)
            die = true;
    }

    void Update()
    {
        test = GameObject.FindGameObjectWithTag("Player");
        if (die == true)
        {
            DestroyImmediate(test);
            Invoke("Respawn", 2);
            die = false;
        }
            
    }

    void Respawn()
    {
        Instantiate(player1, spawn.transform.position, Quaternion.identity);
        
    }


}
