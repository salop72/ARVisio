using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

//Everytime we try to add a script to a Gameobject it is going to add a RayCast automatically for us
[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    //A prefab to a GameObject to instantiate??
    [SerializeField]
    private GameObject placedPrefab;

    //Property so we can access this from anywhere
    public GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

    private ARRaycastManager arRaycastManager;

    //Keep track of when somebody touches the screen, using arrayCast to see if we are colliding with the plane that we created 
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    //Keep track of when somebody touches the screen, using arrayCast to see if we are colliding with the plane that we created 
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        //With the out (el de arriba) vamos a obtener el true y la posición del toque
        //We are counting touches and somebody is touching the screen
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(0).position;
            //if we are touching the screen and we get the position
            return true;

        }
        touchPosition = default;
        return false;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        }
    }

    //Track where the hits are happening
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}
