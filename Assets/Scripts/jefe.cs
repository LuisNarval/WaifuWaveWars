using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour {

	public GameObject bala;

	public float BeatsPorSegundo=1.0f;


	float tiempo=0;
	float tiempoGuardado=0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		tiempo += Time.deltaTime;


		if(tiempo-tiempoGuardado>=1/BeatsPorSegundo){
			print((int)tiempo);
			tiempoGuardado = tiempo;
			GameObject dummy;

			switch ((int)Random.Range (0.0f, 4.9f)) {
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





	void asignarColor(GameObject dummy){
		switch ((int)Random.Range (0.0f, 3.9f)) {

		case 0:
			this.gameObject.GetComponent<Renderer>().material.color=Color.red;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.red;
			break;

		case 1:
			this.gameObject.GetComponent<Renderer>().material.color=Color.yellow;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.yellow;
			break;

		case 2:
			this.gameObject.GetComponent<Renderer>().material.color=Color.green;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.green;
			break;

		case 3:
			this.gameObject.GetComponent<Renderer>().material.color=Color.blue;
			dummy.gameObject.GetComponent<Renderer>().material.color=Color.blue;
			break;

		default:
			print ("Algo salio terriblemente mal");
			break;
		}
		Destroy (dummy,8.0f);
	
	}

}
