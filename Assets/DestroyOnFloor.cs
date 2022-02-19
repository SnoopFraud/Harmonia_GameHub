using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFloor : MonoBehaviour
{
    public float Timer = 3.0f;
    public float TimeLeft;
    public bool TimerOn;

    private AdvancedPooling objectpool;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = false;
        objectpool = FindObjectOfType<AdvancedPooling>();
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
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            TimerOn = true;
        }
    }
    private void OnCollisionExit(Collision floor)
    {
        TimerOn = false;
    }

    private void OnDisable()
    {
        if (objectpool != null)
        {
            objectpool.ReturnGameObject(this.gameObject);
        }
    }
}
