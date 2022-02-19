using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{
    public GameObject prefab;
    private AdvancedPooling objectpool;

    private void Start()
    {
        objectpool = FindObjectOfType<AdvancedPooling>();
    }

    public void GetButton()
    {
        GameObject newCritter = objectpool.GetObject(prefab); // spawning object
        newCritter.transform.position = this.transform.position; // spawn sesuai posisi pada spawner
    }

}
