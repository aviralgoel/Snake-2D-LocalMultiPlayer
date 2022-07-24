using UnityEngine;
using UnityEngine.SceneManagement;

public class PvCollision : MonoBehaviour
{
    public PlayerController controller;
    public PlayerController opponent;
    public GameMenuManager menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {   

        //collision happens with self
        if (collision.CompareTag(transform.gameObject.tag) && !controller.snake.getIsImmune())
        {
            SoundManager.Instance.Play(SoundsNames.NegativeCollectiblePickup);
            controller.PlayerDead();
            opponent.snake.IsDead = true;
            //Debug.Log("I am loser" + transform.gameObject.name);
            menu.PlayerLost(transform.gameObject.name);
        }
        //collision happens with opponent
        else if (collision.CompareTag(opponent.gameObject.tag) && !opponent.snake.getIsImmune() && SceneManager.GetActiveScene().name == "MultiPlayerGame")
        {
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
            opponent.PlayerDead();
            controller.snake.IsDead = true;
            //Debug.Log("I am winner" + transform.gameObject.name);
            menu.PlayerWon(transform.gameObject.name);

        }
    }
}
