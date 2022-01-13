using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject characterPrefab;

        // Handle for if character is still alive
        private GameObject character;

        void Start()
        {
            GameStateController.OnSpawn += Spawn;
            Spawn();
        }

        private void OnDestroy()
        {
            GameStateController.OnSpawn -= Spawn;
        }

        public void Spawn()
        {
            if (character == null)
            {
                character = Instantiate(
                    characterPrefab, 
                    transform.position, 
                    Quaternion.identity);
            }
        }
    }
}
