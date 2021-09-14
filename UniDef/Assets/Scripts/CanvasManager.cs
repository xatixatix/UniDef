using UnityEngine;
public class CanvasManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject GameCanvas;
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
    private void everythingOff()
    {
        MenuCanvas.GetComponent<Canvas>().enabled = false;
        GameCanvas.GetComponent<Canvas>().enabled = false;
    }
}
