using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebServiceClient : MonoBehaviour
{
    [Serializable]
    public class MetroidVaniaScore 
    {
        public int Id;
        public string PlayerName;
        public float Score;
    }

    UnityWebRequest www;

    const string webServiceURL = "localhost:8888/request";
   
   public IEnumerator SendWebRequest(float score)
    {
       
       MetroidVaniaScore newScore = new MetroidVaniaScore();

       newScore.Id = 20;
       newScore.PlayerName = "Joha";
       newScore.Score = score;

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

       Debug.Log(www.downloadHandler.text);
    }

}
