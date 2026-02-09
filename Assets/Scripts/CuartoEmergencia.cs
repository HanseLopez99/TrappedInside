using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuartoEmergencia : MonoBehaviour
{
   
    public GameObject luzCuarto;
    private bool isRoom;
    private Light luz;
    public GameObject sonidoSinera;
    private GameObject sonidoActual;


    // Start is called before the first frame update
    void Start()
    {
        luz = luzCuarto.GetComponent<Light>();
        isRoom = false;
        luz.intensity =0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRoom){
          luz.intensity = Mathf.Sin(Time.time *5) *20 ;
        }else{
            luz.intensity = 0f;
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")){
         isRoom = true;
            sonidoActual = Instantiate(sonidoSinera);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")){
         isRoom = false;
            Destroy(sonidoActual);
       }
    }

}
