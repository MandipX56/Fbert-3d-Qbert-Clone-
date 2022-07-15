using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCon : MonoBehaviour 
{

	public Material GreenColor;
	public Material WhiteColor;
	public int colorStatus = 1;
	public AudioSource tileSounds;
	public AudioClip changeColorSound; 
	public AudioClip noColorChangeSound;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.tag == "Fbert")
	    { 
		  colorStatus -= 1;
		  if(colorStatus == 0)
		  { 
		  GetComponent<Renderer>().material = GreenColor;
		  gameflow.remainingTiles -= 1;
		  gameflow.totalScore += 25;
		  Debug.Log(gameflow.totalScore);
				tileSounds.clip = changeColorSound;
				tileSounds.Play(); 

		  }
		  else
            {
				tileSounds.clip = noColorChangeSound;
				tileSounds.Play();

			}

		  if(colorStatus<0)
            {
				colorStatus = 0;

            }

	    }


		if (other.gameObject.tag == "Enemyfrog2")
		{
			colorStatus += 1;
			if (colorStatus == 1)
			{
				GetComponent<Renderer>().material = WhiteColor;
				gameflow.remainingTiles += 1;
				tileSounds.clip = noColorChangeSound;
				tileSounds.Play();
			}

			if (colorStatus > 1)
			{
				colorStatus = 1;
				tileSounds.clip = noColorChangeSound;
				tileSounds.Play();

			}

		}

		if (other.gameObject.tag == "EnemyFrog")
		{
				tileSounds.clip = noColorChangeSound;
				tileSounds.Play();
		}

		if (other.gameObject.tag == "EnemyFrog3")
		{
				tileSounds.clip = noColorChangeSound;
				tileSounds.Play();
		}

		if (other.gameObject.tag == "Coily")
		{
			tileSounds.clip = noColorChangeSound;
			tileSounds.Play();
		}



	}

}
