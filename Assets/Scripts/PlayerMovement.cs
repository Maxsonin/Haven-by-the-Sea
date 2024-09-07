using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed;

	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rigid;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.freezeRotation = true;
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MyInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void Update()
	{
		MyInput();
	}

	private void MovePlayer()
	{
		// calculate Movement Direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		rigid.AddForce(moveDirection.normalized * moveSpeed * 10.0f, ForceMode.Force);
	}
}
