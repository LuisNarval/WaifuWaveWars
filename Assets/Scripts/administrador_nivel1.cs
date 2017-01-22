using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class administrador_nivel1 : MonoBehaviour {

	public int jugadoresVivos=4;

	public Animator animadorEstadisticas;

	public estadisticas codigoEstadisticas;

	string siguienteEscena;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void restarJugador(){
		jugadoresVivos--;

		if (jugadoresVivos == 0) {
			activarEstadisticas ();
		}

	}




	public void activarEstadisticas(){
		animadorEstadisticas.SetTrigger ("aparecerEstadisticas");
		codigoEstadisticas.actualizarEstadisticas ();
	}




	public void enviarInformacion(string nombre, int balas, int muertes, int danioEnemigo){
		int puntos;
		puntos = ((balas + danioEnemigo) * 2) - muertes * 10;
		switch (nombre) {

		case "jugador1":
			PlayerPrefs.SetInt ("player1_balas", balas);
			PlayerPrefs.SetInt ("player1_muertes", muertes);
			PlayerPrefs.SetInt ("player1_danioEnemigo", danioEnemigo);
			PlayerPrefs.SetInt ("player1_total", puntos);

			if (PlayerPrefs.GetInt ("player1_historialTotal") == null) {
				PlayerPrefs.SetInt ("player1_historialTotal", puntos);

				PlayerPrefs.SetInt ("player1_maximoBalas", balas);
				PlayerPrefs.SetInt ("player1_maximoMuertes", muertes);
				PlayerPrefs.SetInt ("player1_maximoDanioEnemigo", danioEnemigo);
			} else if (PlayerPrefs.GetInt ("player1_historialTotal") < puntos) {
				PlayerPrefs.SetInt ("player1_historialTotal", puntos);

				PlayerPrefs.SetInt ("player1_maximoBalas", balas);
				PlayerPrefs.SetInt ("player1_maximoMuertes", muertes);
				PlayerPrefs.SetInt ("player1_maximoDanioEnemigo", danioEnemigo);
			} 

			break;

			case "jugador2":
				PlayerPrefs.SetInt ("player2_balas",balas);
				PlayerPrefs.SetInt ("player2_muertes",muertes);
				PlayerPrefs.SetInt ("player2_danioEnemigo",danioEnemigo);
				PlayerPrefs.SetInt ("player2_total",puntos);


				if (PlayerPrefs.GetInt ("player2_historialTotal") == null) {
					PlayerPrefs.SetInt ("player2_historialTotal", puntos);

					PlayerPrefs.SetInt ("player2_maximoBalas", balas);
					PlayerPrefs.SetInt ("player2_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player2_maximoDanioEnemigo", danioEnemigo);
				} else if (PlayerPrefs.GetInt ("player2_historialTotal") < puntos) {
					PlayerPrefs.SetInt ("player2_historialTotal", puntos);

					PlayerPrefs.SetInt ("player2_maximoBalas", balas);
					PlayerPrefs.SetInt ("player2_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player2_maximoDanioEnemigo", danioEnemigo);
				} 

			break;

			case "jugador3":
				PlayerPrefs.SetInt ("player3_balas",balas);
				PlayerPrefs.SetInt ("player3_muertes",muertes);
				PlayerPrefs.SetInt ("player3_danioEnemigo",danioEnemigo);
				PlayerPrefs.SetInt ("player3_total",puntos);

				if (PlayerPrefs.GetInt ("player3_historialTotal") == null) {
					PlayerPrefs.SetInt ("player3_historialTotal", puntos);

					PlayerPrefs.SetInt ("player3_maximoBalas", balas);
					PlayerPrefs.SetInt ("player3_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player3_maximoDanioEnemigo", danioEnemigo);
				} else if (PlayerPrefs.GetInt ("player3_historialTotal") < puntos) {
					PlayerPrefs.SetInt ("player3_historialTotal", puntos);

					PlayerPrefs.SetInt ("player3_maximoBalas", balas);
					PlayerPrefs.SetInt ("player3_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player3_maximoDanioEnemigo", danioEnemigo);
				} 

			break;

			case "jugador4":
				PlayerPrefs.SetInt ("player4_balas",balas);
				PlayerPrefs.SetInt ("player4_muertes",muertes);
				PlayerPrefs.SetInt ("player4_danioEnemigo",danioEnemigo);
				PlayerPrefs.SetInt ("player4_total",puntos);

				if (PlayerPrefs.GetInt ("player4_historialTotal") == null) {
					PlayerPrefs.SetInt ("player4_historialTotal", puntos);

					PlayerPrefs.SetInt ("player4_maximoBalas", balas);
					PlayerPrefs.SetInt ("player4_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player4_maximoDanioEnemigo", danioEnemigo);
				} else if (PlayerPrefs.GetInt ("player4_historialTotal") < puntos) {
					PlayerPrefs.SetInt ("player4_historialTotal", puntos);

					PlayerPrefs.SetInt ("player4_maximoBalas", balas);
					PlayerPrefs.SetInt ("player4_maximoMuertes", muertes);
					PlayerPrefs.SetInt ("player4_maximoDanioEnemigo", danioEnemigo);
				} 

			break;

			default:
				print ("Algo salio terriblemente mal");
			break;


		}

	}








}
