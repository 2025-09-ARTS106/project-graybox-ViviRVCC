using Unity.VisualScripting;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.MainMenuButtons _buttonType;
    public void ButtonClciked()
    {
        MainMenuManager._.MainMenuButtonClicked(_buttonType);
    }
}
