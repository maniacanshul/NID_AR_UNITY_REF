using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionHandler : MonoBehaviour
{
    [SerializeField] private ARTouchBasedSpawning spawner;
    [SerializeField] private ARPlaneManager arPlaneManager;

    public void ARSessionEstablished()
    {
        arPlaneManager.enabled = true;
        spawner.enabled = true;
    }
}
