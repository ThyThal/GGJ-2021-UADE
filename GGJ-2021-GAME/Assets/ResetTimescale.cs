﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimescale : MonoBehaviour
{
    public void ResetTime()
    {
        if (GameManager.Instance.isIngame)
        {
            Time.timeScale = 1;
            GameManager.Instance.PauseGame();
            GameManager.Instance.isIngame = false;
        }
    }
}
