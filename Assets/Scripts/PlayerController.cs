using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	private Rigidbody rb;

	public float speed;

	private GvrController controller;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){

		if (GvrController.IsTouching) {
			
			float moveHorizontal = GvrController.ArmModel.pointerPosition.x;
			float moveVertical = GvrController.ArmModel.pointerPosition.z;
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * speed);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
