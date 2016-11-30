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

    // ############# SCIENCE BOX ############### //
    public class AYA_ScienceBox : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Reset All Science")]
        public void DoResetScience()
        {
            bool haveScientist = false;
            foreach (ProtoCrewMember crewMember in vessel.GetVesselCrew())
            {
                if (crewMember.trait == "Scientist")
                {
                    haveScientist = true;
                }
            }
            foreach (Part eachPart in vessel.Parts)                                 //Cycle through each part on the vessel
            {
                foreach (ModuleScienceExperiment thisExperiment in eachPart.FindModulesImplementing<ModuleScienceExperiment>())
                //Cycle through each ModuleScienceExperiment module in the part
                {
                    if (thisExperiment != null)                                     //Only continue it if it's actually a ModuleScienceExperiment (which it should always be but hey)
                    {
                        /*
                        print("AYA: Start Experiment Dump");
                        print("AYA: thisExperiment.ClassName " + thisExperiment.ClassName);
                        print("AYA: thisExperiment.collectActionName " + thisExperiment.collectActionName);
                        print("AYA: thisExperiment.collectWarningText " + thisExperiment.collectWarningText);
                        print("AYA: thisExperiment.collectWarningText " + thisExperiment.collectWarningText);
                        print("AYA: thisExperiment.containersDirty" + thisExperiment.containersDirty);
                        print("AYA: thisExperiment.cooldownString " + thisExperiment.cooldownString);
                        print("AYA: thisExperiment.cooldownTimer" + thisExperiment.cooldownTimer);
                        print("AYA: thisExperiment.cooldownToGo" + thisExperiment.cooldownToGo);
                        print("AYA: thisExperiment.experiment" + thisExperiment.experiment);
                        print("AYA: thisExperiment.dataIsCollectable " + thisExperiment.dataIsCollectable);
                        print("AYA: thisExperiment.deployableSeated " + thisExperiment.deployableSeated);
                        print("AYA: thisExperiment.Deployed " + thisExperiment.Deployed);
                        print("AYA: thisExperiment.enabled " + thisExperiment.enabled);
                        print("AYA: thisExperiment.experimentActionName " + thisExperiment.experimentActionName);
                        print("AYA: thisExperiment.experimentID " + thisExperiment.experimentID);
                        print("AYA: thisExperiment.fxModuleIndices" + thisExperiment.fxModuleIndices);
                        print("AYA: thisExperiment.hasContainer" + thisExperiment.hasContainer);
                        print("AYA: thisExperiment.interactionRange" + thisExperiment.interactionRange);
                        print("AYA: thisExperiment.moduleIsEnabled" + thisExperiment.moduleIsEnabled);
                        print("AYA: thisExperiment.overrideStagingIconIfBlank" + thisExperiment.overrideStagingIconIfBlank);
                        print("AYA: thisExperiment.part" + thisExperiment.part);
                        print("AYA: thisExperiment.resHandler" + thisExperiment.resHandler);
                        print("AYA: thisExperiment.resourceResetCost" + thisExperiment.resourceResetCost);
                        print("AYA: thisExperiment.resourceToReset" + thisExperiment.resourceToReset);
                        print("AYA: thisExperiment.showUpgradesInModuleInfo" + thisExperiment.showUpgradesInModuleInfo);
                        print("AYA: thisExperiment.snapshot" + thisExperiment.snapshot);
                        print("AYA: thisExperiment.stagingDisableText" + thisExperiment.stagingDisableText);
                        print("AYA: thisExperiment.stagingEnabled" + thisExperiment.stagingEnabled);
                        print("AYA: thisExperiment.stagingEnableText" + thisExperiment.stagingEnableText);
                        print("AYA: thisExperiment.stagingToggleEnabledEditor" + thisExperiment.stagingToggleEnabledEditor);
                        print("AYA: thisExperiment.stagingToggleEnabledFlight" + thisExperiment.stagingToggleEnabledFlight);
                        print("AYA: thisExperiment.tag" + thisExperiment.tag);
                        print("AYA: thisExperiment.transform" + thisExperiment.transform);
                        print("AYA: thisExperiment.transmitWarningText" + thisExperiment.transmitWarningText);
                        print("AYA: thisExperiment.upgrades" + thisExperiment.upgrades);
                        print("AYA: thisExperiment.upgradesApplied" + thisExperiment.upgradesApplied);
                        print("AYA: thisExperiment.upgradesApply" + thisExperiment.upgradesApply);
                        print("AYA: thisExperiment.upgradesAsk" + thisExperiment.upgradesAsk);
                        print("AYA: thisExperiment.usageReqMaskExternal" + thisExperiment.usageReqMaskExternal);
                        print("AYA: thisExperiment.usageReqMaskInternal" + thisExperiment.usageReqMaskInternal);
                        print("AYA: thisExperiment.useActionGroups" + thisExperiment.useActionGroups);
                        print("AYA: thisExperiment.useCooldown" + thisExperiment.useCooldown);
                        print("AYA: thisExperiment.useGUILayout" + thisExperiment.useGUILayout);
                        print("AYA: thisExperiment.useStaging" + thisExperiment.useStaging);
                        print("AYA: thisExperiment.vessel" + thisExperiment.vessel);
                        print("AYA: thisExperiment.xmitDataScalar" + thisExperiment.xmitDataScalar);
                        print("AYA: thisExperiment.GUIName " + thisExperiment.GUIName);
                        print("AYA: thisExperiment.Inoperable " + thisExperiment.Inoperable);
                        print("AYA: thisExperiment.isActiveAndEnabled " + thisExperiment.isActiveAndEnabled);
                        print("AYA: thisExperiment.isEnabled " + thisExperiment.isEnabled);
                        print("AYA: thisExperiment.moduleName " + thisExperiment.moduleName);
                        print("AYA: thisExperiment.name " + thisExperiment.name);
                        print("AYA: thisExperiment.rerunnable " + thisExperiment.rerunnable);
                        print("AYA: thisExperiment.resetActionName " + thisExperiment.resetActionName);
                        print("AYA: thisExperiment.resettable " + thisExperiment.resettable);
                        print("AYA: thisExperiment.resettableOnEVA " + thisExperiment.resettableOnEVA);
                        print("AYA: thisExperiment.reviewActionName " + thisExperiment.reviewActionName);
                        print("AYA: thisExperiment.experiment.experimentTitle " + thisExperiment.experiment.experimentTitle);
                        print("AYA: thisExperiment.experiment.requiredExperimentLevel " + thisExperiment.experiment.requiredExperimentLevel);
                        print("AYA: thisExperiment.experimentID.Substring(0,3) = " + thisExperiment.experimentID.Substring(0, 3));
                        */
                        if (thisExperiment.experimentID.Substring(0, 3) == "WBI") //If it's a WBI experiment, from M.O.L.E., don't do it becuase those are special.
                        {
                            // Do nothing
                        }
                        else if (thisExperiment.Deployed)
                        {
                            if (thisExperiment.Inoperable)
                            //                            if (thisExperiment.experimentActionName == "Observe Mystery Goo" || thisExperiment.experimentActionName == "Observe Materials Bay")
                            {
                                if (haveScientist)
                                {
                                    thisExperiment.ResetExperimentExternal();
                                }
                            }
                            else
                            {
                                thisExperiment.ResetExperimentExternal();
                            }
                        }
                        //else print ("AYA: Did not deploy experiment.");
                    }
                }
            }
        }
    }
}
