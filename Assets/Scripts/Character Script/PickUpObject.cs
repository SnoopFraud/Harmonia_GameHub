using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpObject : MonoBehaviour
{
	public Transform player1;
	public Transform player2;

	[SerializeField]
	private bool hasPlayer1 = false;
	[SerializeField]
	private bool hasPlayer2 = false;


	[SerializeField]
	private bool beingCarriedPlayer1 = false;
	private bool beingCarriedPlayer2 = false;

    void OnTriggerEnter(Collider player)
    {
		if (player.tag == "FirstPlayer")
		{
			hasPlayer1 = true;
		}

		if (player.tag == "SecondPlayer")
		{
			hasPlayer2 = true;
		}
	}

    void OnTriggerExit(Collider player)
    {
		hasPlayer1 = false;
		hasPlayer2 = false;
    }

    void Update()
	{
		if (beingCarriedPlayer1)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarriedPlayer1 = false;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.E) && hasPlayer1)
			{
				GetComponent<Rigidbody>().isKinematic = true;
				transform.parent = player1;
				beingCarriedPlayer1 = true;
				transform.localPosition = Vector3.zero;
				transform.localEulerAngles = Vector3.zero;
			}
		}

		if (beingCarriedPlayer2)
		{
			if (Input.GetKeyDown(KeyCode.Keypad0))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarriedPlayer2 = false;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Keypad0) && hasPlayer2)
			{
				GetComponent<Rigidbody>().isKinematic = true;
				transform.parent = player2;
				beingCarriedPlayer2 = true;
				transform.localPosition = Vector3.zero;
				transform.localEulerAngles = Vector3.zero;
			}
		}
	}
}