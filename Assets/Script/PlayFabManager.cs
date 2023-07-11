using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Internal;
using TMPro;
public class PlayFabManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI Skor;
    void Start()
    {
        login();
    }

    void login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeardBoardUpdate, OnError);
    }
    void OnLeardBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull LeaderBoard sent");
    }


    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderBoard, OnError);
    }

    void OnGetLeaderBoard(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }






    public void BirArttýr()
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
        SendLeaderBoard(score);
    }

}
