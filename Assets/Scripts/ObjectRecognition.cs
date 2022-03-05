using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRecognition : MonoBehaviour
{
    public string[] food;
    public Sprite[] icon;

    public Image iconSource;

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
        if(RandomFood == "Food")
        {
            iconSource.sprite = icon[0];
        }
        else if (RandomFood == "Drink")
        {
            iconSource.sprite = icon[1];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == RandomFood)
        {
            Destroy(other.gameObject);
        }
    }
}
