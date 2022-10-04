using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tube;
    [SerializeField] private float spawnSpeed = 3;
    [SerializeField] private Transform player;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTube), 0, spawnSpeed);
    }

    private void SpawnTube()
    {
        float randomheight = Random.Range(-0.6f,2.7f);
        GameObject newTube = Instantiate(tube,new Vector3(transform.position.x ,randomheight,0),Quaternion.identity);
        newTube.transform.parent = transform;
        newTube.GetComponent<Tube>().AssignPlayer(player);
     }
}
