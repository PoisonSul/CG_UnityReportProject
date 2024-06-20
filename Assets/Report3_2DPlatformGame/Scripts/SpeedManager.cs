using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public bool reversing = false;
    public static SpeedManager Instance { get; private set; }

    void Awake()
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

    public void AddSpeedToAll(float amount)
    {
        BroadcastMessage(nameof(TileLooping.SpeedChange), amount, SendMessageOptions.DontRequireReceiver);
    }
    public void ReverseSpeedToAll()
    {
        Debug.Log("rtyry");
        if (!reversing)
        {
            reversing = true;
            BroadcastMessage(nameof(TileLooping.SpeedReverse), SendMessageOptions.DontRequireReceiver);
            Invoke(nameof(CoolDown), 2f);
        }
    }
    public void StopNow()
    {
        BroadcastMessage(nameof(TileLooping.SpeedStop), SendMessageOptions.DontRequireReceiver);
    }

    private void CoolDown()
    {
        reversing = false;
        BroadcastMessage(nameof(TileLooping.SpeedReverse), SendMessageOptions.RequireReceiver);
        CancelInvoke();
    }
}
