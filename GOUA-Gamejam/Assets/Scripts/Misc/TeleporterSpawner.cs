using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterSpawner : MonoBehaviour
{
    public GameObject teleporterPrefab;

    private float timeToSpawn = 20f; // 5 minutes in seconds
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Timer: " + timer);

        if (timer >= timeToSpawn)
        {
            InstantiateTeleporter();
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void InstantiateTeleporter()
    {
        // Get the bounds of the camera view in world space
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;
        float camX = cam.transform.position.x;
        float camY = cam.transform.position.y;
        float xMin = camX - camWidth / 2f;
        float xMax = camX + camWidth / 2f;
        float yMin = camY - camHeight / 2f;
        float yMax = camY + camHeight / 2f;

        // Instantiate the teleporter randomly within the camera view
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector3 position = new Vector3(x, y, 0f);
        Instantiate(teleporterPrefab, position, Quaternion.identity);

        Debug.Log("Teleporter instantiated at " + position);
    }
}
