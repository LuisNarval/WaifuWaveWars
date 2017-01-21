using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {




	public float tiempoDeEspera;
	public float tiempoDeInmunidad;

	float tiempo=0.0f;

	bool inmunidad=false;

	public new Vector3 posicionOrigen;
	public int estadoOrigen;


	SpriteRenderer imagen;

	// Use this for initialization
	void Start () {
		imagen = this.gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!inmunidad)
			contarTiempo ();
		else
			contarTiempoDeInmunidad ();
	}


	void contarTiempo(){
		tiempo += Time.deltaTime;
		if (tiempo >= tiempoDeEspera) {
			this.transform.localPosition = posicionOrigen;



			if(this.GetComponent<movimiento> ()!=null)
				this.GetComponent<movimiento> ().estado = estadoOrigen;
			else if (this.GetComponent<movimiento2> ()!=null)
				this.GetComponent<movimiento2> ().estado = estadoOrigen;



			inmunidad = true;
			tiempo = 0.0f;
		}
	}


	void contarTiempoDeInmunidad(){
		tiempo += Time.deltaTime;
		parpadear ();

		if (tiempo >= tiempoDeInmunidad) {
			imagen.color = new Color (imagen.color.r, imagen.color.g, imagen.color.b, 1.0f);
			tiempo = 0.0f;
			inmunidad = false;
			this.GetComponent<recibirBalas> ().respawnActivo = false;
			this.GetComponent<respawn> ().enabled = false;
		}
	}





	float velocidadParpadeo=5.0f;
	float valorParpadeo=1.0f;
	bool parpadeoPositivo=false;

	void parpadear(){
		if (!parpadeoPositivo) {
			valorParpadeo -= velocidadParpadeo * Time.deltaTime;
		} else {
			valorParpadeo+= velocidadParpadeo * Time.deltaTime;
		}	
			
		imagen.color = new Color (imagen.color.r, imagen.color.g, imagen.color.b, valorParpadeo); 

		if (valorParpadeo <= 0.0f) {
			parpadeoPositivo = true;
		} else if (valorParpadeo >= 1.0f) {
			parpadeoPositivo = false;
		}

	}




}
