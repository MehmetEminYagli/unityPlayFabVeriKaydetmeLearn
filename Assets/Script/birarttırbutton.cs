using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class birarttırbutton : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI Skor;
    private PlayFabManager playFab;
    void Start()
    {
        playFab = GetComponent<PlayFabManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BirArttır()
    {
        score++;
        Skor.text = score.ToString();
    }
    public void Eksilt()
    {
        score--;
        Skor.text = score.ToString();
    }

    public void gameover()
    {
        playFab = GetComponent<PlayFabManager>();
        playFab.SendLeaderBoard(score);
    }
}
