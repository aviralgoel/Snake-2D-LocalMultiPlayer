using UnityEngine;

public class Collectible : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public bool isCollected = false;
    private void Start()
    {
        RandomPosition();
    }
    private void RandomPosition()
    {
        Bounds gridBound = this.gridArea.bounds; // cal

        float x = Random.Range(gridBound.min.x, gridBound.max.x);
        float y = Random.Range(gridBound.min.y, gridBound.max.y);
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player 1") || collision.CompareTag("Player 2"))
        {
            gameObject.SetActive(false);
            isCollected = true;
        }

    }
    public void ActivateCollectible()
    {
        isCollected = false;
        gameObject.SetActive(true);
        RandomPosition();
    }
    public void DeActivateCollectible()
    {
        gameObject.SetActive(false);
        isCollected = true;
    }
}
