using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    move move;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.FindObjectOfType<move>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.die();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        move.die();
    //    }
    //}
}
