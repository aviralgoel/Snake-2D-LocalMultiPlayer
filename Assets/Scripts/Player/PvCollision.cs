using UnityEngine;
using UnityEngine.SceneManagement;

// Purpose: Detect and Handle Collision with self and opponent snake
public class PvCollision : MonoBehaviour
{
    public PlayerController controller;
    public PlayerController opponent;
    public GameMenuManager menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision happens with self && shield is not active
        if (collision.CompareTag(transform.gameObject.tag) && !controller.snake.getIsImmune())
        {
            SoundManager.Instance.Play(SoundsNames.NegativeCollectiblePickup);
            controller.PlayerDead();
            opponent.snake.IsDead = true;
            menu.PlayerLost(transform.gameObject.name);
        }
        // collision happens with opponent and opponent has no shield and it is a multiplayer gaeme
        else if (collision.CompareTag(opponent.gameObject.tag) && !opponent.snake.getIsImmune() && SceneManager.GetActiveScene().name == "MultiPlayerGame")
        {
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
            opponent.PlayerDead();
            controller.snake.IsDead = true;
            menu.PlayerWon(transform.gameObject.name);
        }
    }
}