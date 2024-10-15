using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] private PlayerController player;
    
    private void Update()
    {
        healthText.text = player.GetHealth().ToString(CultureInfo.InvariantCulture);
        ammoText.text = player.GetCurrentAmmo().ToString(CultureInfo.InvariantCulture);
    }
}
