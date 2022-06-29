using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField usernameField;
    public InputField emailField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        /*        WWWForm form = new WWWForm();
                form.AddField("username", usernameField.text);
                form.AddField("email", emailField.text);
                form.AddField("password", passwordField.text);
                UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
                yield return www.SendWebRequest();

                if (www.isDone)
                {
                    var result = www.downloadHandler.text;

                    Debug.Log(result);

                    if (result != "0")
                    {
                        Debug.Log(result);
                    }
                    else
                    {
                        Debug.Log("Erorr");
                    }
                }*/
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;


        //ketika data masuk
        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            /*UnityEngine.SceneManagement.SceneManager.LoadScene(0);*/
        }
        else
        {
            Debug.Log("User creation failed. Erorr #" + www.text);
        }
    }

    //untuk validasi button jika tidak disi maka tidak dapat di klik
    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 8 && emailField.text.Length >= 8 && passwordField.text.Length >=8);
    }
}
