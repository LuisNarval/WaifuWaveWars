using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {


	public float velocidad=5.0f;

	public int estado=1;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKey (KeyCode.A)&&transform.localPosition.x>-345) {
				this.transform.Translate (Vector3.left * Time.deltaTime * velocidad);		
		}
			
		if (Input.GetKey (KeyCode.D)&&transform.localPosition.x<240) {
			this.transform.Translate (Vector3.right * Time.deltaTime * velocidad);		
		}


		if (Input.GetKeyDown (KeyCode.W)) {

			if (estado >2) {
				estado--;
			}

			actualizarEstado ();

		}


		if (Input.GetKeyDown (KeyCode.S)) {

			if (estado <5) {
				estado++;	
			}

			actualizarEstado ();
		}

	}


	void actualizarEstado(){
		switch (estado) {
			case 1:
			this.transform.position = new Vector3 (this.transform.position.x,9,this.transform.position.z);
			break;

			case 2:
			this.transform.position = new Vector3 (this.transform.position.x,7,this.transform.position.z);
			break;

			case 3:
			this.transform.position = new Vector3 (this.transform.position.x,5,this.transform.position.z);
			break;

			case 4:
			this.transform.position = new Vector3 (this.transform.position.x,3,this.transform.position.z);
			break;

			case 5:
			this.transform.position = new Vector3 (this.transform.position.x,1,this.transform.position.z);
			break;
		}
	}


}