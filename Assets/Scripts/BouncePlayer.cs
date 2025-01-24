using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
    public void Bounce(Player player, Bubble bubble)
    {
        player.GetBody().AddForce(transform.up * 25f, ForceMode2D.Impulse);
    }
}
