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

    // ############# SOLAR PANELS ############### //

    public class AYA_Solar : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Extend All")]
        public void ExtendAllSolar()
        {
            foreach (Part eachPart in vessel.Parts)                                             //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleDeployableSolarPanel>();   //If it's a solar panel...
                if (thisPart != null) thisPart.Extend();                                        //Deploy it
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Retract All")]
        public void RetractAllSolar()
        {
            foreach (Part eachPart in vessel.Parts)                                             //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleDeployableSolarPanel>();   //If it's a solar panel...
                if (thisPart != null) thisPart.Retract();                                       //Retract it
            }
        }
    }

    // ############# RADIATORS ############### //

    public class AYA_Radiator : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Extend All")]
        public void ExtendAllRadiator()
        {
            foreach (Part eachPart in vessel.Parts)                                          //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleDeployableRadiator>();  //If it's a radiator...
                if (thisPart != null) thisPart.Extend();                                     //Deploy it
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Retract All")]
        public void RetractAllRadiator()
        {
            foreach (Part eachPart in vessel.Parts)                                          //Cycle through each part on the vessel
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleDeployableRadiator>();  //If it's a radiator...
                if (thisPart != null) thisPart.Retract();                                    //Retract it
            }
        }
    }

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
//						print ("AYA: Start Experiment Dump");
//						print ("AYA: thisExperiment.ClassName " + thisExperiment.ClassName);
//						print ("AYA: thisExperiment.collectActionName " + thisExperiment.collectActionName);
//						print ("AYA: thisExperiment.collectWarningText " + thisExperiment.collectWarningText);
//						print ("AYA: thisExperiment.collectWarningText " + thisExperiment.collectWarningText);
//						print ("AYA: thisExperiment.cooldownString " + thisExperiment.cooldownString);
//						print ("AYA: thisExperiment.dataIsCollectable " + thisExperiment.dataIsCollectable);
//						print ("AYA: thisExperiment.deployableSeated " + thisExperiment.deployableSeated);
//						print ("AYA: thisExperiment.Deployed " + thisExperiment.Deployed);
//						print ("AYA: thisExperiment.enabled " + thisExperiment.enabled);
//						print ("AYA: thisExperiment.experimentActionName " + thisExperiment.experimentActionName);
//						print ("AYA: thisExperiment.experimentID " + thisExperiment.experimentID);
//						print ("AYA: thisExperiment.GUIName " + thisExperiment.GUIName);
//						print ("AYA: thisExperiment.Inoperable " + thisExperiment.Inoperable);
//						print ("AYA: thisExperiment.isActiveAndEnabled " + thisExperiment.isActiveAndEnabled);
//						print ("AYA: thisExperiment.isEnabled " + thisExperiment.isEnabled);
//						print ("AYA: thisExperiment.moduleName " + thisExperiment.moduleName);
//						print ("AYA: thisExperiment.name " + thisExperiment.name);
//						print ("AYA: thisExperiment.rerunnable " + thisExperiment.rerunnable);
//						print ("AYA: thisExperiment.resetActionName " + thisExperiment.resetActionName);
//						print ("AYA: thisExperiment.resettable " + thisExperiment.resettable);
//						print ("AYA: thisExperiment.resettableOnEVA " + thisExperiment.resettableOnEVA);
//						print ("AYA: thisExperiment.reviewActionName " + thisExperiment.reviewActionName);
//						print ("AYA: thisExperiment.experiment.experimentTitle " + thisExperiment.experiment.experimentTitle);
//						print ("AYA: thisExperiment.experiment.requiredExperimentLevel " + thisExperiment.experiment.requiredExperimentLevel);
                        if (thisExperiment.experimentActionName == "Take Surface Sample") //If it's a surface sample, we need to make sure it's not locked out.
                        {
							if (ScenarioUpgradeableFacilities.GetFacilityLevel (SpaceCenterFacility.ResearchAndDevelopment) > 0) // Are you allowed to do surface samples? NOTE: 0 is tier 1. 0.5 is tier 2. 1 is tier 3. These could change if more tiers are added.
							{
								if (!thisExperiment.Deployed) {
									thisExperiment.DeployExperiment (); //Deploy the experiment if it's not already deployed
//									print ("AYA: Deployed Surface Sample that had not yet been deployed");
								}
//								else print ("AYA: Did not deploy Surface Sample as it had previously been deployed.");
							}
//							else print ("AYA: Did not deploy Surface Sample as R&D is the lowest tier.");
                        }
						else
                        {
							if (!thisExperiment.Deployed)
							{
								thisExperiment.DeployExperiment (); //Deploy the experiment if it's not already deployed
//								print ("AYA: Deployed experiment that had not been previously deployed.");
							}
//							else print ("AYA: Did not deploy experiment as it had previously been deployed.");
                        }
                    }
                }
            }
        }
    }

    // ############# REACTION WHEELS ############### //
    // This is not working right now. See comments for errors.
    /*
        public class AYA_SAS : PartModule
        {
            [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Activate All")]
            public void AcivateAll()
            {
                foreach (Part eachPart in vessel.Parts)
                {
                    var thisPart = eachPart.FindModuleImplementing<ModuleReactionWheel>();
                    if (thisPart != null) thisPart.Activate();
                    // Error CS7036  There is no argument given that corresponds to the required formal parameter 'param' of 'ModuleReactionWheel.Activate(KSPActionParam)'

                }
            }
            [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Deactivate All")]
            public void DeactivateAll()
            {
                foreach (Part eachPart in vessel.Parts)
                {
                    var thisPart = eachPart.FindModuleImplementing<ModuleReactionWheel>();
                    if (thisPart != null) thisPart.Deactivate();
                    // Error CS7036  There is no argument given that corresponds to the required formal parameter 'param' of 'ModuleReactionWheel.Deactivate(KSPActionParam)'

                }
            }
        }
    */

    // ############# FUEL CELLS ############### //
    //
    // I have no idea how to make these work, along with all other "resourceconverters."
    // I think I could make them all activate all other resourceconverters, but that would be bad.
    /*
    public class AYA_FuelCell : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Start All")]
        public void StartAllFuelCells()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleF>();
                if (thisPart != null) thisPart.Extend();
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Stop All")]
        public void StopAllFuelCells()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleDeployableRadiator>();
                if (thisPart != null) thisPart.Retract();
            }
        }
    }*/

    // ############# DRILLS ############### //
    //
    // This doesn't work. I don't know how to make it work.
    /*
    public class AYA_Drill : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Start All")]
        public void ExtendAllDrills()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleAsteroidDrill>();
                if (thisPart != null) thisPart.StartResourceConverter();
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Stop All")]
        public void RetractAllDrills()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleAsteroidDrill>();
                if (thisPart != null) thisPart.StopResourceConverter();
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Extend All")]
        public void StartAllDrills()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleResourceHarvester>();
                if (thisPart != null) thisPart.Start();
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Retract All")]
        public void StopAllDrills()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleResourceHarvester>();
                if (thisPart != null) thisPart.??????????();
            }
        }
    }
    */

    // ############# CARGO BAYS ############### //
    //
    // I can't do this either. Same reason as always: I don't know how.
    /*
    public class AYA_CargoBay : PartModule
    {
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Open All")]
        public void OpenAllBays()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleCargoBay>();
                if (thisPart != null) thisPart.();
            }
        }
        [KSPEvent(guiActive = true, guiActiveEditor = false, guiName = "Close All")]
        public void CloseAllBays()
        {
            foreach (Part eachPart in vessel.Parts)
            {
                var thisPart = eachPart.FindModuleImplementing<ModuleCargoBay>();
                if (thisPart != null) thisPart.Retract();
            }
        }
    }
    */
}
