using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/sqlconnect/webtest.php");
        yield return request;
        string[] webresults = request.text.Split('\t');
        Debug.Log(webresults[0]);
        int webNumber = int.Parse(webresults[1]);
        webNumber *= 2;
        Debug.Log(webNumber);
    }
}
