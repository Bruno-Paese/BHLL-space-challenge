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

                string responseBody = "[\r\n    {\r\n        \"Timestamp\": \"1971/04/17 07:00:55\",\r\n        \"Lat\": 48.0,\r\n        \"Long\": 35.0,\r\n        \"Magnitude\": 2.8,\r\n        \"Date\": \"04/17/1971\",\r\n        \"MoonphaseAngle\": 270\r\n    },\r\n    {\r\n        \"Timestamp\": \"1971/05/20 17:25:10\",\r\n        \"Lat\": 42.0,\r\n        \"Long\": -24.0,\r\n        \"Magnitude\": 2.0,\r\n        \"Date\": \"05/20/1971\",\r\n        \"MoonphaseAngle\": 315\r\n    },\r\n    {\r\n        \"Timestamp\": \"1971/07/11 13:24:45\",\r\n        \"Lat\": 43.0,\r\n        \"Long\": -47.0,\r\n        \"Magnitude\": 1.9,\r\n        \"Date\": \"07/11/1971\",\r\n        \"MoonphaseAngle\": 225\r\n    },\r\n    {\r\n        \"Timestamp\": \"1972/01/02 22:29:40\",\r\n        \"Lat\": 54.0,\r\n        \"Long\": 101.0,\r\n        \"Magnitude\": 1.9,\r\n        \"Date\": \"01/02/1972\",\r\n        \"MoonphaseAngle\": 180\r\n    },\r\n    {\r\n        \"Timestamp\": \"1972/09/17 14:35:55\",\r\n        \"Lat\": 12.0,\r\n        \"Long\": 46.0,\r\n        \"Magnitude\": 1.0,\r\n        \"Date\": \"09/17/1972\",\r\n        \"MoonphaseAngle\": 135\r\n    },\r\n    {\r\n        \"Timestamp\": \"1972/12/06 23:08:20\",\r\n        \"Lat\": 51.0,\r\n        \"Long\": 45.0,\r\n        \"Magnitude\": 1.4,\r\n        \"Date\": \"12/06/1972\",\r\n        \"MoonphaseAngle\": 0\r\n    },\r\n    {\r\n        \"Timestamp\": \"1972/12/09 03:50:15\",\r\n        \"Lat\": -20.0,\r\n        \"Long\": -80.0,\r\n        \"Magnitude\": 1.2,\r\n        \"Date\": \"12/09/1972\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1973/02/08 22:52:10\",\r\n        \"Lat\": 33.0,\r\n        \"Long\": 35.0,\r\n        \"Magnitude\": 0.8,\r\n        \"Date\": \"02/08/1973\",\r\n        \"MoonphaseAngle\": 90\r\n    },\r\n    {\r\n        \"Timestamp\": \"1973/03/13 07:56:30\",\r\n        \"Lat\": -84.0,\r\n        \"Long\": -134.0,\r\n        \"Magnitude\": 3.2,\r\n        \"Date\": \"03/13/1973\",\r\n        \"MoonphaseAngle\": 90\r\n    },\r\n    {\r\n        \"Timestamp\": \"1973/06/20 20:22:00\",\r\n        \"Lat\": -1.0,\r\n        \"Long\": -71.0,\r\n        \"Magnitude\": 2.2,\r\n        \"Date\": \"06/20/1973\",\r\n        \"MoonphaseAngle\": 225\r\n    },\r\n    {\r\n        \"Timestamp\": \"1973/10/01 03:58:00\",\r\n        \"Lat\": -37.0,\r\n        \"Long\": -29.0,\r\n        \"Magnitude\": 1.1,\r\n        \"Date\": \"10/01/1973\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1974/02/23 21:16:50\",\r\n        \"Lat\": 36.0,\r\n        \"Long\": -16.0,\r\n        \"Magnitude\": 0.7,\r\n        \"Date\": \"02/23/1974\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1974/03/27 09:11:00\",\r\n        \"Lat\": -48.0,\r\n        \"Long\": -106.0,\r\n        \"Magnitude\": 1.6,\r\n        \"Date\": \"03/27/1974\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1974/04/19 13:35:15\",\r\n        \"Lat\": -37.0,\r\n        \"Long\": 42.0,\r\n        \"Magnitude\": 0.9,\r\n        \"Date\": \"04/19/1974\",\r\n        \"MoonphaseAngle\": 315\r\n    },\r\n    {\r\n        \"Timestamp\": \"1974/05/29 20:42:15\",\r\n        \"Lat\": NaN,\r\n        \"Long\": NaN,\r\n        \"Magnitude\": 0.6,\r\n        \"Date\": \"05/29/1974\",\r\n        \"MoonphaseAngle\": 90\r\n    },\r\n    {\r\n        \"Timestamp\": \"1974/07/11 00:46:30\",\r\n        \"Lat\": 21.0,\r\n        \"Long\": 88.0,\r\n        \"Magnitude\": 2.7,\r\n        \"Date\": \"07/11/1974\",\r\n        \"MoonphaseAngle\": 270\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/01/03 01:42:00\",\r\n        \"Lat\": 29.0,\r\n        \"Long\": -98.0,\r\n        \"Magnitude\": 3.2,\r\n        \"Date\": \"01/03/1975\",\r\n        \"MoonphaseAngle\": 225\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/01/12 03:14:10\",\r\n        \"Lat\": 75.0,\r\n        \"Long\": 40.0,\r\n        \"Magnitude\": 1.7,\r\n        \"Date\": \"01/12/1975\",\r\n        \"MoonphaseAngle\": 0\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/01/13 00:26:20\",\r\n        \"Lat\": -2.0,\r\n        \"Long\": -51.0,\r\n        \"Magnitude\": 1.1,\r\n        \"Date\": \"01/13/1975\",\r\n        \"MoonphaseAngle\": 0\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/02/13 22:03:50\",\r\n        \"Lat\": -19.0,\r\n        \"Long\": -26.0,\r\n        \"Magnitude\": 1.4,\r\n        \"Date\": \"02/13/1975\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/05/07 06:37:05\",\r\n        \"Lat\": -49.0,\r\n        \"Long\": -45.0,\r\n        \"Magnitude\": 1.3,\r\n        \"Date\": \"05/07/1975\",\r\n        \"MoonphaseAngle\": 315\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/05/27 23:29:00\",\r\n        \"Lat\": 3.0,\r\n        \"Long\": -58.0,\r\n        \"Magnitude\": 1.4,\r\n        \"Date\": \"05/27/1975\",\r\n        \"MoonphaseAngle\": 225\r\n    },\r\n    {\r\n        \"Timestamp\": \"1975/11/10 07:52:55\",\r\n        \"Lat\": -8.0,\r\n        \"Long\": 64.0,\r\n        \"Magnitude\": 1.8,\r\n        \"Date\": \"11/10/1975\",\r\n        \"MoonphaseAngle\": 90\r\n    },\r\n    {\r\n        \"Timestamp\": \"1976/01/04 11:18:55\",\r\n        \"Lat\": 50.0,\r\n        \"Long\": 30.0,\r\n        \"Magnitude\": 1.8,\r\n        \"Date\": \"01/04/1976\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1976/01/12 08:18:05\",\r\n        \"Lat\": 38.0,\r\n        \"Long\": 44.0,\r\n        \"Magnitude\": 1.1,\r\n        \"Date\": \"01/12/1976\",\r\n        \"MoonphaseAngle\": 135\r\n    },\r\n    {\r\n        \"Timestamp\": \"1976/03/06 10:12:40\",\r\n        \"Lat\": 50.0,\r\n        \"Long\": -20.0,\r\n        \"Magnitude\": 2.3,\r\n        \"Date\": \"03/06/1976\",\r\n        \"MoonphaseAngle\": 45\r\n    },\r\n    {\r\n        \"Timestamp\": \"1976/03/08 14:42:10\",\r\n        \"Lat\": -19.0,\r\n        \"Long\": -12.0,\r\n        \"Magnitude\": 1.8,\r\n        \"Date\": \"03/08/1976\",\r\n        \"MoonphaseAngle\": 90\r\n    },\r\n    {\r\n        \"Timestamp\": \"1976/05/16 12:32:40\",\r\n        \"Lat\": 77.0,\r\n        \"Long\": -10.0,\r\n        \"Magnitude\": 1.5,\r\n        \"Date\": \"05/16/1976\",\r\n        \"MoonphaseAngle\": 225\r\n    }\r\n]";

                // Parse the JSON array into a list of MoonQuakeModel objects using SimpleJSON.
                List<MoonQuakeModel> moonquakeList = ParseJSON(responseBody);

                // Now you can access the parsed data as a list of objects.
                this.list.GetComponent<ListScript>().createList(moonquakeList);
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
