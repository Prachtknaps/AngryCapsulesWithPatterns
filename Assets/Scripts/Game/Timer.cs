using System.Collections.Generic;

public class Timer : Observable
{
    private List<Observer> observers = new List<Observer>();
    private float totalTime = 0.0f;
    private float timeRemaining = 0.0f;

    public Timer(float time)
    {
        this.totalTime = time;
        this.timeRemaining = time;
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (Observer observer in observers)
        {
            observer.UpdateObserver();
        }
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public void RemoveTime(float time)
    {
        timeRemaining -= time;
        Notify();
        if (timeRemaining == -1)
        {
            GameManager.Instance.SetState(new GameOverState());
        }
    }

    public float GetTime()
    {
        return timeRemaining;
    }
}
