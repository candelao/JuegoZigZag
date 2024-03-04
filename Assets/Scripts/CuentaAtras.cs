using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{

    private Button boton;
    public Image imagen;
    public Sprite[] numeros;
    // Start is called before the first frame update
    void Start()
    {
        boton = GameObject.FindAnyObjectByType<Button>();
        boton.onClick.AddListener(Empezar);
    }

    void Empezar()
    {
        imagen.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);
        StartCoroutine(Cuentaatras());
    }

    IEnumerator Cuentaatras()
    {
        for (int i = 0; i< numeros.Length; i++)
        {
            imagen.sprite = numeros[i];
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene("Escena1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
