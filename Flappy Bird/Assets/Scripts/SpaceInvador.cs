using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceInvador : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        FlyUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            FlyUp();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("KOLLISION ERKANNT");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void FlyUp()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * speed);
    }

  
}
