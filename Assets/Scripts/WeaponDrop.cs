using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    private GameObject itemInRange;
    public TMP_Text interactText; // Reference to the UI text element (set in Inspector)
    public GameObject heldWeapon; // The weapon that appears after pickup (set in Inspector)
    public GameObject worldWeapon; // The weapon in the world (set in Inspector)
    // public extern Inventory weaponSubtract(GameObject weapon);

    private void Start()
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
        if (other.CompareTag("Player") && heldWeapon.activeSelf)
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
        if (!heldWeapon.activeSelf) return; // Prevent dropping if no weapon is held
        // Runs every frame while inside
        if (Input.GetKey(KeyCode.E))
        {
            // Set held weapon to inactive
            if (heldWeapon != null)
            {
                heldWeapon.SetActive(false);
            }
            if (worldWeapon != null)
            {
                worldWeapon.SetActive(true);
                // weaponSubtract(heldWeapon);
                // Destroy(heldWeapon);
            }
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