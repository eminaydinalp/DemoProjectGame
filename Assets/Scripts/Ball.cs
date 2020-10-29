using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	GameObject score;
	GameObject gameManager;

	public GameObject ball1;
	public GameObject ball2;
	public GameObject ball3;
	public GameObject ball4;

	[HideInInspector] public Rigidbody rb;
	[HideInInspector] public Collider col;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	public int clickedOn = 0;
	public int ballCount;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();

		score = GameObject.FindGameObjectWithTag("score");
		gameManager = GameObject.FindGameObjectWithTag("manager");

		DesactivateRb();
	}

	IEnumerator DestroyBall()
	{
		yield return new WaitForSeconds(2);

		if (ballCount == 5)
		{
			gameObject.SetActive(false);
		}
		if (score.GetComponent<Score>().holeCount == 3)
		{
			gameObject.SetActive(false);
		}
		else
		{
			StartCoroutine(CreateBall());
		}
	}

	public void Push(Vector3 force)
	{
		Debug.Log(force);
		rb.AddForce(force, ForceMode.Impulse);
		ballCount++;
		SymbolDestroy();

		StartCoroutine(DestroyBall());
	}

	void SymbolDestroy()
	{
		if (ballCount == 2)
		{
			ball4.SetActive(false);
		}

		if (ballCount == 3)
		{
			ball3.SetActive(false);
		}

		if (ballCount == 4)
		{
			ball2.SetActive(false);
		}

		if (ballCount == 5)
		{
			ball1.SetActive(false);
		}
	
	}

	

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.isKinematic = true;
	}
	

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "yer")
		{
			score.GetComponent<Score>().BoardContact();
			StartCoroutine(CreateBall());
		}

		if(col.gameObject.tag == "delik")
		{
			score.GetComponent<Score>().HoleContact();
			StartCoroutine(CreateBall());

		}
	}

	IEnumerator CreateBall()
	{
		yield return new WaitForSeconds(1.5f);
		
		DesactivateRb();
		if(ballCount<5 || score.GetComponent<Score>().holeCount < 3)
		{
			transform.position = new Vector3(-9f, 18.8f, -17.1f);

		}
	}

	
}
