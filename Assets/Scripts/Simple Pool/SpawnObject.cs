using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private float timetoSpawn = 5f;
    private float timesincespawn;
    private PoolingObject objectpool;

    private void Start()
    {
        objectpool = FindObjectOfType<PoolingObject>();
    }

    private void Update()
    {
        timesincespawn += Time.deltaTime;
        if(timesincespawn >= timetoSpawn)
        {
            GameObject newcritter = objectpool.GetCritter();
            newcritter.transform.position = this.transform.position;
            timesincespawn = 0f;
        }
    }

}
