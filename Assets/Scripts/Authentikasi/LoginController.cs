using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UserProperty
{
    public string name;
    public string username;
    public string score;
}

public class LoginController : MonoBehaviour
{
    //membuat variabel untuk inputfield Login
    public InputField username;
    public InputField Password;

    //membuat variabel untuk inputfield register
    public InputField myName;
    public InputField myUsername;
    public InputField myPassword;
    public InputField myComPass;

    public Text erorrMessage;

    public string[] Url;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PerformLogin()
    {
        StartCoroutine(login());
    }

    IEnumerator login()
    {
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("email", username.text);
        loginForm.AddField("pass", Password.text);

        UnityWebRequest www = UnityWebRequest.Post(Url[0], loginForm);
        yield return www.SendWebRequest();

        if(www.isDone)
        {
            var result = www.downloadHandler.text;

            Debug.Log(result);

            if(result != "0")
            {
                UserProperty user = new UserProperty();

                user = JsonUtility.FromJson<UserProperty>(result);

                PlayerPrefs.SetString("name", user.name);
                PlayerPrefs.SetString("score", user.score);
                PlayerPrefs.SetString("username", user.username);

                Debug.Log("my name is :" + user.name);

                SceneManager.LoadScene("MenuAuthentikasi");
            }
            else
            {
                erorrMessage.text = "Login Gagal";
                Debug.Log("Erorr");
            }
        }
    }



    public void PerformRegister()
    {
        if(myPassword.text == myComPass.text)
        {
            StartCoroutine(Register());
        }
        else
        {
            Debug.LogWarning("Password must be same confirm password");
        }
    }

    IEnumerator Register()
    {
        WWWForm registerForm = new WWWForm();
        registerForm.AddField("email", myUsername.text);
        registerForm.AddField("pass", myPassword.text);
        registerForm.AddField("name", myName.text);

        UnityWebRequest www = UnityWebRequest.Post(Url[1], registerForm);
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
        }
    }
}
