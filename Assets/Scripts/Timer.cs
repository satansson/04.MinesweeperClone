using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

    public void ResetTimer()
    {
        stopwatch.Reset();
    }

    public void StartTimer()
    {
        ResetTimer();
        stopwatch.Start();
    }

    public void StopTimer()
    {
        stopwatch.Stop();
    }

    public int GetCurrentTime()
    {
        return (int)(stopwatch.ElapsedMilliseconds / 1000f);
    }

    public void FixedUpdate()
    {
        int curretnTime = GetCurrentTime();
        timerText.text = curretnTime.ToString();
    }
}
