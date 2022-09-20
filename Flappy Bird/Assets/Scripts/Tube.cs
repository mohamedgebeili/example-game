using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Transform player;
    private bool canScore = true;
    private static int score = 0;
    public void AssignPlayer(Transform player)
    {
        this.player = player;
    }

    // Update is called once per frame
    private void Update()
    {
       transform.Translate(speed * Time.deltaTime * Vector3.left);
        if(transform.position.x < player.position.x && canScore )
        {
            canScore = false;
            score++; 
            print("scoreee " +score);
        }    
    }
}
