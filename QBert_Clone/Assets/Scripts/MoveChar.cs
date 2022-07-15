using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour 
{
	public string midjump = "n";
	public AudioSource deathSound; 

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

        if ((Input.GetKeyDown("z") || Input.GetKeyDown("1")) && (midjump =="n")) 
		{
			midjump = "y";
			transform.eulerAngles = new Vector3(0, -180, 0);
			GetComponent<Rigidbody>().velocity= new Vector3(0,4,-1); 
		}

		if ((Input.GetKeyDown("e") || Input.GetKeyDown("9")) && (midjump == "n"))
		{
			midjump = "y";
			transform.eulerAngles = new Vector3(0, 0, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
		}

		if ((Input.GetKeyDown("c") || Input.GetKeyDown("3")) && (midjump == "n"))
		{
			midjump = "y";
			transform.eulerAngles = new Vector3(0, -270, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
		}

		if ((Input.GetKeyDown("q") || Input.GetKeyDown("7")) && (midjump == "n"))
		{
			midjump = "y";
			transform.eulerAngles = new Vector3(0, -90, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
		}
	}

	private void OnTriggerEnter(Collider other)
    {
		if(other.tag=="Net")
        {
			GetComponent<Transform>().position = new Vector3(0, 1, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			gameflow.remaingLives -= 1;
			gameflow.isLifeIcon -= 1; 
			gameflow.roundNo += 1;
			Debug.Log(gameflow.remaingLives);
			deathSound.Play();
		}
		if (other.tag=="Right")
        {
			midjump = "y";
			transform.eulerAngles = new Vector3(0, -180, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
		}
		if (other.tag == "Left")
		{
			midjump = "y";
			transform.eulerAngles = new Vector3(0, -270, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
		}
	}

	private void OnCollisionEnter(Collision other)
    {

		if (other.gameObject.tag == "Tile")
		{ 
		StartCoroutine(delayMove());
		}

		if (other.gameObject.tag == "EnemyFrog")
        {
			deathSound.Play();
			gameflow.resetBoard = "y";
			gameflow.remaingLives -= 1;
			gameflow.isLifeIcon -= 1;
			gameflow.roundNo += 1;
			GetComponent<Transform>().position = new Vector3(0, 1, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			StartCoroutine(delayReset());

		}

		if (other.gameObject.tag == "Coily")
		{
			deathSound.Play();
			gameflow.resetBoard = "y";
			gameflow.remaingLives -= 1;
			gameflow.isLifeIcon -= 1;
			gameflow.roundNo += 1;
			GetComponent<Transform>().position = new Vector3(0, 1, 0);
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			StartCoroutine(delayReset());

		}

		//if (other.gameObject.tag == "EnemyFrog3")
        //{
		//	StartCoroutine (delayMoveEnemy());
		//}


	}
	IEnumerator delayMoveEnemy()
    {
		//GameObject.FindGameObjectsWithTag("EnemyFrog");
		//GameObject.FindGameObjectsWithTag("Enemyfrog2");
		//GameObject.FindGameObjectsWithTag("Coily");
		yield return new WaitForSeconds(30f);

	}

	IEnumerator delayMove()
    {
		yield return new WaitForSeconds(.05f);
		midjump = "n";

	}

	IEnumerator delayReset()
    {
		yield return new WaitForSeconds(.1f);
		gameflow.resetBoard = "n"; 
    }


}
