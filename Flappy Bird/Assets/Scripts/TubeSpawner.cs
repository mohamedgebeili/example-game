using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tube;
    [SerializeField] private float Spawnspeed;
    // Start is called before the first frame update
    void Start()
    {
        TubeObstical();
        InvokeRepeating("TubeObstical", 0 , Spawnspeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TubeObstical()
    {
        float randomheight = Random.Range(-0.6f,2.7f);
        Instantiate(tube,new Vector3(transform.position.x ,randomheight,0),Quaternion.identity);  
     }
}
