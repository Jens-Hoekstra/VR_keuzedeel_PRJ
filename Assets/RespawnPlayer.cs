using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject respawnpoint;
         void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            { 
                other.gameObject.transform.position = respawnpoint.transform.position;
            }
    }
}
