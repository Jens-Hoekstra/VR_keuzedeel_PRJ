using UnityEngine;
using System;

public class WristWatchClock_Debug2 : MonoBehaviour
{
    public Transform hourHand;    // assign HourPivot
    public Transform minuteHand;  // assign MinutesPivot
    public Transform secondHand;  // assign SecondsPivot (optional)

    [Header("If the displayed time is wrong, adjust this offset (hours)")]
    public float timezoneOffsetHours = 0f; // e.g. +1 for CET if needed

    public enum Axis { X, Y, Z }
    public Axis rotateAxis = Axis.Z;
    public bool invert = true; // set false if it spins the other way

    [Header("Debugging")]
    public bool logEverySecond = true;

    DateTime lastLogged = DateTime.MinValue;


    void Start()
    {
        if (hourHand == null || minuteHand == null)
        {
            Debug.LogError("[ClockDebug2] Assign hourHand and minuteHand (use the Pivot objects). Script disabled.");
            enabled = true;
            return;
        }
        Debug.Log("[ClockDebug2] Started. Assigned: H=" + hourHand.name + " M=" + minuteHand.name + (secondHand ? " S=" + secondHand.name : ""));
    }

    void Update()
    {
        // Get system local time and apply optional timezone offset
        DateTime now = DateTime.Now.AddHours(timezoneOffsetHours);

        // compute smooth angles
        float hourFraction = (now.Hour % 12) + now.Minute / 60f + now.Second / 3600f;
        float hourAngle = hourFraction * 30f; // 360/12 = 30

        float minuteFraction = now.Minute + now.Second / 60f + now.Millisecond / 60000f;
        float minuteAngle = minuteFraction * 6f; // 360/60 = 6

        float secondFraction = now.Second + now.Millisecond / 1000f;
        float secondAngle = secondFraction * 6f;

        ApplyRotation(hourHand, hourAngle);
        ApplyRotation(minuteHand, minuteAngle);
        if (secondHand) ApplyRotation(secondHand, secondAngle);

        // optional per-second logging to check values
        if (logEverySecond && lastLogged.Second != now.Second)
        {
            lastLogged = now;
            Debug.Log($"[ClockDebug2] Time={now:HH:mm:ss.fff}  HourA={hourAngle:F2} MinA={minuteAngle:F2} SecA={secondAngle:F2}");
        }
    }

    void ApplyRotation(Transform t, float angleDegrees)
    {
        if (t == null) return;

        // choose sign based on invert
        float signed = invert ? -angleDegrees : angleDegrees;

        Vector3 e = t.localEulerAngles;
        switch (rotateAxis)
        {
            case Axis.X: e.x = signed; break;
            case Axis.Y: e.y = signed; break;
            case Axis.Z: e.z = signed; break;
        }
        t.localEulerAngles = e;
    }
}
