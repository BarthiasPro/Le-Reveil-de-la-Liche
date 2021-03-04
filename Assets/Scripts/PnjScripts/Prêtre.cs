using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prêtre : PNJ
{
    public string dialogText_1;
    public string dialogText_2;
    public string dialogText_3;
    public string dialogText_4;
    public string dialogText_5;
    public string dialogText_6;
    public Lich lich;

    // Start is called before the first frame update
    void Start()
    {
        pnjID = 2;
        pnjName = "Prêtre";
        dialogText_1 = "Une liche s'est établie au nord-ouest et menace cet endroit, peut tu nous en débarasser, tu devrais commencer par trouver une arme ?";
        dialogText_2 = "Le magasin est ouvert, le marchand vend peut être des armes...";
        dialogText_3 = "Je n'ai pas d'argent sur moi, mais le bûcheron au sud-est doit avoir du travail à te confier";
        dialogText_4 = "gg";
        dialogText_5 = "Cette épée fera l'affaire, bonne chance, notre destin repose entre tes mains";
        dialogText_6 = "Tu es blessé, laisse moi te soigner avant ton combat";
    }


    public override void Speak()
    {
        ui.DisableInteractText();
        if(database.Completed("KillTheLich") == false )
        {
            if(database.Quests.ContainsKey("KillTheLich"))
            {
                if (player.HasSword())
                {
                    if(player.curHp < player.maxHp)
                    {
                        Tell(dialogText_6);
                        player.Heal();
                    }
                    else
                    {
                        Tell(dialogText_5);
                    }
                }
                else
                {
                    if(player.HasGold())
                    {
                        Tell(dialogText_2);
                    }
                    else
                    {
                        Tell(dialogText_3);
                    }                    
                }
            }
            else
            {
                GiveQuest("KillTheLich");
                lich.gameObject.SetActive(true);
                if (player.HasSword() == false)
                {
                    GiveQuest("GetSword");
                }
                Tell(dialogText_1);                
            }
        }
        else
        {            
            Tell(dialogText_4);           
        }
    }
}
