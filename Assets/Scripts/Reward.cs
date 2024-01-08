using UnityEngine;

public class Reward : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PLAYER_TAG)
        {
            SaveableData.AddScore();
            gameObject.SetActive(false);
        }
    }
}
