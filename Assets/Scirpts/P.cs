using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject spikePrefab; // Prefab del pincho
    public Transform spikeSpawnPoint; // Punto de spawn del pincho
    public float spawnDelay = 1f; // Retraso entre cada spawn de pincho
    public float fallSpeed = 5f; // Velocidad de ca�da del pincho

    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside)
        {
            // Spawn pinchos
            SpawnSpike();
            isPlayerInside = false; // Resetear para evitar spawns m�ltiples
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

        // Asignar velocidad de ca�da al pincho
        spike.GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;

        // Destruir el pincho despu�s de un tiempo
        Destroy(spike, 5f); // Ajusta el tiempo seg�n sea necesario
    }
}
