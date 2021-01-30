﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public void Break()
    {
        GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 0.1f);
    }

    public void Reset()
    {
        GetComponent<Image>().color = Color.white;
    }
}