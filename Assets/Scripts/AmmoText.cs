using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public TMP_Text ammoText;
    private string ammoTextString = "Ammo: ";
    private int ammoTextVal=0;
    void Start()
    {
        ammoText = GetComponent<TMP_Text>();
    }

    public void ChangeText() {
        ammoTextVal += 1;
        ammoText.text = ammoTextString + ammoTextVal.ToString();
    }
}
