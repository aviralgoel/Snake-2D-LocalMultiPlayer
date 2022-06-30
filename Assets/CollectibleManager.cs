using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CollectibleManager : MonoBehaviour
{
    [System.Serializable]
    public class CollectiblesClass
    {
        public GameObject obj;
        public CollectibleNames name;
    };
    public List<CollectiblesClass> collectibles;
    public float minSpawnFrequency;
    public float maxSpawnFrequency;
    private void Start()
    {
        StartCoroutine(CollectibleSpawner());
    }
    IEnumerator CollectibleSpawner()
    {   
        // every Range(3,6) second second check if an collectible is active or not,
        // if it is active deactivate it, else activate it
        while (true)
        {
            for (int i = 0; i < collectibles.Capacity; i++)
            {
                Debug.Log("Starting Coroutine");
                Collectible temp = collectibles[i].obj.GetComponent<Collectible>();
                if (temp.isCollected)
                {
                    temp.ActivateCollectible();
                }
                else
                {   
                    temp.DeActivateCollectible();
                }
                yield return new WaitForSeconds(Random.Range(minSpawnFrequency, maxSpawnFrequency));
            }
            
        }
        
        

    }
}
