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

    bool nextOrder;

    // Start is called before the first frame update
    void Start()
    {
        RandomOrder();
        nextOrder = false;
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

        if(nextOrder)
        {
            RandomOrder();
        }
    }

    private void OnTriggerEnter(Collider Item)
    {
        if(Item.tag == RandomFood)
        {
            Destroy(Item.gameObject);
            nextOrder = true;
        }
    }

    void RandomOrder()
    {
        int randomIndex = Random.Range(0, food.Length);
        string randomName = food[randomIndex];
        NameRandom = randomName;
        nextOrder = false;
    }
}
