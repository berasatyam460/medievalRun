using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{

    public GameObject[] gound_tile;
    [SerializeField] Vector3 nextspawn;
    

    public void spawn_ground()
    {
        int randomno = Random.Range(0, gound_tile.Length);
        GameObject gt = Instantiate(gound_tile[randomno], nextspawn, Quaternion.identity);
        nextspawn = gt.transform.GetChild(1).transform.position;
    }
    public void fiften()
    {
        GameObject gt = Instantiate(gound_tile[0], nextspawn, Quaternion.identity);
        nextspawn = gt.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<15;i++)
        fiften();
        
      
    }
   
    
}
