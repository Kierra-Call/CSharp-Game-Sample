using UnityEngine;

public class Abilitys : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;
    
    // Reference to the SelectionManager
    private SelectionManager selectionManager;

    void Start()
    {
        // Find the SelectionManager instance in the scene
        selectionManager = SelectionManager.instance;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input you want to use
        {
            // Get the direction of the ray from the SelectionManager
            Vector3 rayDirection = selectionManager != null ? selectionManager.GetRayDirection() : Vector3.forward;
            ShootSphere(rayDirection);
        }
    }

    void ShootSphere(Vector3 direction)
    {
        // Instantiate a sphere prefab
        GameObject sphere = Instantiate(spherePrefab, shootPoint.position, Quaternion.identity);

        // Get the Rigidbody component of the sphere
        Rigidbody sphereRb = sphere.GetComponent<Rigidbody>();

        // Check if the sphere has a Rigidbody component
        if (sphereRb != null)
        {
            sphereRb.AddForce(direction * shootForce, ForceMode.Impulse);

        }
    }

}
