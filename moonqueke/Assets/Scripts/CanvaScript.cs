using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class DataGetter : MonoBehaviour
{

    string apiUrl = "https://moonquake-api.azurewebsites.net";

    void Start()
    {
        StartCoroutine(MakeGetRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Debug.Log("Response content:");
                Debug.Log(responseBody);
            }
        }
    }
}
