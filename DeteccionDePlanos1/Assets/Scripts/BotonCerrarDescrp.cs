using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonCerrarDescrp : MonoBehaviour
{
    //Objetos para descrbir los modelos
    public GameObject panelDescrp; // Panel de Descripcion
    public TextMeshProUGUI txt; // texto de descripcion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonCerrar()
    {
        txt.text = "";
        panelDescrp.SetActive(false);
    }
}
