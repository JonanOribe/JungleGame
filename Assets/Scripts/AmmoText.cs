using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public TMP_Text ammoText;
    private int ammoTextVal=0;
    void Start()
    {
        ammoText = GetComponent<TMP_Text>();
    }

    public void ChangeText() {
        ammoTextVal += 1;
        ammoText.text =  ammoText.text + ammoTextVal.ToString();
    }
}
