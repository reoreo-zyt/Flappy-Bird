using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefeb;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisabled()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefeb, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
