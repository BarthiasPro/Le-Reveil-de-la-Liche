using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucheron : PNJ
{
    public string dialogText_1;
    public string dialogText_2;
    public string dialogText_3;
    public string dialogText_4;
    public string dialogText_5;
    public Wolf wolf;

    // Start is called before the first frame update
    void Start()
    {
        pnjID = 1;
        pnjName = "Bûcheron";
        dialogText_1 = "Je ne peux plus travailler à cause du loup devant le grand Chêne. Si tu m'en débarasse je te paierais une pièce d'or";
        dialogText_2 = "Bonne chance aventurier, ce loup est dangereux";
        dialogText_3 = "Oh merci, grâce à toi je vais pouvoire reprendre le travail, voici ton paiement comme convenu";
        dialogText_4 = "Il parait que le vendeur dans la boutique a des armes à vendre, tu devrais mieux t'équiper pour la suite";
    }

    // Update is called once per frame
  

    public override void Speak()
    {
        ui.DisableInteractText();
        if(database.Completed("HuntTheWolf") == false )
        {
            if(database.Quests.ContainsKey("HuntTheWolf"))
            {
                Tell(dialogText_2);
            }
            else
            {
                Tell(dialogText_1);
                GiveQuest("HuntTheWolf");
                wolf.gameObject.SetActive(true);
            }

        }
        else
        {
            if (database.Completed("SpeakToLumberjack") == false)
            {
                Tell(dialogText_3);
                EventController.PnjTalked(pnjID);
            }
            else
            {
                Tell(dialogText_4);
            }
        }
    }    
}
