using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastTouch : MonoBehaviour
{
    public GameObject particle;
    
    // Start is called before the first frame update

    private bool iniciar;
    //void Start()
    //{
    //    
    //}

    public void ActivarMenu()
    {
        StartCoroutine(ExecuteAfterTime(1));
    }

    // Update is called once per frame
    void Update()
    {
        if(iniciar==true)//activar el menú
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
                            if (hit.collider.name == "Portal11")
                                SceneManager.LoadScene(1);
                            if (hit.collider.name == "Portal22")
                                SceneManager.LoadScene(2);
                            if (hit.collider.name == "Portal33")
                                SceneManager.LoadScene(3);
                        }
                    }
                }
            }
    }

    IEnumerator ExecuteAfterTime(float time)//Tiempo de retraso para activar el menú
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        iniciar = true;
    }
    
}
