using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private bool hasPassedPlayer;
    private Transform player;

    public void AssignPlayer(Transform player)
    {
        this.player = player;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);

        if (!hasPassedPlayer && transform.position.x < player.position.x)
        {
            hasPassedPlayer = true;
            player.GetComponent<SpaceInvader>().IncreaseScore();
        }
    }
}
