using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterReturn : MonoBehaviour
{
    private PoolingObject objectpool;

    private void Start()
    {
        objectpool = FindObjectOfType<PoolingObject>();

    }

    private void OnDisable()
    {
        if(objectpool != null)
        {
            objectpool.ReturnCritter(this.gameObject);
        }
    }

}
