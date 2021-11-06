using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class MazePlayer : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	public TextMeshProUGUI winText;
	public static float timer;

	public static bool timeStarted = false;
	private float movementX;
	private float movementY;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		winText.text = "";
		Time.timeScale = 1;
	}

	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();

		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			
			winText.text = "Congratulations! You solved the maze!";
			Time.timeScale = 0;
			
		}
	}
	// Update is called once per frame
	void FixedUpdate()
	{

		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}
}