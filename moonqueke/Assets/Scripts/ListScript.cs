using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListScript : MonoBehaviour
{
    public GameObject visualizer, cameraObject;
    public GameObject buttonPrefab;
    private int initalyCoord = 240;
    private int increment = -30;

    public void createList(List<MoonQuakeModel> moonquakes)
    {
        foreach(var quake in moonquakes)
        {
            createButton(quake);
        }
    }

    void createButton(MoonQuakeModel quake)
    {
        Vector3 pos = Vector3.zero;
        pos.y = initalyCoord + increment;
        initalyCoord = initalyCoord + increment;

        GameObject go = Instantiate(buttonPrefab);
        go.transform.SetParent(this.transform, true);
        go.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => onClick(quake));
        go.GetComponentInChildren<TextMeshProUGUI>().text = quake.timestamp;
        go.transform.localPosition = pos;
        go.transform.localScale = Vector3.one;
        go.transform.localRotation = Quaternion.identity;
    }
    void onClick(MoonQuakeModel quake)
    {
        visualizer.GetComponent<MoonquakeVisualization>().CreateMarker(quake.lat, quake.lon, quake.timestamp);
       // cameraObject.GetComponent<CameraScript>().PositionCameraAtLongitudeAndLatitude(quake.lon, quake.lat, 1f);

    }
}
