using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy3Con : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {

    }

    
    // Update is called once per frame
    void Update()
    {
        if (gameflow.resetBoard == "y")
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (Random.Range(0, 2) == 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -270, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }

       


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fbert")
        {
            gameflow.totalScore += 100;
            Debug.Log(gameflow.totalScore);
            StartCoroutine(delayMoveEnemy());
            Destroy(gameObject);
        }


        if (other.gameObject.tag == "Net")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator delayMoveEnemy()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(30f);
        Time.timeScale = 1;
        //gameflow.GetComponent<Rigidbody>(gameObject.tag = "EnemyFrog").velocity = Vector3.zero;

    }
}



