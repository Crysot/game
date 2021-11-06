using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class CollectorPlayer : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI lifeText;
	public TextMeshProUGUI winText;
	public TextMeshProUGUI ponitsRemaining;
	public static float timer;
	public static bool timeStarted = false;
	private float movementX;
	private float movementY;
	private int points;
	private int life;
	private int count;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Time.timeScale = 1;
		count = 0;
		life = 3;
		points = 44;
		SetCountText();
		winText.text = "";
	}

    void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x;
		movementY = movementVector.y;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			points--;
			SetCountText();
		}
	}
	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barricade"))
		{
			life--;
			this.transform.position = new Vector3(0, 2 , 0);
			SetCountText();
		}
	}

	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		ponitsRemaining.text = "Points Remaining: " + points.ToString();
		if (count >= 44)
		{
			winText.text = "You won!";
			Time.timeScale = 0;
		}
		lifeText.text = "Remaining life: " + life.ToString();
		if (life == 0)
		{
			winText.text = " Game Over! Sorry kaaaamo,) ";
			Time.timeScale = 0;
		}
	}
}