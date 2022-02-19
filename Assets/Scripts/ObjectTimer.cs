using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTimer : MonoBehaviour
{
    public float Timer = 3.0f;
    public float TimeLeft;
    public bool TimerOn;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn == false)
        {
            TimeLeft = Timer;
        }

        if (TimerOn == true)
        {
            TimeLeft -= Time.deltaTime;
        }

        if (TimeLeft < 0)
        {
            Destroy(gameObject); //ide gw kalo misalnya bisa bikin objectnya ilang tanpa harus destroy
            //[Dequeue disini] -> prefab harus akses pooling yg ada
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            TimerOn = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        TimerOn = false;
    }
}
