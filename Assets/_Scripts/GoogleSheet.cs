using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class GoogleSheet : MonoBehaviour
{
    public Dictionary<int, int> NumEnergyShieldsDataHandler = new();
    public Dictionary<int, float> DragonSpeedDataHandler = new();
    public Dictionary<int, float> DragonTimeBetweenEggDropsDataHandler = new();
    public Dictionary<int, float> DragonLeftRightDistanceDataHandler = new();

    public IEnumerator LoadData()
    {
        UnityWebRequest curentResp = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1RTjNz9ZCV2A4FhTNOj5D7DxRNzzhk2XX6rvUGnqdFHc/values/Лист1?key=AIzaSyCVDGzNYhH6hayj7appMIA9-3WSx0JKvso");
        yield return curentResp.SendWebRequest();

        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);
        int i = 0;
        foreach (var itemRawJson in rawJson["values"])
        {
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;

            if (i == 2)
            {
                for (int j = 0; j < LevelController.LevelCount; j++)
                {
                    Debug.Log(j);
                    NumEnergyShieldsDataHandler[j + 1] = int.Parse(selectRow[j]);
                    DragonSpeedDataHandler[j + 1] = float.Parse(selectRow[j + LevelController.LevelCount]);
                }
            }
            if(i == 16)
            {
                for (int j = 0; j < LevelController.LevelCount; j++)
                {
                    DragonTimeBetweenEggDropsDataHandler[j + 1] = float.Parse(selectRow[j]);
                    DragonLeftRightDistanceDataHandler[j + 1] = float.Parse(selectRow[j + LevelController.LevelCount]);
                }
            }
            i+=1;
        }
        
        foreach(var key in NumEnergyShieldsDataHandler.Keys)
            Debug.Log(key);
    }
}
