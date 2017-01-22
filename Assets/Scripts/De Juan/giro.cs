using UnityEngine;
using System.Collections;

public class giro : MonoBehaviour {

	public float contador;
	public float intervalo;
	public bool tapa;
	public Texture r1a;
	public Texture r1b;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		contador = 0;
		rend = GetComponent<Renderer> ();
		rend.material.mainTexture = r1a;
		tapa = false;
	}
	
	// Update is called once per frame
	void Update () {
			
		contador += Time.deltaTime;

		if (contador >= intervalo && tapa==false) {
			rend.material.mainTexture = r1b;
			tapa = true;
			contador = 0;
		}

		if (contador >= intervalo && tapa==true) {
			rend.material.mainTexture = r1a;
			tapa = false;
			contador = 0;
		}
	}
}
