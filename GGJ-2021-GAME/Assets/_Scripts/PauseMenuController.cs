﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private Button buttonHelp;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonGoBack;

    [Header("Menu")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] public CanvasGroup canvasGroup;
    [SerializeField] private Animator _animator;

   

    //Extras
    private bool pauseMenuActive;

    private void Awake()
    {
        GameManager.Instance.pauseMenu = this;        
    }

    void Start()
    {        
        buttonResume.onClick.AddListener(OnClickResume);
        buttonHelp.onClick.AddListener(OnClickHelp);
        buttonQuit.onClick.AddListener(OnClickQuit);
        buttonGoBack.onClick.AddListener(OnClickGoBack);
        buttonMainMenu.onClick.AddListener(OnClickMenu);
        pauseMenu.SetActive(true);
        pauseMenuActive = true;
        helpMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.IsPaused())
        {
            if (pauseMenuActive)
            {
                OnClickResume();
            } else
            {
                OnClickGoBack();
            }

            Input.ResetInputAxes();
        }
    }

    public void OnClickResume() 
    {
        GameManager.Instance.PauseGame();      
    }

    public void OnClickHelp() 
    {
        if (pauseMenuActive)
        {
            pauseMenuActive = false;
            pauseMenu.SetActive(false);
            helpMenu.SetActive(true);
        }
    }

    public void OnClickMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.levelLoader.LoadScene("Menu Scene");
        //SceneManager.LoadScene("Menu Scene");
    }

    public void OnClickGoBack() 
    {
        if (!pauseMenuActive)
        {
            pauseMenuActive = true;
            pauseMenu.SetActive(true);
            helpMenu.SetActive(false);
        }
    }

    public void OnClickQuit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
