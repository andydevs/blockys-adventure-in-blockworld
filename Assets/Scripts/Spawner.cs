using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject characterPrefab;

        void Start()
        {
            GameStateController.OnSpawn += Spawn;
        }

        public void Spawn()
        {
            Instantiate(characterPrefab, transform.position, Quaternion.identity);
        }
    }
}
