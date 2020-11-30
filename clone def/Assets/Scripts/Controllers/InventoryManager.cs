using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;


    private void Start()
    {
        instance = this;
    }

    public class InventoryP
    {
        public int lifePlayer;
        public int shot;


        public InventoryP()
        {
            lifePlayer = 100;
            shot = 0;

        }
    }

    public List<InventoryP> playersList = new List<InventoryP>();

    public void InitInventorys()
    {
        for (int i = 0; i < 2; i++)
        {
            playersList.Add(new InventoryP());
        }
    }

    public void resetInventory()
    {
        for(int i = 0; i < 2; i++) { 
            playersList[i].lifePlayer = 100;
            playersList[i].shot = 0;

        }
    }

    public int damageLife(int idPlayer, int damageValue)
    {
        return playersList[idPlayer].lifePlayer -= damageValue;
    }


}