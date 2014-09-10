using UnityEngine;

public class AllController : MonoBehaviour
{
    public GameObject ComponentsMenu;
    public GameObject ComponentsGame;

    public void Start()
    {
        if (GameData.CurrentStatus == null)
            GameData.CurrentStatus = Status.Menu;
        switch (GameData.CurrentStatus)
        {
            case Status.Menu:
                Menu();
                break;
            case Status.Play:
                Game();
                break;
        }
    }

    public void Menu()
    {
        if (ComponentsMenu != null)
            ComponentsMenu.SetActive(true);
        if (ComponentsGame != null)
            ComponentsGame.SetActive(false);
    }

    public void Game()
    {
        if (ComponentsMenu != null)
            ComponentsMenu.SetActive(false);
        if (ComponentsGame != null)
            ComponentsGame.SetActive(true);
    }
}
