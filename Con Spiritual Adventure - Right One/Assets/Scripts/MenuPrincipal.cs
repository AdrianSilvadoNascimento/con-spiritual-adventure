using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    [SerializeField] private GameObject menuOptions, settingsPanel;
    [SerializeField] private int sceneIndex;
    private bool closeMenu = false;

    
    public void PlayGame() {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenCloseSettings() {
        closeMenu = !closeMenu;
        Debug.Log(closeMenu);
        if (closeMenu) {
            menuOptions.SetActive(false);
            settingsPanel.SetActive(true);
        } else {
            menuOptions.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }

    public void QuitGame() {
        Debug.Log("You Quitted");
        Application.Quit();
    }
}
