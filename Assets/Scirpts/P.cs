using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject spikePrefab; // Prefab del pincho
    public Transform spikeSpawnPoint; // Punto de spawn del pincho
    public float spawnDelay = 1f; // Retraso entre cada spawn de pincho
    public float fallSpeed = 5f; // Velocidad de caída del pincho

    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside)
        {
            // Spawn pinchos
            SpawnSpike();
            isPlayerInside = false; // Resetear para evitar spawns múltiples
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void SpawnSpike()
    {
        // Crear un nuevo pincho en el punto de spawn
        GameObject spike = Instantiate(spikePrefab, spikeSpawnPoint.position, spikeSpawnPoint.rotation);

        // Asignar velocidad de caída al pincho
        spike.GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;

        // Destruir el pincho después de un tiempo
        Destroy(spike, 5f); // Ajusta el tiempo según sea necesario
    }
}
