using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_ArquiMuseo : MonoBehaviour
{
    public GameObject panelDgl;//Para el cuadro de informacion
    public GameObject btnCerrarInfo; //Para cerrar la descripcion

    Txt_Eiffel torreEifl;
    Txt_libertad stlibertad;
    Txt_catedral iglCatedral;
    Txt_Piramide piramide;

    // Start is called before the first frame update
    void Start()
    {
        panelDgl.SetActive(false);
        btnCerrarInfo.SetActive(false);
        torreEifl = GameObject.FindGameObjectWithTag("TorreEifl").GetComponent<Txt_Eiffel>();
        stlibertad = GameObject.FindGameObjectWithTag("StLibertad").GetComponent<Txt_libertad>();
        iglCatedral = GameObject.FindGameObjectWithTag("IglCatedral").GetComponent<Txt_catedral>();
        piramide = GameObject.FindGameObjectWithTag("Piramide").GetComponent<Txt_Piramide>();
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
                            case "effiel":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                torreEifl.activarPanel();
                                break;
                            case "StatueLibert":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                stlibertad.activarPanel();
                                break;
                            case "IglCatedral":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                iglCatedral.activarPanel();
                                break;
                            case "Kheopspiram":
                                panelDgl.SetActive(true);
                                btnCerrarInfo.SetActive(true);
                                piramide.activarPanel();
                                break;
                        }
                    }
                }
            }
        }
    }
}
