﻿using System.Collections.Generic;
using System.Linq;


public static class Constants
{
    //new object type to hold details of a scoreable item
    public class scoreableItem
    {
        public double points { get; set; }
        public string objectType { get; set; }
        public double probability { get; set; }
    }

    //global constant for associating scoreable items with their points and types
    public static Dictionary<string, scoreableItem> scoreableItems = new Dictionary<string, scoreableItem>() {
        { "capsuleSm", new scoreableItem { points=5, objectType="capsule", probability=0.03 } },
        { "capsuleLg", new scoreableItem { points=20, objectType="capsule", probability=0.015 } },
        { "fuelTankSm", new scoreableItem { points=1, objectType="fuelTank", probability=0.16 } },
        { "fuelTankMd", new scoreableItem { points=1.5, objectType="fuelTank", probability=0.11 } },
        { "fuelTankLg", new scoreableItem { points=2, objectType="fuelTank", probability=0.08} },
        { "engineSm", new scoreableItem { points=1, objectType="engine", probability=0.16} },
        { "engineMd", new scoreableItem { points=1.5, objectType="engine", probability=0.11 } },
        { "engineLg", new scoreableItem { points=2, objectType="engine", probability=0.08 } },
        { "batterySm", new scoreableItem { points=1, objectType="battery", probability=0.16 } },
        { "batteryLg", new scoreableItem { points=2, objectType="battery", probability=0.08 } },
        { "solarPanel", new scoreableItem { points=19, objectType="solarPanel", probability=0.015 } },
        { "fuel", new scoreableItem { points=1, objectType="fuel", probability=1 } },
    };

    //global constant for defining the maximum number of each object type
    public static Dictionary<string, int> objectLimits = new Dictionary<string, int>() {
        { "capsule", 1 },
        { "fuelTank", 3 },
        { "engine", 3 },
        { "battery", 1 },
        { "solarPanel", 1 },
        { "fuel", 25 },
    };

    //Player Movement Speed
    public const float moveSpeed = 5f;

    //Sorting Order
    public const int sortingOrderBase = 5000;

    //Audio Mixer 
    public const string masterAudioMixer = "volume";
    public const float muteVolume = 0f;

    //No Name Error Message
    public const string errMsg = "Error, please input a name.";

    //Scene Indexs
    public const int titleScreenIndex = 0;
    public const int homebaseSceneIndex = 1;
    public const int adventureSceneIndex = 2;
    public const int endScreenIndex = 3;

    //Number Adventures
    public const int maxAdventures = 20;

}
