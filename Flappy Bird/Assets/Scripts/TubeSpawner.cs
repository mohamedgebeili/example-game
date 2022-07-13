using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tube;
    // Start is called before the first frame update
    void Start()
    {
        TubeObstical();
        InvokeRepeating("TubeObstical", 5 , 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TubeObstical()
    {
        Instantiate(tube);
    }
}
