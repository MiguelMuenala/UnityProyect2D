using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage");
            Destroy(collision.gameObject);//destruye el objeto que colisiona con el objeto que contiene este script
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();//objetenemos la funcion "PlayerDamaged" del script "PlayerRespawn"
        }
    }
}
