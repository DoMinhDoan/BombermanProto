using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask layerMask;

    bool isExploded = false;

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

        //
        StartCoroutine(CreateExplosion(Vector3.forward));
        StartCoroutine(CreateExplosion(Vector3.right));
        StartCoroutine(CreateExplosion(Vector3.back));
        StartCoroutine(CreateExplosion(Vector3.left));

        // Disables the mesh renderer, making the bomb invisible.
        GetComponent<MeshRenderer>().enabled = false;
        isExploded = true;

        // Disables the collider, allowing players to move through and walk into an explosion.
        transform.Find("Collider").gameObject.SetActive(false);

        // Destroys the bomb after 0.3 seconds; this ensures all explosions will spawn before the GameObject is destroyed.
        Destroy(gameObject);
    }

    IEnumerator CreateExplosion(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;

            // Raycast : position, direction, maxdistance, layerMask
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i, layerMask);

            if(!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
            }
            else
            {
                // Once the raycast hits a block, it breaks out of the for loop.This ensures the explosion can't jump over walls.
                break;
            }
        }
        yield return new WaitForSeconds(.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isExploded && other.gameObject.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }
}
