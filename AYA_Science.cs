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
    // ############# SCIENCE ############### //

    public class AYA_Science : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Perform All Science")]
        public void DoAllScience()
        {
            foreach (Part eachPart in vessel.Parts)                                 //Cycle through each part on the vessel
            {
                foreach (ModuleScienceExperiment thisExperiment
                    in eachPart.FindModulesImplementing<ModuleScienceExperiment>()) //Cycle through each ModuleScienceExperiment module in the part
                {
                    if (thisExperiment != null)                                     //Only continue it if it's actually a ModuleScienceExperiment (which it should always be but hey)
                    {
                        if (thisExperiment.experimentActionName == "Take Surface Sample") //If it's a surface sample, we need to make sure it's not locked out.
                        {
                            if (ScenarioUpgradeableFacilities.GetFacilityLevel(SpaceCenterFacility.ResearchAndDevelopment) > 0) // Are you allowed to do surface samples? NOTE: 0 is tier 1. 0.5 is tier 2. 1 is tier 3. These could change if more tiers are added.
                            {
                                if (!thisExperiment.Deployed)
                                {
                                    thisExperiment.DeployExperiment(); //Deploy the experiment if it's not already deployed
                                                                       //print ("AYA: Deployed Surface Sample that had not yet been deployed");
                                }
                                //else print ("AYA: Did not deploy Surface Sample as it had previously been deployed.");
                            }
                            //else print ("AYA: Did not deploy Surface Sample as R&D is the lowest tier.");
                        }
                        else if (thisExperiment.experimentID.Substring(0, 3) == "WBI") //If it's a WBI experiment, from M.O.L.E., don't do it becuase those are special.
                        {
                            // Do nothing
                        }
                        else if (!thisExperiment.Deployed)
                        {
                            thisExperiment.DeployExperiment(); //Deploy the experiment if it's not already deployed
                                                               //print ("AYA: Deployed experiment that had not been previously deployed.");
                        }
                        //else print ("AYA: Did not deploy experiment.");
                    }
                }
            }
        }
    }
}
