﻿// ALL Y'ALL
// By 5thHorseman with much help from many others
// License: CC SA

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
