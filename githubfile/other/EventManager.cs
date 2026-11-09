using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }


    public Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void addEvent(string eventName, Action function) 
    {
        eventDictionary.Add(eventName, function);
    }
    public Action GetAction(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out var Action))
        {
            return Action;
        }
        return null;
    }
    public void removeAction(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            eventDictionary.Remove(eventName);
        }
    }

    public void TriggerEvent(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent?.Invoke();
        }
    }













}
