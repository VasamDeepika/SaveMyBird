using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject optionPanel;
    public GameObject topPanel,middlePANEL,helpPanel;
    public void OptionsMenu()
    {
        optionPanel.SetActive(true);
        topPanel.SetActive(false);
        middlePANEL.SetActive(false);
    }
    public void Back()
    {
        optionPanel.SetActive(false);
        topPanel.SetActive(true);
        middlePANEL.SetActive(true);
        helpPanel.SetActive(false);
    }
    public void Help()
    {
        optionPanel.SetActive(false);
        topPanel.SetActive(false);
        middlePANEL.SetActive(false);
        helpPanel.SetActive(true);
    }
}
