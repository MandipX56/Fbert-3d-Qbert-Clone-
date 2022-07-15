using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Con : MonoBehaviour
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
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Net")
        {
            Destroy(gameObject);
        }


    }


}
