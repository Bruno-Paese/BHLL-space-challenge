using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class DataGetter : MonoBehaviour
{

    string apiUrl = "https://moonquake-api.azurewebsites.net";
    public GameObject list;

    void Start()
    {
        StartCoroutine(MakeGetRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     List<MoonQuakeModel> ParseJSON(string json)
    {
        List<MoonQuakeModel> moonquakeList = new List<MoonQuakeModel>();
        JSONArray jsonArray = JSON.Parse(json).AsArray;

        foreach (JSONNode node in jsonArray)
        {
            MoonQuakeModel moonquake = new MoonQuakeModel
            {
                timestamp = node["Timestamp"],
                lat = node["Lat"].AsFloat,
                lon = node["Long"].AsFloat,
                magnitude = node["Magnitude"].AsFloat,
                date = node["Date"]
            };

            moonquakeList.Add(moonquake);
        }

        return moonquakeList;
    }

    private IEnumerator MakeGetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl + "/quakes"))
        {
            Debug.Log(apiUrl + "/quakes");
            // Send the GET request
            yield return webRequest.SendWebRequest();

            // Check for errors during the request
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("GET request failed: " + webRequest.error);
            }
            else
            {
                // Process the response data
                string responseBody = webRequest.downloadHandler.text;
                // Parse the JSON array into a list of MoonQuakeModel objects using SimpleJSON.
                List<MoonQuakeModel> moonquakeList = ParseJSON(responseBody);

                // Now you can access the parsed data as a list of objects.
                this.list.GetComponent<ListScript>().createList(moonquakeList);

            }
        }
    }
}
