using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
    [SerializeField]
    protected float force = 35;

    public void Bounce(Player player, Bubble bubble)
    {
        player.GetBody().AddForce(transform.up * force, ForceMode2D.Impulse);
    }
}
