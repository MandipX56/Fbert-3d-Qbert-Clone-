using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameflow : MonoBehaviour 
{
	public static int remainingTiles = 28;
	public Transform Enemy1Obj;
	public Transform Enemy2Obj;
	public Transform Enemy3Obj;
	public Transform Coilyball;
	public Transform Coily;


	public static int remaingLives = 3;
	public static string resetBoard = "n";
	public static int totalScore = 0;
	public Text PlayerScoreTxt;
	public static int roundNo = 1;
	public Text RoundNo;
	public static int levelNo = 1;
	public Text LevelNo; 
	public bool spawnCoilysnake;



	public static int isLifeIcon = 2;
	public Image Lifeimg1;
	public Image Lifeimg2;

	// Use this for initialization
	void Start () 
	{

		StartCoroutine(spawnEnemy1());
		StartCoroutine(spawnEnemy2());
		StartCoroutine(spawnEnemy3());
		StartCoroutine(spawnCoily());


	}
	
	// Update is called once per frame
	void Update () 
	{

		if (remainingTiles==0)
        {
			Debug.Log("You WIN!!!");
			StartCoroutine(loadNextLevel());
		
        }
		
		if(remaingLives<1)
        {
			SceneManager.LoadScene("GameOver");
			remaingLives = 3; 
			totalScore = 0;
			isLifeIcon = 2;
			remainingTiles = 28;
			StartCoroutine(spawnEnemy1());
			StartCoroutine(spawnEnemy2());
			StartCoroutine(spawnEnemy3());
			StartCoroutine(spawnCoily());
		}

		PlayerScoreTxt.text = totalScore.ToString();
		RoundNo.text = roundNo.ToString();
		LevelNo.text = levelNo.ToString();


		if (Input.GetKey("enter"))
		{
			Application.Quit();
		}


		// UI life icons 
		if (isLifeIcon==1)
        {
			Destroy(Lifeimg1);
			
        }

		if (isLifeIcon == 0)
		{
			Destroy(Lifeimg1);
			Destroy(Lifeimg2);
			
		}

		if(spawnCoilysnake == true)
        {
			StopCoroutine(spawnCoily());
			spawnCoilysnake = false;
		}


	}

    IEnumerator loadNextLevel()
    {
		yield return new WaitForSeconds(3);
		remainingTiles = 28;
		totalScore += 1000;
		levelNo += 1; 
		Debug.Log(totalScore);
		SceneManager.LoadScene("MainGame");
		StartCoroutine(spawnEnemy1());
		StartCoroutine(spawnEnemy2());
		StartCoroutine(spawnEnemy3());
		StartCoroutine(spawnCoily());

	}

	IEnumerator spawnEnemy1()
    {
		yield return new WaitForSeconds(9); //9 for game
		Instantiate(Enemy1Obj, new Vector3(0, 2, -1), Enemy1Obj.rotation);
		StartCoroutine(spawnEnemy1());
	}

	IEnumerator spawnEnemy2()
	{
		yield return new WaitForSeconds(17); //17 for game
		Instantiate(Enemy2Obj, new Vector3(1, 0, 0), Enemy2Obj.rotation);
		StartCoroutine(spawnEnemy2());
	}

	IEnumerator spawnEnemy3()
	{
		yield return new WaitForSeconds(12); //12 for game
		Instantiate(Enemy3Obj, new Vector3(1, 0, -1), Enemy3Obj.rotation);
		StartCoroutine(spawnEnemy3());
	}

	IEnumerator spawnCoily()
	{
		yield return new WaitForSeconds(20); //20 for game 
		spawnCoilysnake = true; 
		Instantiate(Coilyball, new Vector3(0, 3, 0), Coilyball.rotation);
		//StartCoroutine(spawnCoily());
	}




}
