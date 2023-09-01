// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class FurniturePlacementManager : MonoBehaviour
// {
//     public GameObject SpawanableFurniture;

//     public ARSessionOrigin sessionOrigin;
//     public ARRaycastManager raycastManager;
//     public ARPlaneManager planeManager;
//     private List<ARRaycastHit> raycastHits=new List<ARRaycastHit>();

//     private void Update(){
//         if(Input.touchCount>0){
//             if(Input.GetTouch(0).phase==TouchPhase.Began){
//                 bool collision=raycastManager.Raycast(Input.GetTouch(0).position, raycastHits, TrackableType.PlaneWithinPolygon);

//                 if(collision && isButtonPressed()==false){
//                 //if(collision ){
//                     GameObject _object =Instantiate(SpawanableFurniture);
//                     _object.transform.position=raycastHits[0].pose.position;
//                     _object.transform.rotation=raycastHits[0].pose.rotation;
//                 }

//                 foreach(var planes in planeManager.trackables){
//                     planes.gameObject.SetActive(false);
//                 }

//                 planeManager.enabled=false;
//             }
//         }
//     }

//     public bool isButtonPressed(){
//         if(EventSystem.current.currentSelectedGameObject?.GetComponent<Button>()==null ){
//             return false;
//         }
//         else{
//             return true;
//         }
//     }

//     public void SwitchFurniture(GameObject furniture){
//         SpawanableFurniture=furniture;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurniturePlacementManager : MonoBehaviour
{
    public GameObject SpawanableFurniture;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        // Check if a button is pressed
        if (isButtonPressed())
        {
            return; // Skip furniture placement if a UI button is pressed
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Perform raycast to detect planes
                if (raycastManager.Raycast(Input.GetTouch(0).position, raycastHits, TrackableType.PlaneWithinPolygon))
                {
                    // Create and place the furniture
                    GameObject _object = Instantiate(SpawanableFurniture);
                    _object.transform.position = raycastHits[0].pose.position;
                    _object.transform.rotation = raycastHits[0].pose.rotation;
                }
            }
        }
    }

    public bool isButtonPressed()
    {
        // Check if a UI button is currently selected
        return EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() != null;
    }

    public void SwitchFurniture(GameObject furniture)
    {
        SpawanableFurniture = furniture;
    }
}
