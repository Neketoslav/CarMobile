using System.Collections.Generic;

public interface IAnalyticTools
{
    void SendMessage(string nameEvent);
    void SendMessage(string nameEvent, IDictionary<string, object> eventData = null);
}

