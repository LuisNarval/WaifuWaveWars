using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class recibirBalas : MonoBehaviour {

	public string colorPersonaje;

	public Text marcador;
	public Text marcadorVidas;

	public GameObject Informacion;
	public GameObject Calavera;

	public GameObject explosion;


	public bool respawnActivo = false;

	public int vidas=3;
	int cantidadDeBalas=0;

	// Use this for initialization
	void Start () {
		actualizarVidas ();
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
				GetComponent<AudioSource> ().Play ();


			} else if(invasor.gameObject.tag!="jugador"&&!respawnActivo) {
				

				Instantiate (explosion, this.transform.position, this.transform.rotation);
				this.transform.position = new Vector3 (1000, this.transform.position.y, 200);

				vidas--;
				actualizarVidas();

			if (vidas >= 0) {
				respawnActivo = true;
				this.GetComponent<respawn> ().enabled = true;
			} else if (vidas < 0) {
				Informacion.SetActive(false);
				Calavera.SetActive(true);
				Destroy (this.gameObject);
			}


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
