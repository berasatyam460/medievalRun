using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class game_manager : MonoBehaviour
{
    public static game_manager instance;
    public TextMeshProUGUI coin_collected;
    public TextMeshProUGUI coin_collectShow;//show the ingame collected coin
    public GameObject restartpanel;
    [SerializeField] int coin_Collect = 0;
    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;

    }
    // Start is called before the first frame update
    public void  updatescore()
    { 
        coin_Collect += 2;
    }
    private void Update()
    {
        coin_collectShow.text="Coin Collected: "+coin_Collect.ToString();
    }

    public void die()
    {
        Time.timeScale = 0f;
        restartpanel.SetActive(true);
        coin_collected.text = "Coin Collected: " + coin_Collect.ToString();
    }
    public void restart(int index)
    {
        SceneManager.LoadScene(index);
    }
}
