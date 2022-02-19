using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingMask : MonoBehaviour
{
    [SerializeField] private LayerMask indoorMask;
    [SerializeField] private LayerMask outdoorMask;
    Camera MainCamera;

    public GameObject outdoorLight;
    public GameObject indoorLight;
    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        MainCamera.cullingMask = outdoorMask;
        indoorLight.SetActive(false);
        outdoorLight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        MainCamera.cullingMask = indoorMask;
        indoorLight.SetActive(true);
        outdoorLight.SetActive(false)
;    }
}
