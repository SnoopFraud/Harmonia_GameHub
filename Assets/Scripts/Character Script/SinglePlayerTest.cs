using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerTest : MonoBehaviour
{
    //For basic movement 
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float groundDistance = 0.4f;

    //For smooth rotation towards movement
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    //For gravity implementation
    [SerializeField] private float gravityValue = -9.8f;
    Vector3 playervelocity;
    bool groundedPlayer;

    //For grab object on ground
    [SerializeField] private bool isDetected;
    [SerializeField] private bool isGrabed;
    public Transform grabSlot;
    GameObject objectToPickUp;

    // Update is called once per frame
    void Update()
    {
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playervelocity.y < 0)
        {
            playervelocity.y = 0f;
        }

        playervelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playervelocity * Time.deltaTime);

        
        if(isGrabed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dropItem();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && isDetected)
            {
                pickUpItem();
            }
        }
        
    }

    private void OnTriggerEnter(Collider item)
    {
        if(item.gameObject.tag == "Food" || item.gameObject.tag == "Drink")
        {
            isDetected = true;
            objectToPickUp = item.gameObject;
        }
    }

    private void OnTriggerExit(Collider item)
    {
        isDetected = false;
    }

    void pickUpItem()
    {
        objectToPickUp.transform.parent = grabSlot;
        objectToPickUp.transform.localPosition = Vector3.zero;
        objectToPickUp.transform.localEulerAngles = Vector3.zero;
        isGrabed = true;
        objectToPickUp.GetComponent<Rigidbody>().isKinematic = true;
    }

    void dropItem()
    {
        objectToPickUp.GetComponent<Rigidbody>().isKinematic = false;
        objectToPickUp.transform.parent = null;
        isGrabed = false;
    }
}
