using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour {

	public GameObject bala;

	public float BeatsPorSegundo=1.0f;


	public float minimoEsferas=2.0f;
	public float maximoEsferas=6.9f;

	float tiempo=0;
	float tiempoGuardado=0;


	int duracion;
	int estadoColor;

	public GameObject ojo;
	public GameObject orbita;

	// Use this for initialization
	void Start () {
		asignarLargo ();
	}

	// Update is called once per frame
	void Update () {

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



}
