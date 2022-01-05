using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public class FallDetector : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                Debug.Log("You DAAAAA!");
                other.GetComponent<PlayerController>().Kill();
            }
        }
    }
}