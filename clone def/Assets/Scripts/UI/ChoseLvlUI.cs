using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLvlUI : MonoBehaviour
{

    [SerializeField]
    private Button map1Button;

    [SerializeField]
    private Button map2Button;

    [SerializeField]
    private Button map3Button;

    // Start is called before the first frame update
    void Start()
    {

        map1Button.onClick = new Button.ButtonClickedEvent();
        map1Button.onClick.AddListener(
            delegate
            {
                UIManager.Instance.setMap(0);
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.CHOSELVL);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.TURNUI);
            });

        map2Button.onClick = new Button.ButtonClickedEvent();
        map2Button.onClick.AddListener(
            delegate
            {
                UIManager.Instance.setMap(1);
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.CHOSELVL);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.TURNUI);
            });

        map3Button.onClick = new Button.ButtonClickedEvent();
        map3Button.onClick.AddListener(
            delegate
            {
                UIManager.Instance.setMap(2);
                UIManager.Instance.CloseScreen(UIManager.BUTTONS.CHOSELVL);
                UIManager.Instance.OpenScreen(UIManager.BUTTONS.TURNUI);
                ;
            });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
