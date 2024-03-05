using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{

    public Button botonStart;
    public Button botonTerminar;
    public Image Puntos;
    public Text NPuntos;
    public Image imagen;
    public Sprite[] numeros;
    // Start is called before the first frame update
    void Start()
    {
        botonStart.onClick.AddListener(Empezar);
        botonTerminar.onClick.AddListener(TerminarJuego);
    }

    void Empezar()
    {
        imagen.gameObject.SetActive(true);
        botonStart.gameObject.SetActive(false);
        botonTerminar.gameObject.SetActive(false);
        Puntos.gameObject.SetActive(false);
        NPuntos.gameObject.SetActive(false);
        StartCoroutine(Cuentaatras());
    }

    void TerminarJuego()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    IEnumerator Cuentaatras()
    {
        for (int i = 0; i< numeros.Length; i++)
        {
            imagen.sprite = numeros[i];
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene("Nivel1");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
