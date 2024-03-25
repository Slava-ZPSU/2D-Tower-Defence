using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    // Visible fields
    [SerializeField]
    private TextMeshProUGUI timerText;

    // Invisible fields
    public float timer = 0.0f;

    private void Awake()
    {
        timerText = transform.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        DisplayTime();
    }

    private void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
