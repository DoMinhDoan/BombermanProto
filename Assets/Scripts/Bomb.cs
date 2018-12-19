using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Disables the mesh renderer, making the bomb invisible.
        GetComponent<MeshRenderer>().enabled = false;

        // Disables the collider, allowing players to move through and walk into an explosion.
        transform.Find("Collider").gameObject.SetActive(false);

        // Destroys the bomb after 0.3 seconds; this ensures all explosions will spawn before the GameObject is destroyed.
        Destroy(gameObject);
    }
}
