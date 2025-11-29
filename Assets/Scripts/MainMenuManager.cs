using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour

{
    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    public enum MainMenuButtons { start, credits };
    public enum CreditsButtons { back }
    [SerializeField] GameObject _MainMenuContainer;
    [SerializeField] GameObject _CreditsMenuContainer;
    [SerializeField] private string _sceneToLoadAfterClickingPlay;
    [SerializeField] private AudioClip Buttonback;
    public void Awake()
    {
        if (_ == null)
        {
            _ = this;

        }
        else
        {
            Debug.LogError("There are more than 1 MainMenuManager's in the Scene");
        }
    }
    private void Start()
    {
        OpenMenu(_MainMenuContainer);
    }
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked:" + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.start:
                PlayClicked();
                break;
            case MainMenuButtons.credits:
                CreditsClicked();
                break;
            default:
                Debug.Log("Button clicked tha wasnt implemented in MainMenuManager Method");
                break;
        }
    }

    public void CreditsClicked()
    {
        OpenMenu(_CreditsMenuContainer);
    }

    public void ReturnToMainMenu()
    {
        OpenMenu(_MainMenuContainer);
    }


    public void CreditsButtonClicked(CreditsButtons buttonClicked)
    {
        switch(buttonClicked)
        {
            case CreditsButtons.back:
                ReturnToMainMenu();
                SoundEffectsManager.instance.PlaySoundFXClip(Buttonback, transform, 1f);
                break;
        }
    }
    private void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }
    }
    public void PlayClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay);
    }
    public void OpenMenu(GameObject menuToOpen)
    {
        _MainMenuContainer.SetActive(menuToOpen == _MainMenuContainer);
        _CreditsMenuContainer.SetActive(menuToOpen == _CreditsMenuContainer);
    }
}
