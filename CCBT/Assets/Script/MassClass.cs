using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MassClass
{
    public AudioClip audio;
    public int ID;
    public bool Bomb;
   [NonSerialized]public bool isClear = false;
}

