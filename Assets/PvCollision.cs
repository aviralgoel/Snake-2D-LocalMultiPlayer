using UnityEngine;
using UnityEngine.SceneManagement;

public class PvCollision : MonoBehaviour
{
    public PlayerController controller;
    public PlayerController opponent;

    private void Awake()
    {

    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "MultiplayerGame")
        {
            this.GetComponent<PvCollision>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(transform.gameObject.tag) && !controller.snake.getIsImmune())
        {
            SoundManager.Instance.Play(SoundsNames.NegativeCollectiblePickup);
            controller.PlayerDead();
            opponent.snake.IsDead = true;

        }
        else if (collision.CompareTag(opponent.gameObject.tag) && !opponent.snake.getIsImmune())
        {
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
            opponent.PlayerDead();
            controller.snake.IsDead = true;
        }
    }
}
