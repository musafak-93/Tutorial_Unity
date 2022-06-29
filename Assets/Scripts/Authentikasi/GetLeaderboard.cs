using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using System;


[Serializable]
public class UserProperti
{
    public string name;
    public string score;
}

[Serializable]
public class ObjectProperty
{
    public UserProperti[] myUsers;
}
public class GetLeaderboard : MonoBehaviour
{

    public Text[] LeaderboardText;
    public string Url;
    List<UserProperti> ListBoard = new List<UserProperti>();

    ObjectProperty s = new ObjectProperty();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLeader());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GetLeader()
    {

        UnityWebRequest www = UnityWebRequest.Get(Url);
        yield return www.SendWebRequest();

        if (www.isDone)
        {
            var result = www.downloadHandler.text;

            Debug.Log(result);

            if (result != "0")
            {
                var JsonArrayString = "{\"myUsers\":" + result + "}";
                s = JsonUtility.FromJson<ObjectProperty>(JsonArrayString);
                //Debug.Log(JsonArrayString);
                for (int i = 0; i < s.myUsers.Length; i++)
                {
                    ListBoard.Add(new UserProperti { name = s.myUsers[i].name, score = s.myUsers[i].score });
                }

                ShowLeaderboard();
            }
            else
            {
                Debug.Log("Erorr");
            }
        }
    }

    public void ShowLeaderboard() 
    {
        LeaderboardText[0].text = ListBoard.ElementAt(0).name + " score : " + ListBoard.ElementAt(0).score;
        LeaderboardText[1].text = ListBoard.ElementAt(1).name + " score : " + ListBoard.ElementAt(1).score;
        LeaderboardText[2].text = ListBoard.ElementAt(2).name + " score : " + ListBoard.ElementAt(2).score;
    }
}
