using UnityEngine;
using System;

public class ClockTime : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hourRotation = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f;
        float minuteRotation = currentTime.Minute * 6f;
        float secondRotation = currentTime.Second * 6f;

        hourHand.localRotation = Quaternion.Euler(0, 0, -hourRotation);
        minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteRotation);
        secondHand.localRotation = Quaternion.Euler(0, 0, -secondRotation);
    }
}
