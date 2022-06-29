using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("my name is " + PlayerPrefs.GetString("name ") + "and my score is: " + PlayerPrefs.GetString("score"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
