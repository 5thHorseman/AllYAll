
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AllYAll
{

    // ############# REACTION WHEELS ############### //

    public class AYA_SAS : PartModule
    {

        bool activeReactionWheel = false;

        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Activate All")]
        public void DoAllReactionWheel()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleReactionWheel>();

                KSPActionParam kap = new KSPActionParam(KSPActionGroup.Custom01, KSPActionType.Activate);

                if (thisPart != null)
                {
                    if (activeReactionWheel)
                        thisPart.Deactivate(kap);
                    else
                        thisPart.Activate(kap);
                }
            }
        }


        public void FixedUpdate()
        {
            if (HighLogic.LoadedScene == GameScenes.EDITOR)
                return;
            activeReactionWheel = false;
            foreach (Part eachPart in vessel.Parts)                                          //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleReactionWheel>();  
                if (thisPart != null)
                {
                    if (thisPart.State == ModuleReactionWheel.WheelState.Active)
                    {
                        activeReactionWheel = true;
                        break;
                    }
                }
            }
            
            if (activeReactionWheel)
                Events["DoAllReactionWheel"].guiName = "Deactivate All SAS";
            else
                Events["DoAllReactionWheel"].guiName = "Activate All SAS";
            
        }
    }
}