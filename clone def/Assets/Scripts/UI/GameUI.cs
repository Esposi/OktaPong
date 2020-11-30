using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public Text[] textName;
    public GameObject[] textGOName;
    public Text[] textLife;
    public Image[] lifeBar;

    public Text skill;

    private float newHealth;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLifeInfo(int lifePlayer, int playerToChange)
    {
        textLife[playerToChange].text = lifePlayer+"%";
    }

    public void setLifeBar(int lifePlayer, int playerToChange)
    {
        newHealth = (float)lifePlayer / 100;
        lifeBar[playerToChange].transform.localScale= new Vector3(newHealth, 1, 1);

        if(newHealth<=0.25)lifeBar[playerToChange].color = new Color32(255, 0, 0, 100);
        else lifeBar[playerToChange].color = new Color32(0, 255, 0, 100);
    }

    public void TurnOFTitlePlayerText()
    {
        for (int i = 0; i < 2; i++) textGOName[i].SetActive(false);
    }
    public void TurnOnTitlePlayerText()
    {
        for (int i = 0; i < 2; i++) textGOName[i].SetActive(true);
    }

    public void SetSkillText(int idSkill)
    {
        skill.text = "Skill: " + idSkill;
    }







}
