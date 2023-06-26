using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    //public Text levelCleared;// texto del canva para indocar que se terminó el nivel
    //public GameObject transition; //

    public Text totalFruits;
    public Text FruitsCollected;
    public Text Totalpoint;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;//Frutas totales que tiene el contenedor de frutas al iniciar el juego
        
        Totalpoint.text = PlayerPrefs.GetFloat("chaeckPointPositionX").ToString();
    }
    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        int scoreResult = totalFruitsInLevel - transform.childCount;//childCount: es para objeter el número de hijos que se tiene 
        FruitsCollected.text = scoreResult.ToString();
        int conteindoPlayerPrefs= scoreResult + PlayerPrefs.GetInt("chaeckPointPositionX");
        PlayerPrefs.SetFloat("chaeckPointPositionX", conteindoPlayerPrefs);
    }
    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, Victoria");//Imprimir en consola que se terminó el nivel
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Cambiar de escena, aumenta un 1 al indice del SceneManager.
            //levelCleared.gameObject.SetActive(true); //Mostrar un canva de mensaje de que se terminó el nivel.
            //transition.SetActive(true); //
            Invoke("ChangeScene", 1); //tiempo de espera 1segundo
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
