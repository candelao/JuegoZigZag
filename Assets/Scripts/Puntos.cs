using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public Text Contador;
    // Start is called before the first frame update
    void Start()
    {
        Contador.text = "" + GameManager.instance.TotalEstrellas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
