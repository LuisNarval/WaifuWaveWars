using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jefe : MonoBehaviour {

	public GameObject bala;

	public AudioSource cancionRapida;
	public AudioSource musica;
	public GameObject explosion;


	public administrador_nivel1 codigoAdmin;

	public Animator animadorEstadisticas;


	public float BeatsPorSegundo=1.0f;


	public float minimoEsferas=2.0f;
	public float maximoEsferas=6.9f;

	float tiempo=0;
	float tiempoGuardado=0;


	int duracion;
	int estadoColor;

	public float vida=2500.0f;

	public GameObject ojo;
	public GameObject orbita;


	public laser1 jugadorRojo;
	public laser1 jugadorAmarillo;
	public laser1 jugadorVerde;
	public laser1 jugadorAzul;

	// Use this for initialization
	void Start () {
		asignarLargo ();

	}

	void fixedUpdate(){
		jugadorRojo.StopCoroutine ("FireLaser");
		jugadorAmarillo.StopCoroutine ("FireLaser");
		jugadorVerde.StopCoroutine ("FireLaser");
		jugadorAzul.StopCoroutine ("FireLaser");
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.RightShift)||Input.GetKey(KeyCode.RightControl)||Input.GetKey(KeyCode.Return)||Input.GetKey(KeyCode.CapsLock)){
			llamarDisparo ();
		}


		tiempo += Time.deltaTime;

		orbita.transform.Rotate (0, 0, BeatsPorSegundo * Time.deltaTime * 10.0f);

		if(tiempo-tiempoGuardado>=1/BeatsPorSegundo){



			tiempoGuardado = tiempo;
			GameObject dummy;

			switch ((int)Random.Range (1.0f, 4.9f)) {
			case 0:
					dummy = Instantiate (bala, new Vector3 (this.transform.position.x, 9, this.transform.position.z), this.transform.rotation)as GameObject;
					asignarColor (dummy);
				break;

				case 1:
					dummy=Instantiate (bala, new Vector3(this.transform.position.x,7,this.transform.position.z), this.transform.rotation)as GameObject;
					asignarColor (dummy);
				break;

				case 2:
					dummy=Instantiate (bala, new Vector3(this.transform.position.x,5,this.transform.position.z), this.transform.rotation)as GameObject;
					asignarColor (dummy);
				break;

				case 3:
					dummy=Instantiate (bala, new Vector3(this.transform.position.x,3,this.transform.position.z), this.transform.rotation)as GameObject;
					asignarColor (dummy);
				break;

				case 4:
					dummy=Instantiate (bala, new Vector3(this.transform.position.x,1,this.transform.position.z), this.transform.rotation)as GameObject;
					asignarColor (dummy);
				break;
			}
				

		}

	}



	void asignarLargo(){
		estadoColor = (int)Random.Range (0.0f,3.9f);
		duracion=(int)Random.Range (minimoEsferas,maximoEsferas);
	}



	void asignarColor(GameObject dummy){
		switch (estadoColor) {

		case 0:
			orbita.GetComponent<Renderer> ().material.color = Color.red;
			ojo.GetComponent<Renderer> ().material.color = Color.red;
			dummy.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			dummy.gameObject.tag = "rojo";
			duracion--;
			if (duracion <= 0)
				asignarLargo ();			
			break;

		case 1:
			orbita.GetComponent<Renderer>().material.color=Color.yellow;
			ojo.GetComponent<Renderer>().material.color=Color.yellow;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.yellow;
			dummy.gameObject.tag = "amarillo";
			duracion--;
			if (duracion <= 0)
				asignarLargo ();
			
			break;

		case 2:
			orbita.GetComponent<Renderer>().material.color=Color.green;
			ojo.GetComponent<Renderer>().material.color=Color.green;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.green;
			dummy.gameObject.tag = "verde";
			duracion--;
			if (duracion <= 0)
				asignarLargo ();
			
			break;

		case 3:
			orbita.GetComponent<Renderer>().material.color=Color.blue;
			ojo.GetComponent<Renderer>().material.color=Color.blue;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.blue;
			duracion--;
			dummy.gameObject.tag = "azul";
			if (duracion <= 0)
				asignarLargo ();
			
			break;

		default:
			print ("Algo salio terriblemente mal");
			print (estadoColor);
			asignarLargo ();
			break;
		}
		Destroy (dummy,6.0f);
	}





	void llamarDisparo(){
		switch (estadoColor) {

			case 0:
				
				jugadorRojo.StopCoroutine ("FireLaser");
				jugadorRojo.disparar ();
			break;

			case 1:
			
				jugadorAmarillo.StopCoroutine ("FireLaser");
				jugadorAmarillo.disparar ();
			break;

			case 2:

				jugadorVerde.StopCoroutine ("FireLaser");
				jugadorVerde.disparar ();
			break;

			case 3:
	
				jugadorAzul.StopCoroutine ("FireLaser");
				jugadorAzul.disparar ();
			break;

			default:
			print ("Algo salio terriblemente mal. Estado actual: "+ estadoColor);
			break;
		}
	}


	public Image relleno;

	bool segundaFase=false;

	public void actualizarMarcador(){


		if (vida <=1000.0f&&!segundaFase) {
			BeatsPorSegundo = 2.5f;

			musica.gameObject.SetActive (false);
			cancionRapida.gameObject.SetActive (true);
			segundaFase = true;
		}


		relleno.fillAmount = vida / 2500.0f;

		print (vida);

		if (vida <=0.0f) {
			GameObject dummy=Instantiate (explosion,transform.position,transform.rotation)as GameObject;
			dummy.transform.localScale = new Vector3 (10,10,10);
			codigoAdmin.activarEstadisticas ();
			Destroy (this.gameObject);
		}

	}


}
