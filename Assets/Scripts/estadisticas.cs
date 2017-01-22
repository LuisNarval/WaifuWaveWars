using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class estadisticas : MonoBehaviour {


	public Text player1_balas;
	public Text player2_balas;
	public Text player3_balas;
	public Text player4_balas;

	public Text player1_muertes;
	public Text player2_muertes;
	public Text player3_muertes;
	public Text player4_muertes;

	public Text player1_danioEnemigo;
	public Text player2_danioEnemigo;
	public Text player3_danioEnemigo;
	public Text player4_danioEnemigo;

	public Text player1_total;
	public Text player2_total;
	public Text player3_total;
	public Text player4_total;


	public Text player1_historial;
	public Text player2_historial;
	public Text player3_historial;
	public Text player4_historial;

	public Text player1_historialTotal;
	public Text player2_historialTotal;
	public Text player3_historialTotal;
	public Text player4_historialTotal;



	public string siguienteEscena;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void actualizarEstadisticas(){
	
		player1_balas.text=PlayerPrefs.GetInt("player1_balas").ToString();
		player2_balas.text=PlayerPrefs.GetInt("player2_balas").ToString();
		player3_balas.text=PlayerPrefs.GetInt("player3_balas").ToString();
		player4_balas.text=PlayerPrefs.GetInt("player4_balas").ToString();

		player1_muertes.text=PlayerPrefs.GetInt("player1_muertes").ToString();
		player2_muertes.text=PlayerPrefs.GetInt("player2_muertes").ToString();
		player3_muertes.text=PlayerPrefs.GetInt("player3_muertes").ToString();
		player4_muertes.text=PlayerPrefs.GetInt("player4_muertes").ToString();

		player1_danioEnemigo.text=PlayerPrefs.GetInt("player1_danioEnemigo").ToString();
		player2_danioEnemigo.text=PlayerPrefs.GetInt("player2_danioEnemigo").ToString();
		player3_danioEnemigo.text=PlayerPrefs.GetInt("player3_danioEnemigo").ToString();
		player4_danioEnemigo.text=PlayerPrefs.GetInt("player4_danioEnemigo").ToString();

		player1_total.text=PlayerPrefs.GetInt("player1_total").ToString();
		player2_total.text=PlayerPrefs.GetInt("player2_total").ToString();
		player3_total.text=PlayerPrefs.GetInt("player3_total").ToString();
		player4_total.text=PlayerPrefs.GetInt("player4_total").ToString();

		player1_historial.text=PlayerPrefs.GetInt("player1_maximoBalas")+"/"+PlayerPrefs.GetInt("player1_maximoMuertes")+"/"+PlayerPrefs.GetInt("player1_maximoDanioEnemigo").ToString();
		player2_historial.text=PlayerPrefs.GetInt("player2_maximoBalas")+"/"+PlayerPrefs.GetInt("player2_maximoMuertes")+"/"+PlayerPrefs.GetInt("player2_maximoDanioEnemigo").ToString();
		player3_historial.text=PlayerPrefs.GetInt("player3_maximoBalas")+"/"+PlayerPrefs.GetInt("player3_maximoMuertes")+"/"+PlayerPrefs.GetInt("player3_maximoDanioEnemigo").ToString();
		player4_historial.text=PlayerPrefs.GetInt("player4_maximoBalas")+"/"+PlayerPrefs.GetInt("player4_maximoMuertes")+"/"+PlayerPrefs.GetInt("player4_maximoDanioEnemigo").ToString();

		player1_historialTotal.text=PlayerPrefs.GetInt("player1_historialTotal").ToString();
		player2_historialTotal.text=PlayerPrefs.GetInt("player2_historialTotal").ToString();
		player3_historialTotal.text=PlayerPrefs.GetInt("player3_historialTotal").ToString();
		player4_historialTotal.text=PlayerPrefs.GetInt("player4_historialTotal").ToString();


	}







	public void jugarDeNuevo(){
		siguienteEscena="Nivel1";
		this.GetComponent<Animator> ().SetTrigger ("desaparecerEstadisticas");
	}

	public void regresar(){
		siguienteEscena="Menu";
		this.GetComponent<Animator> ().SetTrigger ("desaparecerEstadisticas");
	}


	public void irASiguienteEscena(){
		SceneManager.LoadScene(siguienteEscena);
	}




}
