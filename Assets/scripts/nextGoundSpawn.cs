using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextGoundSpawn : MonoBehaviour
{
    [SerializeField]bool N_platform;
    groundSpawner groundSpawner;
    public GameObject obsticle;
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<groundSpawner>();
        if(N_platform)
        spawn_enemy();
        if(N_platform)
        spawn_coin();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawn_ground();

        Destroy(gameObject, 3f);
    }
    void spawn_enemy()
    {
        int enemyspwan_pointindex = Random.Range(2, 5);

        Transform spwanpoint_enemy = transform.GetChild(enemyspwan_pointindex).transform;

        GameObject enemy = Instantiate(obsticle, spwanpoint_enemy.position, Quaternion.identity, transform);
    }
    void spawn_coin()
    {

        int luckycoin ;
        int coinspwan_pointindex = Random.Range(5, 8);
        if (coinspwan_pointindex == 5)
        {
            int lc = Random.Range(1, 3);
             luckycoin =  5+ lc;
        }else if (coinspwan_pointindex==6)
        {
            luckycoin = 6 + 1;

        }else
        {
            int lc = Random.Range(1, 3);
            luckycoin = 7 - lc;
        }
        int ab = Random.Range(0, 5);
        if (ab < 3)
        {
            Transform spwanpoint_coin1 = transform.GetChild(luckycoin).transform;
            GameObject coins1 = Instantiate(coin, spwanpoint_coin1.position, Quaternion.identity, transform);
        }
        Transform spwanpoint_coin = transform.GetChild(coinspwan_pointindex).transform;
        GameObject coins = Instantiate(coin, spwanpoint_coin.position, Quaternion.identity, transform);
    }
}
