using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorBolaN2 : MonoBehaviour
{

    public Camera camara;
    public GameObject suelo;
    public GameObject estrella;
    public float velocidad;
    public Text Contador;
    public AudioSource Sonido;

    private Vector3 offSet;
    private float ValX, ValZ;
    private Vector3 DireccionActual;
    // Start is called before the first frame update
    void Start()
    {
        Contador.text = "" + GameManager.instance.TotalEstrellas;
        offSet = camara.transform.position;
        CrearSueloInicial();
        DireccionActual= Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offSet;
        if(Input.GetKeyUp(KeyCode.Space)){
            CambiarDireccion();
        }
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);

        if(transform.position.y < -20)
        {
            // Carga la escena "SampleScene" o la escena que desees reiniciar
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "Suelo"){
            Debug.Log("Colision con el suelo");
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
    }

    IEnumerator BorrarSuelo(GameObject suelo)
    {
        float aleatorio = Random.Range(0.0f , 1.0f);
        if (aleatorio > 0.5f)
        {
            ValX +=4.5f;
        }
        else
        {
            ValZ+=4.5f;
        }
        Instantiate(suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);
        float aleatorio2 = Random.Range(0.0f , 1.0f);
        if (aleatorio2 > 0.7f)
        {
            Instantiate(estrella, new Vector3(ValX, 1, ValZ), Quaternion.Euler(45, 45, 45));
        }

        yield return new WaitForSeconds(2);
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(suelo);
    }

    void CambiarDireccion()
    {
        if(DireccionActual == Vector3.forward)
        {
            DireccionActual = Vector3.right;
        }
        else
        {
            DireccionActual = Vector3.forward;
        }
    }

    void CrearSueloInicial()
    {
       for(int i =0; i<3; i++){
            ValZ +=4.5f;
            Instantiate(suelo, new Vector3(ValX, 0, ValZ),Quaternion.identity);
        }
        for(int i =0; i<15; i++){
        float aleatorio = Random.Range(0.0f , 1.0f);
        if (aleatorio > 0.5f)
        {
            ValX +=4.5f;
        }
        else
        {
            ValZ+=4.5f;
        }
            Instantiate(suelo, new Vector3(ValX, 0, ValZ),Quaternion.identity);
        float aleatorio2 = Random.Range(0.0f , 1.0f);
        if (aleatorio2 > 0.7f)
        {
            Instantiate(estrella, new Vector3(ValX, 1, ValZ), Quaternion.Euler(45, 45, 45));
        }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Estrella"))
        {
            Sonido.Play();
            GameManager.instance.AñadirEstrella();
            Contador.text = "" + GameManager.instance.TotalEstrellas;
            Destroy(other.gameObject);
            if(GameManager.instance.TotalEstrellas==12){
                SceneManager.LoadScene("Nivel3");
                Contador.text = "12";
            }
        }
    }
}