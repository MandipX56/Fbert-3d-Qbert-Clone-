using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Instructions"); 
        }


        if (Input.GetKey("enter"))
        {
            Application.Quit();
            Debug.Log("it's working!");
        }


    }
}
