using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI ammo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateUI()
    {
        ammo.text = "Ammo: " + GetComponent<MyPlayer>().currentAmmo;
    }
}
