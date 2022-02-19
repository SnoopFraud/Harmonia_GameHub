using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    [SerializeField] GameObject CritterPrefab; //get prefab
    [SerializeField] private Queue<GameObject> CritterPool = new Queue<GameObject>(); //Hold ref to all game object
    
    public GameObject GetCritter()
    {
        if(CritterPool.Count > 0) //check if if there's a CritterPrefab for pool
        {
            GameObject critter = CritterPool.Dequeue(); 
            critter.SetActive(true);
            return critter;
        }
        else //if empty
        {
            GameObject critter = Instantiate(CritterPrefab); //will make new instant
            return critter;
        }
    }

    public void ReturnCritter(GameObject critter)
    {
        CritterPool.Enqueue(critter);
        critter.SetActive(false);
    }
}
