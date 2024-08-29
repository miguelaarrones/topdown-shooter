using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { Health, Ammo, Coin }
    public PickupType pickupType;
    public int amount = 1;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            switch (pickupType)
            {
                case PickupType.Health:
                    player.AddHealth(amount);
                    break;
                case PickupType.Ammo:
                    player.AddAmmo(amount);
                    break;
                case PickupType.Coin:
                    player.AddCoins(amount);
                    break;
            }

            Destroy(gameObject);
        }
    }
}