using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private int[] playerValueDice;
    public int PlayerWithFirstMove;


    private MainMenuUI MainMenuScript;
    private TurnUI TurnUIScript;
    private AfterGameUI AfterGameUIScript;
    private GameUI GameUIScript;
    private ChoseLvlUI ChoseLvlUIScript;

    //open and close UI
    public enum BUTTONS
    {
        MAINMENU = 1,
        AFTERGAME = 2,
        GAMEUI = 3,
        TURNUI =4,
        CHOSELVL = 5,
    }

    [System.Serializable]
    public class UIScreen
    {
        public GameObject m_pScreenObject;
        public BUTTONS m_pScreen;
    }

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerValueDice = new int[2];

        FindUIScripts();

    }

    //set UIs to be managed in UIManager

    private void FindUIScripts()
    {
        MainMenuScript = FindObjectOfType<MainMenuUI>();
        TurnUIScript = FindObjectOfType<TurnUI>();
        GameUIScript = FindObjectOfType<GameUI>();
        AfterGameUIScript = FindObjectOfType<AfterGameUI>();
        ChoseLvlUIScript = FindObjectOfType<ChoseLvlUI>();
    }

    // Screen management
    [SerializeField]
    private List<UIScreen> m_pScreens = new List<UIScreen>();

    public void OpenScreen(BUTTONS pScreen)
    {
        GetScreenObject(pScreen).SetActive(true);
    }

    public void CloseScreen(BUTTONS pScreen)
    {

        GetScreenObject(pScreen).SetActive(false);
    }

    public GameObject GetScreenObject(BUTTONS pScreen)
    {
        UIScreen UI = m_pScreens.Find(screen => screen.m_pScreen == pScreen);
        return UI.m_pScreenObject;
    }

    ///TURN UI
    public void EnableTurnUI()
    {
        TurnUIScript.enabled = true;
        TurnUIScript.setTurnCheck();

    }

    
    //set value dice in players int array and send the dice value to text gameui script

    public void SetTurn(int player)
    {
        playerValueDice[player]=SendRandomNumber();

        TurnUIScript.setValueDice(player, playerValueDice[player]);
    }

    int SendRandomNumber()
    {
        return Random.Range(1, 21);        
    }

    public void setFirstPlayer()
    {
        //if the dices draw the turn check will restart
        if (playerValueDice[0] == playerValueDice[1])
        {
            TurnUIScript.DrawGameObject.SetActive(true);
        }
        else
        {
            if (playerValueDice[0] > playerValueDice[1])
            {

                PlayerWithFirstMove = 0;
                TurnUIScript.ActiveStartGame();

            }
            else
            {
                PlayerWithFirstMove = 1;
                TurnUIScript.ActiveStartGame();
            }


            TurnUIScript.enabled = false;

            setGameUI();
            MechanicsManager.instance.setInicialConfigs(PlayerWithFirstMove);
        }
    }



    ///GAMEUI
    
    //set life text after damage 
    public void setPlayersInfo(int lifeToSend, int idPlayer)
    {
        GameUIScript.setLifeInfo(lifeToSend, idPlayer);
        GameUIScript.setLifeBar(lifeToSend, idPlayer);

    }

    //set inicials life text
    private void setGameUI()
    {
        for (int i = 0; i < 2; i++)
        {
            GameUIScript.setLifeInfo(100, i);
            GameUIScript.setLifeBar(100, i);
        }

    }

    //turn of player text
    public void DesactivePlayerText()
    {
        GameUIScript.TurnOFTitlePlayerText();
    }
    public void ActivePlayerText()
    {
        GameUIScript.TurnOnTitlePlayerText();
    }


    //AFTERGAMEUI

    public void sendAfterGameInfos(int idPLayer, int valueShots, int valueLife)
    {
        AfterGameUIScript.setAfterGameTextPlayer(idPLayer, valueShots, valueLife);
    }      

    //CHOSEMAPUI

    public void setMap(int idMap)
    {
        MechanicsManager.instance.setMap(idMap);
    }

    public void setTextSkil(int idSkill)
    {
        GameUIScript.SetSkillText(idSkill);

    }

}
