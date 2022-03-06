using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispencerActivator : MonoBehaviour
{
    [SerializeField] private bool readytopick = false;
    public GameObject Food;
    
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        readytopick = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        readytopick = true;
    }

    private void OnTriggerExit(Collider other)
    {
        readytopick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readytopick)
        {
            Instantiate(Food, spawnPosition.transform.position, spawnPosition.transform.rotation);
        }
    }

    void Spawn()
    {
        Instantiate(Food, spawnPosition.transform.position, spawnPosition.transform.rotation);
    }
}
