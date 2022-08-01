using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public List<GameObject> collectibles;
    public GameObject massGainer;

    public float minSpawnFrequency;
    public float maxSpawnFrequency;

    private void Start()
    {
        // all collectibles (except mass gainer) spawn based on a random time interval coroutine
        StartCoroutine(CollectibleSpawner());
    }

    private void Update()
    {
        // mass gainer gets spawned instantly when collected
        if (massGainer.GetComponent<Collectible>().isCollected)
        {
            massGainer.GetComponent<Collectible>().ActivateCollectible();
        }
    }

    private IEnumerator CollectibleSpawner()
    {
        // every Range(3,6) second check if an collectible is active or not,
        // if it is active deactivate it, else activate it
        while (true)
        {
            int i = Random.Range(0, collectibles.Count);
            Collectible temp = collectibles[i].GetComponent<Collectible>();
            if (temp.isCollected) // collectible is SetActive(false)
            {
                temp.ActivateCollectible();
            }
            else // collectible is SetActive(true)
            {
                temp.DeActivateCollectible();
            }
            yield return new WaitForSeconds(Random.Range(minSpawnFrequency, maxSpawnFrequency));
        }
    }
}