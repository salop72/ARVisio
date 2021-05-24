using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_PlaneMuseo : MonoBehaviour
{

    public GameObject panelDgl;//Para el cuadro de informacion
    public GameObject btnCerrarInfo; //Para cerrar la descripcion

    Txt_Sol sol;
    Txt_Tierra tierra;
    Txt_Estacion iss;
    Txt_Traje traje;


    // Start is called before the first frame update
    void Start()
    {
        panelDgl.SetActive(false);
        btnCerrarInfo.SetActive(false);
        sol = GameObject.FindGameObjectWithTag("Sol").GetComponent<Txt_Sol>();
        tierra = GameObject.FindGameObjectWithTag("Tierra").GetComponent<Txt_Tierra>();
        iss = GameObject.FindGameObjectWithTag("iss").GetComponent<Txt_Estacion>();
        traje = GameObject.FindGameObjectWithTag("Traje").GetComponent<Txt_Traje>();
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
                            case "SolEstante":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                sol.activarPanel();
                                break;
                            case "TierraPEs":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                tierra.activarPanel();
                                break;
                            case "iss":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                iss.activarPanel();
                                break;
                            case "g_SpaceX_Suit_LowRes:SpaceXSuit_low_SpaceX_Suit_LowRes:SpaceXSuit_low":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                traje.activarPanel();
                                break;
                        }
                    }
                }
            }
        }
    }
}
