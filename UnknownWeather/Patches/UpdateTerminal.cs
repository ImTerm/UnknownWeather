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
            string originalText = __instance.screenLevelDescription.text;
            string text = originalText;

            var position1 = text.IndexOf("\nWeather:");
            if (position1 < 0) return;

            var position2 = text.IndexOf("\n", position1 + 1);
            if (position2 < 0) position2 = text.Length;

            text = text.Remove(position1, position2 - position1);

            if (__instance.screenLevelDescription.text.Equals(originalText))
                __instance.screenLevelDescription.text = text;
        }
    }
}