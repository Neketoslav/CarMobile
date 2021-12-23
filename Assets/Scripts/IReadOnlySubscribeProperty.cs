using System;

public interface IReadOnlySubscribeProperty<T>
{
    T Value { get; }

    void SubscribeOnChange(Action<T> subscribeAction);
    void UnSubscribeOnChange(Action<T> unSubscribeAction);

}
