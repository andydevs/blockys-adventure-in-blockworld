using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject blockyPrefab;

    GameObject blockyInstance;

    void Start()
    {
        SpawnABlocky();
    }

    void SpawnABlocky()
    {
        blockyInstance = Instantiate(blockyPrefab, transform.position, Quaternion.identity);
    }

    public void Notify()
    {
        Debug.Log("Rip Blocky");
        SpawnABlocky();
    }
}
