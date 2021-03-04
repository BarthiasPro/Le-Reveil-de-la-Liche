using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendeur : PNJ
{
    public string dialogText_1;
    public string dialogText_2;

    // Start is called before the first frame update
    void Start()
    {
        pnjID = 0;
        pnjName = "Vendeur";
        dialogText_1 = "Bonjour, jeune aventurier. Il ne me reste rien à vendre, à part cette épée. Elle est à toi pour une pièce d'or.";
        dialogText_2 = "Tu as fais une excellente affaire, bon courage dans ta quête.";
    }

    // Update is called once per frame
    public override void Speak()
    {
        if (player.HasSword() == false)
        {
            ui.SetDialog(this.transform.position, pnjName + ": " + dialogText_1);
            ui.DisableInteractText();

        }
        else
        {
            ui.SetDialog(this.transform.position, pnjName + ": " + dialogText_2);
            ui.DisableInteractText();
        }

    }
}
