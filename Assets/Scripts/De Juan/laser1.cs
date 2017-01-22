using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class laser1 : MonoBehaviour {


	public Text contador;

	public GameObject explosion;

	public recibirBalas codigoBalas;

	public Image barraDeBalas;

	public AudioSource SFX_error;

	public float balasNecesarias=10.0f;
	public float cantidadDeBalas = 0.0f;


	public bool puedeDisparar=false;
	public GameObject trueno;

	LineRenderer line;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;

	}

	// Update is called once per frame
	void Update () {
		
	}



	public void recogerBala(){
			cantidadDeBalas++;
			barraDeBalas.fillAmount = cantidadDeBalas / 10.0f;
			contador.text = cantidadDeBalas.ToString ();
			if (cantidadDeBalas >= balasNecesarias) {
				puedeDisparar = true;
				trueno.SetActive (true);
			}
	}


	public void gastarBalas(){
		cantidadDeBalas -= 2 * Time.deltaTime;
		barraDeBalas.fillAmount = cantidadDeBalas / 10.0f;
		contador.text = cantidadDeBalas.ToString ();
		if (cantidadDeBalas <=0) {
			puedeDisparar = false;
			trueno.SetActive (false);
		}
	}


	public void disparar(){
		if (puedeDisparar) {
			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
		}else{
			SFX_error.Play ();
			StopCoroutine ("FireLaser");
		}
	}


	IEnumerator FireLaser()
	{
		line.enabled = true;

		while (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.RightShift)||Input.GetKey(KeyCode.RightControl)||Input.GetKey(KeyCode.Return)||Input.GetKey(KeyCode.CapsLock)) {
			//line.renderer = new Vector2 (0, Time.time);
			this.GetComponent<AudioSource>().Play();
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);

			gastarBalas ();

			if(Physics.Raycast(ray, out hit, 15)){
				line.SetPosition(1, hit.point);
				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition (transform.forward * 5, hit.point);


					if (hit.rigidbody.gameObject.name == "Jefe") {
						hit.rigidbody.gameObject.GetComponent<jefe> ().vida-=10;
						codigoBalas.danioRealizado++;
						Instantiate (explosion, hit.point, Quaternion.Euler (new Vector3 (0, 0, 0)));
						hit.rigidbody.gameObject.GetComponent<jefe> ().actualizarMarcador();
					}
				}
			}
			else
				line.SetPosition(1, ray.GetPoint(15));

			yield return null;
		}

		line.enabled = false;
	}
}