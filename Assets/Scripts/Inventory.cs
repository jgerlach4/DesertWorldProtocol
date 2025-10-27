using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int numWeapons;

    void Start()
    {
        numWeapons = 3;
    }

    public void allWeaponsDestroyed(int num)
    {
        if (num == 0)
        {
            EndGame();
        }
    }

    public void weaponSubtract(GameObject heldWeapon) 
    {
        Destroy(heldWeapon);
        numWeapons -= 1;
        Debug.Log(numWeapons);
    }

    public void EndGame() 
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
