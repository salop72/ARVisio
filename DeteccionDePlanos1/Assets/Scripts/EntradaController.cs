using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntradaController : MonoBehaviour
{
    public GameObject OtherWorld;
    public Material[] materials;
    private Vector3 camPosition;
    bool front;
    bool OtroMundo;
    bool hasCollided;
    // Start is called before the first frame update
    void Start()
    {
        SetMaterials(false); 
    }

    void SetMaterials(bool active)
    {
        var stencilTest = active ? CompareFunction.NotEqual : CompareFunction.Equal;

        foreach (var mat in materials)
        {
            mat.SetInt("_StencilComp", (int)stencilTest);
        }

        
    }
    bool GetIsFron()
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 worldPos = MainCamera.transform.position + MainCamera.transform.forward * Camera.main.nearClipPlane;
        camPosition = transform.InverseTransformPoint(worldPos);
        return camPosition.y >= 0 ? true : false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (collider.transform != MainCamera.transform)
            return;
        front = GetIsFron();
        hasCollided = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (collider.transform != MainCamera.transform)
            return;
        hasCollided = false;
    }

    void whileCameraCollindig()
    {
        if (!hasCollided)
            return;
        bool isFront = GetIsFron();

        if ((isFront && !front) || (front && !isFront))
        {
            OtroMundo = !OtroMundo;
            SetMaterials(OtroMundo);
        }
        front = isFront;
    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }
    // Update is called once per frame
    void Update()
    {
        whileCameraCollindig();
    }
}
