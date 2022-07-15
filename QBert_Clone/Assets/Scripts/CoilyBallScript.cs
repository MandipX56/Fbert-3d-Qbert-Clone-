using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyBallScript : MonoBehaviour
{
    public Transform Snakebody;
    Rigidbody ball_rigidbody;
    
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


        if (gameObject.transform.position.y == -6)
        {
            ball_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(spawnSnakeBody());
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
        if (other.gameObject.tag == "Net")
        {
            Destroy(gameObject);
            
        }

    }


    IEnumerator spawnSnakeBody()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Snakebody, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Snakebody.rotation);
    }

}
