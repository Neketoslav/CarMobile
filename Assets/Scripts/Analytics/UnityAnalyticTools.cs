using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnalyticTools : IAnalyticTools
{
    public void SendMessage(string nameEvent)
    {
        Analytics.CustomEvent(nameEvent);
    }

    public void SendMessage(string nameEvent, IDictionary<string, object> eventData)
    {
        if (eventData == null)
            eventData = new Dictionary<string, object>();
        Analytics.CustomEvent(nameEvent, eventData);
    }
}
