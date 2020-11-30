using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{
    private bool deleteCapsules;
    public GameObject [] playerToEnable;
    private int playerToPlay;
    public GameObject[] startPosition;
    public GameObject[] mapsPrefabs;
    private GameObject theMap;

    private int idSkill=1;

    public GameObject[] projectilesGO;

    private int lifeToSend;


    private InventoryManager InventoryManagerScript;


    public static MechanicsManager instance;

    void Start()
    {
        instance = this;

        playerToEnable = new GameObject[2];
        SetPlayers();
        InventorySetup();

    }

    //reset the board deleting the projectiles
    void Update()
    {
        if (deleteCapsules) Destroy(GameObject.FindGameObjectWithTag("Projectile"));

        SkillPlayer();

    }

    //set projectile do player
    private void SkillPlayer()
    {
        if (Input.GetKeyDown("1"))
        {
            idSkill = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            idSkill = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            idSkill = 3;
        }
        if (Input.GetKeyDown("4"))
        {
            idSkill = 4;
        }

        UIManager.Instance.setTextSkil(idSkill);
        playerToEnable[playerToPlay].GetComponent<PlayerController>().projectileObject = projectilesGO[idSkill - 1];

    }

    //starts inventory
    private void InventorySetup()
    {
        InventoryManagerScript = FindObjectOfType<InventoryManager>();
        InventoryManagerScript.InitInventorys();
    }

    //find players and set id number
    private void SetPlayers()
    {
        for (int i=0; i < 2; i++) { 
            playerToEnable[i] = GameObject.Find("Player"+(i+1));
            playerToEnable[i].GetComponent<PlayerController>().setPlayerId(i);
        }
    }

    //set inicial config to game after dices check
    public void setInicialConfigs(int diceWinner)
    {
        ActivePlayers();
        deleteCapsules = false;
        playerToPlay = diceWinner;
        ChangeTurn();
        setInicialPosition();
        InventoryManagerScript.resetInventory();
        UIManager.Instance.ActivePlayerText();
    }

    //set inicial players position in board
    public void setInicialPosition()
    {
        for (int i = 0; i < 2; i++)
        {
            playerToEnable[i].transform.position = startPosition[i].transform.position;
        }

    } 

    //set map


    public void setMap(int id)
    {
        theMap = Instantiate(mapsPrefabs[id], new Vector3(-2.8f,0.45f,0), Quaternion.identity);
        theMap.transform.parent= GameObject.Find("Board").transform;
        theMap.SetActive(true);
    }

    //set player turn
    public void ChangeTurn()
    {
        playerToEnable[playerToPlay].GetComponent<PlayerController>().enabled = true;
    }

    public void endTurn()
    {
        playerToEnable[playerToPlay].GetComponent<PlayerController>().enabled = false;
        InventoryManagerScript.playersList[playerToPlay].shot++;
        UIManager.Instance.DesactivePlayerText();
        if (playerToPlay == 0) playerToPlay = 1;
        else playerToPlay = 0;
        ChangeTurn();

    }

    //damage mechanic, check death and change gameUI
    public void dealDamage(int idPlayer, int damageValue)
    {
        lifeToSend= InventoryManagerScript.damageLife(idPlayer, damageValue);
        UIManager.Instance.setPlayersInfo(lifeToSend, idPlayer);
        checkDeath(idPlayer);

    }

    
    public void checkDeath(int idPlayer)
    {
        if (InventoryManagerScript.playersList[idPlayer].lifePlayer <= 0)
        {
            SetActiveResultGameScreen();
            sendUIAfterGameValues();
            DesactivePlayers();
            deleteCapsules = true;
            DesactivePlayersMovement();
            DesactiveMap();
        }
    }

    private void DesactiveMap()
    {
        Destroy(theMap);
    }

    private void sendUIAfterGameValues()
    {
        for(int i=0;i<2;i++) UIManager.Instance.sendAfterGameInfos(i, InventoryManagerScript.playersList[i].shot, InventoryManagerScript.playersList[i].lifePlayer);
    }

    private void SetActiveResultGameScreen()
    {
        UIManager.Instance.CloseScreen(UIManager.BUTTONS.GAMEUI);
        UIManager.Instance.OpenScreen(UIManager.BUTTONS.AFTERGAME);
    }

    //set active players
    private void ActivePlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            playerToEnable[i].SetActive(true);
        }
    }
    private void DesactivePlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            playerToEnable[i].SetActive(false);
        }
    }
    private void DesactivePlayersMovement()
    {
        for (int i = 0; i < 2; i++)
        {
            playerToEnable[i].GetComponent<PlayerController>().enabled=false;
        }
    }


}
