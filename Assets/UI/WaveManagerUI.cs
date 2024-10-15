using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;

    private void Update()
    {
        waveText.text = "Current Wave: 00000";
    }
}
