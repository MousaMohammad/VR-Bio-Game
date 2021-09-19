using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
this script is used to simplify the Tutorial process to make the gameplay more descriptive.
all what you need is to add statements that describe your scene mechanics or any gameplay tip you want.
then you can override the TutorialSkip to activate spawners or any script you have disactivated
*********************************************************************************/

public class ImmuneTutorial : Tutorial
{
    [HideInInspector]
    //  Remove those strings and add strings that describes your scene mechanics
    //  like what should the player do in your scene
    //  or how can he play? how can he increase the state that is related to your scene
    //  [Note]: try writing each statement you add at the text in the Tutorial Tablet 
    //          to make sure that it fits the text box size
    public string[] ImmuneTutorialScripts = new string[] {
    "Some pathogens have invaded you body\n You need to kill them before they become invincible",
    "You are now in control of your immune system \n the pathogens have already took control over your first two lines of defense",
    "You have 3 types of weapons",
    "The sword simulates our T cells. once it encounters a foreign body, it releases cytotoxic factors. \n causing all infected cells to be self-destructed.",
    "BE CAREFUL! only cells infected by pathogens are affected.",
    "The gun fires antibodies and kills the targeted pathogens.",
    "The pills help boost your immune system and git rid of pathogens and infected cells for a while.",
    "Once the virus enters your body, it does not have a host yet.\n this your chance to neutralize them with antiboies. such pathogens may look like: ",
    "If the virus attaches itself to a host, they become harder to kill.\n now you have to kill the infected cells, such cells look like: ",
    "BEWARE! killing healthy cells deteriorates your health and reduces your score.",
    "Let's go!"
    };
    new void Start()
    {
        base.Start();
        TutorialScripts = new string[] {
    "Some pathogens have invaded you body\n You need to kill them before they become invincible",
    "You are now in control of your immune system \n the pathogens have already took control over your first two lines of defense",
    "You have 3 types of weapons",
    "The sword simulates our T cells. once it encounters a foreign body, it releases cytotoxic factors. \n causing all infected cells to be self-destructed.",
    "BE CAREFUL! only cells infected by pathogens are affected.",
    "The gun fires antibodies and kills the targeted pathogens.",
    "The pills help boost your immune system and git rid of pathogens and infected cells for a while.",
    "Once the virus enters your body, it does not have a host yet.\n this your chance to neutralize them with antiboies. such pathogens may look like: ",
    "If the virus attaches itself to a host, they become harder to kill.\n now you have to kill the infected cells, such cells look like: ",
    "BEWARE! killing healthy cells deteriorates your health and reduces your score.",
    "Let's go!"
    };

    }
    new void Update()
    {
        base.Update();
    }

    public override void TutorialSkip()
    {
        base.TutorialSkip();

        // remove the next line override the method however you want
        Debug.Log("Immune Tutorial");
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
    }
}
