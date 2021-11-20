using UnityEngine;
public class CanvasManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject GameCanvas;
    public GameObject UpgradeCanvas;
    void Start()
    {
        toMenu();
    }
    public void toMenu()
    {
        everythingOff();
        MenuCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void toGame()
    {
        everythingOff();
        GameCanvas.GetComponent<Canvas>().enabled = true;
        GameplayManager.instance.startGame();
    }
    public void toUpgrades()
    {
        everythingOff();
        UpgradeManager.instance.RefreshUpgrades();
        UpgradeCanvas.GetComponent<Canvas>().enabled = true;
    }
    private void everythingOff()
    {
        MenuCanvas.GetComponent<Canvas>().enabled = false;
        GameCanvas.GetComponent<Canvas>().enabled = false;
        UpgradeCanvas.GetComponent<Canvas>().enabled = false;
    }
}
