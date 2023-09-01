using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlantPlacementMananger : MonoBehaviour
{
    public GameObject[] flowers;

    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    public void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Shoot Raycast
            //Place Objects Randomly
            //Disable the Planes and the Plane Manager

            bool collison = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);
            if (collison)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                _object.transform.position = raycastHits[0].pose.position;
            }

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;

        }
    }
}
