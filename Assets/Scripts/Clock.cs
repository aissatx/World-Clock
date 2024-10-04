using UnityEngine;
using System;

public class Clock : MonoBehaviour {
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    public int timeZoneOffset;  // Time zone offset in hours

    void Update () {
        // Get the current UTC time
        DateTime utcTime = DateTime.UtcNow;

        // Apply the time zone offset to get the local time for this clock
        DateTime localTime = utcTime.AddHours(timeZoneOffset);

        // Calculate the time span from the start of the day
        TimeSpan time = localTime.TimeOfDay;

        // Set the rotations for the clock hands based on the local time
        hoursPivot.localRotation = 
            Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = 
            Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = 
            Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}
