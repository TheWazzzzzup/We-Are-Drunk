using UnityEngine;

public class CheckShakerMinigameCollisions : MonoBehaviour
{
    public ShakerLocation Location { get; private set; } // The current location of the shaker (based on triggers)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("No"))
        {
            Location = ShakerLocation.No;
        }
        if (collision.CompareTag("Little"))
        {
            Location = ShakerLocation.Little;
        }
        if (collision.CompareTag("Medium"))
        {
            Location = ShakerLocation.Medium;
        }
        if (collision.CompareTag("Heavy"))
        {
            Location = ShakerLocation.Heavy;
        }
    }

}

public enum ShakerLocation
{
    No,
    Little,
    Medium,
    Heavy
}
