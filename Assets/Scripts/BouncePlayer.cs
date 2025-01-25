using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
	[SerializeField]
	protected float force = 35;

	public void Bounce(Player player)
	{
		player.GetBody().AddForce(transform.up * force, ForceMode2D.Impulse);
	}
}
