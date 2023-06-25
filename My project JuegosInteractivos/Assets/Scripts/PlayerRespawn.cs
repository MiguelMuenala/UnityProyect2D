using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float chaeckPointPositionX, chaeckPointPositionY;//Punto donde va a re-aparecer el personaje.
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("chaeckPointPositionX") != 0)//PlayerPrefs: guarda información del juego, y la mantiene aún cuando termina el juego, y no guarda vectores.
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("chaeckPointPositionX"), PlayerPrefs.GetFloat("chaeckPointPositionY")));
        }
    }

    public void ReachedCheckPoint(float x, float y)//Guarda la posción del Ckerpoint con el PlayerPrefs
    {
        PlayerPrefs.SetFloat("chaeckPointPositionX", x);//SetFloat para guardar la información en el PlayerPrefs
        PlayerPrefs.SetFloat("chaeckPointPositionY", y);
    }
    
    public void PlayerDamaged()//Para animation de morir.
    {
        animator.Play("die");
        Invoke("RefreshScene", 1); //tiempo de espera en segundos
    }

    void RefreshScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//volver a cargar la escena actual
    }
}
