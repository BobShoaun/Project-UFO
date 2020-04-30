using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UFOGUI : MonoBehaviour {

    [SerializeField] private UFO ufo;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        
    }

    private void Update() {
        healthText.text = "Health: " + ufo.Health;
    }


}
