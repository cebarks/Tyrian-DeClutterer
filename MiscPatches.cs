using SPT.Reflection.Patching;
using EFT;
using EFT.Interactive;
using HarmonyLib;
using System.Reflection;

namespace Framesaver
{
    public class PhysicsUpdatePatch : ModulePatch
    {
        public static bool everyOtherFixedUpdate = false;
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(EFTPhysicsClass), "Update");
        }

        [PatchPrefix]
        public static bool PatchPrefix()
        {
            everyOtherFixedUpdate = !everyOtherFixedUpdate;
            if (everyOtherFixedUpdate)
            {
                EFTPhysicsClass.SyncTransformsClass.Update();
                EFTPhysicsClass.GClass745.Update();
            }
            return false;
        }
    }
    public class PhysicsFixedUpdatePatch : ModulePatch
    {
        public static bool everyOtherFixedUpdate = false;
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(EFTPhysicsClass), "FixedUpdate");
        }

        [PatchPrefix]
        public static bool PatchPrefix()
        {
            everyOtherFixedUpdate = !everyOtherFixedUpdate;
            if (everyOtherFixedUpdate)
            {
                EFTPhysicsClass.SyncTransformsClass.FixedUpdate();
            }
            return false;
        }
    }
    public class RagdollPhysicsLateUpdatePatch : ModulePatch
    {
        public static bool everyOtherFixedUpdate = false;
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(CorpseRagdollTestApplication), "LateUpdate");
        }

        [PatchPrefix]
        public static bool PatchPrefix()
        {
            everyOtherFixedUpdate = !everyOtherFixedUpdate;
            if (everyOtherFixedUpdate)
            {
                EFTPhysicsClass.SyncTransforms();
            }
            return false;
        }
    }
    public class FlameDamageTriggerPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(FlameDamageTrigger), "ProceedDamage");
        }

        [PatchPrefix]
        public static bool PatchPrefix()
        {
            return false;
        }
    }
}