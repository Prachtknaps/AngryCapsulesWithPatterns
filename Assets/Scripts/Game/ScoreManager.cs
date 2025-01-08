using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Observable
{
    private List<Observer> observers = new List<Observer>();
    private int score = 0;

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

    public void AddPoints(int points)
    {
        score += points;
        Notify();
    }

    public int GetScore()
    {
        return score;
    }
}
