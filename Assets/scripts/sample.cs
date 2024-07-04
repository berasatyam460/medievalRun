using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class sample : MonoBehaviour
{
    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    //public Text ds;
    public GameObject loadingobj;
    public Slider loadingsli;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        loadingobj.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onck(int level)
    {
        // SceneManager.LoadScene(level);
   
            StartCoroutine(loadaing(level ));
    }
   
       
    public void exit()
    {
        Application.Quit();
    } 
    IEnumerator loadaing(int level)
    {

        AsyncOperation loading = SceneManager.LoadSceneAsync(level);
        while (!loading .isDone )
        {
            loadingobj.SetActive(true);
            float progress = Mathf.Clamp01(loading .progress  / 0.9f);


            loadingsli.value = progress;
            text.text = (progress * 100f).ToString("0") + "%";
            yield return null;
        }
    }


}
