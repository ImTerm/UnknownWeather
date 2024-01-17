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
    [HarmonyPatch(typeof(Terminal), nameof(Terminal.LoadNewNode))]
    public static class ChangeTerminal
    {
        public static void Prefix(Terminal __instance, TerminalNode node)
        {
            node.displayText = node.displayText.Replace("[planetTime]", "");
            node.displayText = node.displayText.Replace("It is \ncurrently [currentPlanetTime] on this moon.", "");
        }
    }

    [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.SetMapScreenInfoToCurrentLevel))]
    public static class ChangeScreen
    {
        public static void Postfix(StartOfRound __instance)
        {
            __instance.screenLevelDescription.text = __instance.screenLevelDescription.text.Split("\nWeather")[0];
        }
    }
}