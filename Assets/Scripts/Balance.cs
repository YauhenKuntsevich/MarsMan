using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
   private long _money = 20;

    public long Money
    {
        get => _money;
        set => _money = value;
    }
}
