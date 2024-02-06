using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace BetterTotalScrap
{
    [HarmonyPatch(typeof(HUDManager), "FillEndGameStats")]
    public class HUDManagerPatch
    {
        [HarmonyPostfix]
        public static void FillEndGameStatsPostfix(HUDManager __instance, int scrapCollected)
        {
            int remainingScrapInLevel = CalculateRemainingScrapInLevel();
            float finalCount = (int)(scrapCollected + remainingScrapInLevel);

            finalCount += 80 * GameObject.FindObjectsOfType<LungProp>().Where(lung => lung.isLungDocked).Count();

            __instance.statsUIElements.quotaDenominator.text = finalCount.ToString();
        }
        private static int CalculateRemainingScrapInLevel()
        {
            GrabbableObject[] array = Object.FindObjectsOfType<GrabbableObject>();
            int remainingValue = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].itemProperties.isScrap && !array[i].isInShipRoom && !array[i].isInElevator && !array[i].scrapPersistedThroughRounds)
                {
                    remainingValue += array[i].scrapValue;
                }
            }
            return remainingValue;
        }
    }
}
