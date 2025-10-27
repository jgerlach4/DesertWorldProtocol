using TMPro;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private GameObject itemInRange;
    public GameObject heldWeapon; // The weapon that appears after pickup (set in Inspector)
    public TMP_Text interactText; // Reference to the UI text element (set in Inspector)
    void Start()
    {
        // Ensure the interact text is hidden at the start
        if (interactText != null)
        {
            interactText.enabled = false;
        }
    }

    // Called automatically when another collider enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show interact text
            if (interactText != null)
            {
                interactText.enabled = true;
            }
            itemInRange = this.gameObject;
        }
    }
    // Optional: when object stays inside trigger
    private void OnTriggerStay(Collider other)
    {
        // Runs every frame while inside
        if (Input.GetKey(KeyCode.E))
        {
            // Set held weapon to active
            if (heldWeapon != null) 
            {
                heldWeapon.SetActive(true);
            }
            // Disable pickup object
            itemInRange.SetActive(false);

        }
    }
    // Optional: when object exits trigger
    private void OnTriggerExit(Collider other)
    {
        if (interactText != null)
        {
            interactText.enabled = false;
        }
    }
}
