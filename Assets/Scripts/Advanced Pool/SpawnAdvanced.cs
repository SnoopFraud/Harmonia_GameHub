using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdvanced : MonoBehaviour
{
    [SerializeField]
    private float timetoSpawn = 5f;
    private float timesincespawn;
    private AdvancedPooling objectpool;
    [SerializeField]
    private GameObject prefab;

    private void Start()
    {
        objectpool = FindObjectOfType<AdvancedPooling>();
    }

    private void Update()
    {
        timesincespawn += Time.deltaTime;
        if(timesincespawn >= timetoSpawn)
        {
            GameObject newCritter = objectpool.GetObject(prefab); // spawning object
            newCritter.transform.position = this.transform.position; // spawn sesuai posisi pada spawner
            timesincespawn = 0f; // hitung balik dari 0 sblm spawn lagi
        }
    }

}
