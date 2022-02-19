using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private AdvancedPooling objectpool;
    public bool SpawnFood;
    [SerializeField]
    private GameObject Prefab; 

    private void Start()
    {
        objectpool = FindObjectOfType<AdvancedPooling>();

    }

    private void Update()
    {
        if (SpawnFood == true)
        {
            GameObject newcritter = objectpool.GetObject(Prefab);
            newcritter.transform.position = this.transform.position;
        }

        if (SpawnFood == false)
        {

        }

    }

    private void OnTriggerEnter(Collider food)
    {
        if(food.gameObject.tag == "Food")
        {
            SpawnFood = false;
        }
    }

    private void OnTriggerExit(Collider food)
    {
        if(food.gameObject.tag == "Food")
        {
            SpawnFood = true;
        }
        
    }

    void SpawnMethod()
    {
        if (SpawnFood == true)
        {
            
        }
    }


}
