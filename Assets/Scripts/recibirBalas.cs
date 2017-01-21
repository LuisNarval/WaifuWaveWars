using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class recibirBalas : MonoBehaviour {

	public string colorPersonaje;

	public Text marcador;
	public Text marcadorVidas;

	public GameObject explosion;


	int vidas=3;
	int cantidadDeBalas=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D invasor){
		print ("Ha habido Contacto");

		if (invasor.gameObject.tag== colorPersonaje) {
			Destroy (invasor.gameObject);
			cantidadDeBalas++;
			actualizarMarcador ();

		} else if(invasor.gameObject.tag!="jugador") {
			Destroy (this.gameObject);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
			vidas--;
			actualizarVidas();
		}

	}

	void actualizarMarcador(){
		if (cantidadDeBalas < 10) {
			marcador.text = "000" + cantidadDeBalas.ToString();
		} else if (cantidadDeBalas < 100) {
			marcador.text = "00" + cantidadDeBalas.ToString();
		} else if (cantidadDeBalas < 1000) {
			marcador.text = "0" + cantidadDeBalas.ToString();
		}else{
			marcador.text = cantidadDeBalas.ToString();
		

		}
	}




	void actualizarVidas(){
		marcadorVidas.text = vidas.ToString ();
	}


}
