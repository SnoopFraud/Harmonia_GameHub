using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRecognition : MonoBehaviour
{
    public string[] food;
    string NameRandom;
    public string RandomFood;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, food.Length);
        string randomName = food[randomIndex];
        NameRandom = randomName;
    }

    // Update is called once per frame
    void Update()
    {
        RandomFood = NameRandom;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == RandomFood)
        {
            Destroy(other.gameObject);
        }
    }
}
