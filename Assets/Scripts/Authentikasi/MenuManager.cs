using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel[1].SetActive(false);
        Panel[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangePanel(int index)
    {

        //element o login panel & element 1 register panel
        if(index == 1)
        {
            Panel[0].SetActive(true);
            Panel[1].SetActive(false);
        }

        if (index == 2)
        {
            Panel[1].SetActive(true);
            Panel[0].SetActive(false);
        }
    }
}
