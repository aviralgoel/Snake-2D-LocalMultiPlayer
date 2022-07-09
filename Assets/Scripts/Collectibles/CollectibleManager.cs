using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CollectibleManager : MonoBehaviour
{
    public List<GameObject> collectibles;
    public GameObject massGainer;
    
    public float minSpawnFrequency;
    public float maxSpawnFrequency;
    private void Start()
    {
        StartCoroutine(CollectibleSpawner());
    }
    private void Update()
    {
        if (massGainer.GetComponent<Collectible>().isCollected)
        {
            massGainer.GetComponent<Collectible>().ActivateCollectible();
        }

    }
    IEnumerator CollectibleSpawner()
    {   
        // every Range(3,6) second second check if an collectible is active or not,
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
