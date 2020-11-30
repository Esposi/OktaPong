using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour
{


    public int start;

    public GameObject img1;
    public GameObject img2;
    public GameObject StartGameObject;
    public GameObject DrawGameObject;

    [SerializeField]
    private Button Player1Dice;

    [SerializeField]
    private Button Player2Dice;

    [SerializeField]
    private Button AgainButton;
    
    [SerializeField]
    private Button StartButton;

    [SerializeField]
    public Text[] PlayerDiceText;

    [SerializeField]
    public Text PlayerWinDiceText;

    // Start is called before the first frame update
    void Start()
    {


        setTurnCheck();
        Player1Dice.onClick = new Button.ButtonClickedEvent();
        Player1Dice.onClick.AddListener(
            delegate
            {
                UIManager.Instance.SetTurn(0);
                Player1Dice.GetComponent<Button>().enabled = false;
                img1.SetActive(false);
                start++;
            });



        Player2Dice.onClick = new Button.ButtonClickedEvent();
        Player2Dice.onClick.AddListener(
            delegate
            {
                UIManager.Instance.SetTurn(1);
                Player2Dice.GetComponent<Button>().enabled = false;
                img2.SetActive(false);
                start++;

            });

        AgainButton.onClick = new Button.ButtonClickedEvent();
        AgainButton.onClick.AddListener(
            delegate
            {
                setTurnCheck();
                DrawGameObject.SetActive(false);

            });
        
        StartButton.onClick = new Button.ButtonClickedEvent();
        StartButton.onClick.AddListener(
            delegate
            {
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.TURNUI);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.GAMEUI);


            });
    }

    void Update()
    {
        CheckStart();
    }

    //works after the players check his turns
    private void CheckStart()
    {
        if (start == 2) UIManager.Instance.setFirstPlayer();
    }

    //uimanager set active the "start game object"
    public void ActiveStartGame()
    {
        StartGameObject.SetActive(true);
        PlayerWinDiceText.text = "Player " + (UIManager.Instance.PlayerWithFirstMove + 1)  + " First Move";
    }

    //set dice text
    public void setValueDice(int playerNumber, int value)
    {
        PlayerDiceText[playerNumber].text = "" + value;
    }


    //restarts inicial UI values with dices draw values
    public void setTurnCheck()
    {
        StartGameObject.SetActive(false);
        start = 0;
        Player1Dice.GetComponent<Button>().enabled = true;
        Player2Dice.GetComponent<Button>().enabled = true;
        img1.SetActive(true);
        img1.SetActive(true);
        PlayerDiceText[0].text = "?";
        PlayerDiceText[1].text = "?";
    }

}
