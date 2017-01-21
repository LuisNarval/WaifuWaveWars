using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

	public float velocidad = -5.0f;

	// Use this for initialization
	void Start () {
	}



	// Update is called once per frame
	void Update () {
	
		movimientoLateral ();




	}



	void movimientoLateral(){
		this.transform.Translate (1.0f*velocidad*Time.deltaTime,0,0);
	}
		








}