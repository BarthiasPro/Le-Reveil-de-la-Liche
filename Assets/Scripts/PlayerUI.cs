using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI interactText;
    public TextMeshProUGUI dialogText;
    public GameObject dialog;
    public Image healthBarFill;
    public Image xpBarFill;

    private Player player;

    private void Awake()
    {
        // get the player
        player = FindObjectOfType<Player>();
    }

    public void UpdateLevelText()
    {
        levelText.text = "Lvl\n" + player.curLevel;
    }

    public void UpdateHealthBar()
    {
        healthBarFill.fillAmount = (float)player.GetcurHP()/(float)player.GetmaxHP();
    }

    public void UpdateXpBar()
    {
        xpBarFill.fillAmount = (float)player.curXp / (float)player.xpToNextLevel;
    }

    public void SetInteractText(Vector3 pos, string text)
    {
        interactText.gameObject.SetActive(true);
        interactText.text = text;

        interactText.transform.position = Camera.main.WorldToScreenPoint(pos + Vector3.up);
    }

    public void SetDialog(Vector3 pos, string text)
    {
        dialog.gameObject.SetActive(true);
        dialogText.text = text;
        dialog.transform.position = Camera.main.WorldToScreenPoint(pos + Vector3.up);
        player.startTalk();
    }

    public void DisableInteractText()
    {
        if(interactText.gameObject.activeInHierarchy)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    public void DisableDialog()
    {
        if (dialog.gameObject.activeInHierarchy)
        {
            dialog.gameObject.SetActive(false);
        }
        player.stopTalk();
    }

    public void UpdateInventoryText()
    {
        inventoryText.text = "";

        foreach(string item in player.inventory)
        {
            inventoryText.text += item + "\n";
        }
    }

}
