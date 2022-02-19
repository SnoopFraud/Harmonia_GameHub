using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterReturnAdvanced : MonoBehaviour
{

    private AdvancedPooling objectpool;

    // Start is called before the first frame update
    void Start()
    {
        objectpool = FindObjectOfType<AdvancedPooling>();
    }

    public void OnDisable()
    {
        if(objectpool != null)
        {
            objectpool.ReturnGameObject(this.gameObject);
        }
    }
}
