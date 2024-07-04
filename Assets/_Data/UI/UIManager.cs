using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : Singleton<UIManager>
{
    #region Variables
    [Header("Page Management")]
    [Tooltip("The pages managed by The UI manager")]
    public List<UIPage> pages;
    [Tooltip("The index of the active page in the UI")]
    public int currentPage = 0;
    [Tooltip("The page (by index) switched to when the UI Manager starts up")]
    public int defaultPage = 0;

    [Header("Pause Settings")]
    [Tooltip("The index of the pause page in the pages list")]
    public int pausePageIndex = 1;
    [Tooltip("Whether or not to allow pausing")]
    public bool allowPause = true;
    [Header("Polish Effects")]
    [Tooltip("The effect to create when navigating between UI")]
    public GameObject navigationEffect;
    [Tooltip("The effect to create when clicking on or pressing a UI element")]
    public GameObject clickEffect;
    [Tooltip("The effect to create when the player is backing out of a Menu page")]
    public GameObject backEffect;

    // Whether the application is paused
    private bool isPaused = false;

    // A list of all UI element classes
    private List<UIelement> UIelements;

    // The event system handling UI navigation
    [HideInInspector]
    public EventSystem eventSystem;
    // The Input Manager to listen for pausing
    [SerializeField]
    private InputManager inputManager;

    #endregion

    #region Setup func
    protected override void OnEnable()
    {
        this.SetupGameManagerUiManager();
    }

    private void SetupGameManagerUiManager()
    {
        if(GameManager.Instance != null && GameManager.Instance.uiManager == null)
        {
            GameManager.Instance.uiManager = this;
        }
    }

    // Find and store all ui element in list
    private void SetupUIElements()
    {
        UIelements = FindObjectsOfType<UIelement>().ToList();
    }

    // Get the event system from scene
    private void SetupEventSystem()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        if(eventSystem == null)
        {
            Debug.LogWarning("There is no event system in the scene when you trying to use ui manager");
        }
    }

    // Setup input manager
    private void SetupInputManager()
    {
        if(inputManager == null)
        {
            this.inputManager = InputManager.Instance;
        }
        if(inputManager == null)
        {
            Debug.LogWarning("The UI manager is missing a reference to an Input Manager");
        }
    }

    // Setting pause
    public void TogglePause()
    {
        if (allowPause)
        {
            if (isPaused)
            {
                GoToPage(defaultPage);
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                GoToPage(pausePageIndex);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    // Go through all UIElement and update ui
    public void UpdateUI()
    {
        foreach(UIelement uielement in UIelements)
        {
            uielement.UpdateUI();
        }
    }

    protected override void Start()
    {
        SetupInputManager();
        SetupEventSystem();
        SetupUIElements();
        InitilizeFirstPage();
        UpdateUI();
    }

    // Set up first page 
    private void InitilizeFirstPage()
    {
        GoToPage(defaultPage);
    }
    #endregion

    private void Update()
    {
        CheckPauseInput();
    }

    // Keep track of pause btn
    private void CheckPauseInput()
    {
        if (inputManager != null)
        {
            if (inputManager.pauseButton == 1)
            {
                TogglePause();
                //Consume the input
                inputManager.pauseButton = 0;
            }
        }
    }

    // Go to a page by page index
    public void GoToPage(int pageIndex)
    {
        if (pageIndex < pages.Count && pages[pageIndex] != null)
        {
            SetActiveAllPages(false);
            pages[pageIndex].gameObject.SetActive(true);
            pages[pageIndex].SetSelectedUIDefault();
        }
    }

    // Turns all stored pages on or off depending on parameter
    public void SetActiveAllPages(bool activated)
    {
        if (pages != null)
        {
            foreach (UIPage page in pages)
            {
                if (page != null)
                    page.gameObject.SetActive(activated);
            }
        }
    }
}
