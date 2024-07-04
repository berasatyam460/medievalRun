using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] int turnspeed;
    public AudioClip coinclip;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinclip,transform.position, 0.5f);
            game_manager.instance.updatescore();
            Destroy(gameObject);

        }
    }
    private void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);
    }
   
}
