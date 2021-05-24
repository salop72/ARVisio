using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Txt_catedral : MonoBehaviour
{
    public TextMeshProUGUI txt;
    [TextArea(4, 40)]
    public string[] parrafos;
    int index;
    public float verparrafo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TxtDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            txt.text += letra;

            yield return new WaitForSeconds(verparrafo);
        }
    }

    public void activarPanel()
    {
        txt.text = "";
        StartCoroutine(TxtDialogo());
    }
}
