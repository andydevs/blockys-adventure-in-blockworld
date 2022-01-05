using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        public GameObject blockyPrefab;

        void Start()
        {
            GameStateController.OnSpawnABlocky += SpawnABlocky;
            SpawnABlocky();
        }

        public void SpawnABlocky()
        {
            Instantiate(blockyPrefab, transform.position, Quaternion.identity);
        }
    }
}