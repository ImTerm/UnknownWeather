using HarmonyLib;
using Unity.Netcode;
using BepInEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GameNetcodeStuff;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using Object = UnityEngine.Object;

namespace UnknownWeather.Patches
{
    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(typeof(Terminal), nameof(Terminal.LoadNewNode))]
    public static class ChangeTerminal
    {
        public static void Prefix(Terminal __instance, TerminalNode node)
        {
            node.displayText = node.displayText.Replace("[planetTime]", "");
            node.displayText = node.displayText.Replace("It is \ncurrently [currentPlanetTime] on this moon.", "");
        }
    }

    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.SetMapScreenInfoToCurrentLevel))]
    public static class ChangeScreen
    {
        public static void Postfix(StartOfRound __instance)
        {
            var position1 = __instance.screenLevelDescription.text.IndexOf("\nWeather:");
            System.Console.WriteLine("\n\n1");
            if (position1 > -1)
            {
                var position2 = __instance.screenLevelDescription.text.IndexOf("\n", position1);
                System.Console.WriteLine("\n\n2");
                if (position2 > -1)
                {
                    string[] result = __instance.screenLevelDescription.text.Split(__instance.screenLevelDescription.text.Substring(position1, position2));
                    System.Console.WriteLine("\n\n3");
                    __instance.screenLevelDescription.text = result[0] + result[1];
                    System.Console.WriteLine("\n\n4");
                }
            }
        }
    }
}