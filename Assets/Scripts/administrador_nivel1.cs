using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class administrador_nivel1 : MonoBehaviour {

	public int jugadoresVivos=4;

	public Animator animadorEstadisticas;

	public estadisticas codigoEstadisticas;

	public GameObject Ganador;


	public Sprite jugador1;
	public Sprite jugador2;
	public Sprite jugador3;
	public Sprite jugador4;

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
		Ganador.GetComponent<Image> ().sprite = spriteGanador();
	}

	public Text tituloEstadisticas;
	public GameObject cuerpoTitulo;

	public void estadisticasGanadoras(){
		
		tituloEstadisticas.text="¡VICTORIA!";
		cuerpoTitulo.GetComponent<Renderer> ().material.color = Color.green;

	}


	Sprite spriteGanador(){

		Sprite[] arregloSprites = { jugador1, jugador2, jugador3, jugador4 };
		int[] arregloValores = { PlayerPrefs.GetInt("player1_total"), PlayerPrefs.GetInt("player2_total"), PlayerPrefs.GetInt("player3_total"), PlayerPrefs.GetInt("player4_total") };
			

		Sprite ganador=jugador1;


			for(int x=0;x<4   ;x++){
				for(int y=0;y<3  ;y++){
					if (arregloValores [y] > arregloValores [x]) {
						ganador = arregloSprites [y];
					}
				}
			}

		return ganador;
	}


	public void enviarInformacion(string nombre, int balas, int muertes, int danioEnemigo){
		int puntos;
		puntos = ((balas + danioEnemigo/5) * 2) - muertes * 10;
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
