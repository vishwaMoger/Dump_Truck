using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScrip : MonoBehaviour
{
    [Header("Timer")]
    public float TimerCount = 5f;

    [Header("things to stop")]
    public PlayerController PlayerTruck;

    public TextMeshProUGUI CountdownText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerCount > 1)
        {
            PlayerTruck.AccelerationForce = 0f;
        }
        else if (TimerCount == 0)
        {
            PlayerTruck.AccelerationForce = 300f;
           
        }
    }

    IEnumerator timer()
    {
        while (TimerCount > 0)
        {
            CountdownText.text = TimerCount.ToString();
            yield return new WaitForSeconds(1f);
            TimerCount -= 1;
        }

        CountdownText.text = "GO";
        yield return new WaitForSeconds(1f);
        CountdownText.gameObject.SetActive(false);
    }
}
