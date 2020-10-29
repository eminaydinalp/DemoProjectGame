using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Camera cam;

    GameObject ball;
	GameObject trajectory;

	public Button startButton;

    [SerializeField] float pushForce = 4f;

    bool isDragging = false;
	public bool start = false;

    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 direction;
    Vector3 force;
    float distance;


    void Start()
    {
		startButton.onClick.AddListener(StartButton);
		cam = Camera.main;

		ball = GameObject.FindGameObjectWithTag("ball");
        //ball.GetComponent<Ball>().DesactivateRb();

		trajectory = GameObject.FindGameObjectWithTag("trajectory");
		
    }

	public void StartButton()
	{
		StartCoroutine(StartWait());
		startButton.gameObject.SetActive(false);
	}

	IEnumerator StartWait()
	{
		yield return new WaitForSeconds(1);
		start = true;
	}

	void Update()
	{
	
		if (Input.GetMouseButtonDown(0) && start)
		{

			isDragging = true;
			OnDragStart();
		}
		if (Input.GetMouseButtonUp(0) && start)
		{
			isDragging = false;
			OnDragEnd();
		}

		if (isDragging)
		{
			OnDrag();
		}
	}

	
	void OnDragStart()
	{
		ball.GetComponent<Ball>().DesactivateRb();
		startPoint = new Vector3(-9f, 18.8f, -17.1f);
		Debug.Log("cc");

		trajectory.GetComponent<Trajectory>().Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
		distance = Vector3.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
	
		force = direction * distance * pushForce;

		
		Debug.DrawLine(startPoint, endPoint);

		trajectory.GetComponent<Trajectory>().UpdateDots(ball.GetComponent<Ball>().pos, force);
	}

	void OnDragEnd()
	{
		
		ball.GetComponent<Ball>().ActivateRb();

		ball.GetComponent<Ball>().Push(force);

		trajectory.GetComponent<Trajectory>().Hide();
	}


}
