using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float myVelocity = 2.5f;

    public double num = 3.735;


    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        //Show Instruction game on debug tab

        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arror keys");
    }

    void MovePlayer()
    {
        //Transform.Translate(xValue, yValue, zValue);

        if (this.CompareTag("FirstPlayer"))
        {
            //1st player
            float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            transform.Translate(xValue, 0, zValue);
        }

        if (this.CompareTag("SecondPlayer"))
        {
            //2nd player
            float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            transform.Translate(xValue, 0, zValue);
        }
    }
}
