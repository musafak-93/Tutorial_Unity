using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSettings : MonoBehaviour
{
    public Text TextTimer1;
    public float Waktu = 100; //01:30
    float s;
    public static bool GameAktif1 = false;
    public GameObject CanvasKalah;

    void SetText1()
    {
        //Untuk Settings Teks
        int Menit = Mathf.FloorToInt(Waktu / 60); //01
        int Detik = Mathf.FloorToInt(Waktu % 60); //30
        TextTimer1.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }


    private void Update()
    {
        if (GameAktif1)
        {
            //Untuk Set Time berjalan
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        //Kondisi saat waktu habis
        if (GameAktif1 && Waktu <= 0)
        {
            Debug.Log("Game Kalah");
            CanvasKalah.SetActive(true);
            GameAktif1 = false;
        }

        SetText1();
    }

    public void StopBtn()
    {
        GameAktif1 = !GameAktif1;
        if (GameAktif1)
        {
            //Time.timeScale = 0;
            //Untuk Set Time berjalan
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
            }
        } 
        else if (!GameAktif1)
        {
            //Time.timeScale = 1;
            GameAktif1 = false;
            WaktuSettings.GameAktif2 = true;
        }
    }
}
