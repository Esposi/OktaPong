using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button PlayButton;
    





    void Start()
    {


        PlayButton.onClick = new Button.ButtonClickedEvent();
        PlayButton.onClick.AddListener(
            delegate
            {
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.MAINMENU);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.CHOSELVL);
                UIManager.Instance.EnableTurnUI();

            });



    }

    void Update()
    {
        
    }


}
