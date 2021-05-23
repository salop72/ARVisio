using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslation : MonoBehaviour
{
    public string centro = "Sol";
    GameObject Centro;
    public float distancia = 0.05f;
    public float angulo = 0;
    public float velocidad = 10;
    // Start is called before the first frame update
    void Start()
    {
        angulo = Random.Range(0, 25);
    }

    // Update is called once per frame
    void Update()
    {
        Centro = GameObject.Find(centro);
        transform.position = new Vector3(Centro.transform.position.x + distancia * Mathf.Cos(angulo*Mathf.Deg2Rad), transform.position.y, Centro.transform.position.z + distancia * Mathf.Sin(angulo * Mathf.Deg2Rad));
        angulo += velocidad*Time.deltaTime;
    }
}
