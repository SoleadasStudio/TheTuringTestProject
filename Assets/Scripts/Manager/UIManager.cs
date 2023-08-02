using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Health playerhealth;


    void Start()
    {

    }

    private void OnEnable()
    {
        playerhealth.OnHealthUpdate += OnHealthUpdate;
    }

    private void OnDisable()
    {
        playerhealth.OnHealthUpdate -= OnHealthUpdate;
    }

    void Update()
    {

    }

    void OnHealthUpdate(float health)
    {
        healthText.text = "Health :" + Mathf.Floor(health).ToString(); /// 77.896f --> 78.0f
    }
}
