using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public void AddSpeedToAll(float amount)
    {
        SendMessage(nameof(TileLooping.SpeedChange), amount, SendMessageOptions.DontRequireReceiver);
    }

    public void ReverseSpeedToAll()
    {
        SendMessage(nameof(TileLooping.SpeedReverse), SendMessageOptions.DontRequireReceiver);
    }
}
