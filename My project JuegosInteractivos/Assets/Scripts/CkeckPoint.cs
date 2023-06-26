using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    //public Text Totalpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);

            GetComponent<Animator>().enabled = true;
        }
    }
}
