using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AfterGameUI : MonoBehaviour
{

    [SerializeField]
    private Button PlayAgainButton;

    [SerializeField]
    private Button MainMenuButton;

    public static AfterGameUI instance;


    public Text[] lifeText;
    public Text[] shotText;


    void Start()
    {
        instance = this;



        PlayAgainButton.onClick = new Button.ButtonClickedEvent();
        PlayAgainButton.onClick.AddListener(
            delegate
            {
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.AFTERGAME); 
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.CHOSELVL);
                UIManager.Instance.EnableTurnUI();
                
                
            });

        MainMenuButton.onClick = new Button.ButtonClickedEvent();
        MainMenuButton.onClick.AddListener(
            delegate
            {
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.AFTERGAME);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.MAINMENU);
                
            });


    }

    public void setAfterGameTextPlayer(int idPLayer,int valueShots, int valueLife)
    {
        lifeText[idPLayer].text = valueLife+"%";
        shotText[idPLayer].text = valueShots + "x";
    }
}
