using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_BritishMuseo : MonoBehaviour
{

    public GameObject panelDgl;//Para el cuadro de informacion
    public GameObject btnCerrarInfo; //Para cerrar la descripcion

    Txt_Emperador empRomano;
    Txt_Magno magno;
    Txt_EsculturaMex escMex;


    // Start is called before the first frame update
    void Start()
    {
        panelDgl.SetActive(false);
        btnCerrarInfo.SetActive(false);
        empRomano = GameObject.FindGameObjectWithTag("Emperador").GetComponent<Txt_Emperador>();
        magno = GameObject.FindGameObjectWithTag("Magno").GetComponent<Txt_Magno>();
        escMex = GameObject.FindGameObjectWithTag("EsculturaMex").GetComponent<Txt_EsculturaMex>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    // Construct a ray from the current touch coordinates
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hit;
                    // Create a particle if hit
                    if (Physics.Raycast(ray, out hit))
                    {
                        string name;
                        name = hit.collider.name;
                        switch (name)
                        {
                            case "Emperador":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                empRomano.activarPanel();
                                break;
                            case "Magno":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                magno.activarPanel();
                                break;
                            case "EsculturaMex":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                escMex.activarPanel();
                                break;
                        }
                    }
                }
            }
        }
    }
}
