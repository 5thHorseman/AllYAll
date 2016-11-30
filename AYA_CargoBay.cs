// ALL Y'ALL v0.5
// By 5thHorseman
// License: CC SA
// v0.1: Added "Extend All" and "Retract All" to deployable solar panels.
// v0.2: Added "Extend All" and "Retract All" to deployable radiators.
// v0.3: Added "Perform All Science" to all science instruments.
// v0.4: Fixed Surface Sample bug and added ability to perform all experiments in a part with multiple experiments
// v0.5: Fixed Mystery Goo and Science Jr running when they had not been reset.
// v0.9: (proposed) Modify UI to lessen the number of lines in right-click menus.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AllYAll
{

    // ############# CARGO BAYS ############### //

    
    public class AYA_CargoBay : PartModule
    {

        bool cargoBayOpen = false;

        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Open Bays")]
        public void DoAllBays()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleCargoBay>();
                if (thisPart != null)
                {
                    var thisPartAnimate = eachPart.FindModuleImplementing<ModuleAnimateGeneric>();
                    if (thisPartAnimate != null)
                    {
                        KSPActionParam param = new KSPActionParam(KSPActionGroup.Custom01, KSPActionType.Activate);
                        if (cargoBayOpen)
                        {
                            if (thisPartAnimate.animSwitch)
                                thisPartAnimate.ToggleAction(param);
                        }
                        else
                        {
                            if (!thisPartAnimate.animSwitch)
                                thisPartAnimate.ToggleAction(param);
                        }
                    }
                }
            }
        }

        public void FixedUpdate()
        {
            if (HighLogic.LoadedScene == GameScenes.EDITOR)
                return;


            bool  moving = false;
            cargoBayOpen = false;

            foreach (Part eachPart in vessel.Parts)                                          //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleCargoBay>();
                if (thisPart != null)
                {
                    var thisPartAnimate = eachPart.FindModuleImplementing<ModuleAnimateGeneric>();
                    if (thisPartAnimate != null)
                    {
                        if (thisPartAnimate.aniState == ModuleAnimateGeneric.animationStates.MOVING)
                        {
                            moving = true;
                            break;
                        }
                        if (thisPartAnimate.animSwitch)
                            cargoBayOpen = true;

                    }
                }
            }

            if (moving)
            {
                Events["DoAllBays"].active = false;
                return;
            }
            Events["DoAllBays"].active = true;
            if (cargoBayOpen)
                Events["DoAllBays"].guiName = "Close all bays";
            else
                Events["DoAllBays"].guiName = "Open all bays";
        }



    }  
}
