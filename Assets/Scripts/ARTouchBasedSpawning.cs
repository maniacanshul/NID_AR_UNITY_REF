using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTouchBasedSpawning : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(raycastManager.Raycast(Input.mousePosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;
                Instantiate(objectToSpawn, pose.position, pose.rotation);
            }
        }
    }
}
