﻿/*MIT License

Copyright (c) 2017 Michael Ferrara

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
using System;
using System.Collections.Generic;
using UnityEngine;
using ProcEngines.EngineConfig;

namespace ProcEngines
{
    class ProceduralEngineModule : PartModule
    {

        EngineConfigBase procEngineConfig;
        string mixture = "Kerosene_Lox";

        [KSPField(guiName = "Cham. Pres. MPa", isPersistant = true, guiActiveEditor = false, guiActive = false), UI_FloatRange(affectSymCounterparts = UI_Scene.All, maxValue = 50.0f, minValue = 0.25f, scene = UI_Scene.All, stepIncrement = 0.25f)]
        double chamberPresMPa = 5;
        double lastChamPres = 5;

        [KSPField(guiName = "Area Ratio", isPersistant = true, guiActiveEditor = false, guiActive = false), UI_FloatRange(affectSymCounterparts = UI_Scene.All, maxValue = 250.0f, minValue = 1.3f, scene = UI_Scene.All, stepIncrement = 0.1f)]
        double areaRatio = 7;
        double lastAreaRatio = 7;

        [KSPField(guiName = "Nozzle Diam.", isPersistant = true, guiActiveEditor = false, guiActive = false), UI_FloatRange(affectSymCounterparts = UI_Scene.All, maxValue = 20f, minValue = 0.1f, scene = UI_Scene.All, stepIncrement = 0.1f)]
        double nozzleDiameter = 1;
        double lastNozzleDiameter = 1;

        void Awake()
        {
            procEngineConfig = new EngineConfigGasGen(mixture);
        }

        void FixedUpdate()
        {

        }

        bool CheckChanges()
        {
            bool changes = false;
            if (chamberPresMPa != lastChamPres)
            {
                procEngineConfig.SetChamberPressure(chamberPresMPa);
                lastChamPres = chamberPresMPa;
                changes = true;
            }
            if (areaRatio != lastAreaRatio)
            {
                procEngineConfig.SetExpansionRatio(areaRatio);
                lastAreaRatio = areaRatio;
                changes = true;
            }
            if (nozzleDiameter != lastNozzleDiameter)
            {
                procEngineConfig.SetNozzleDiameter(nozzleDiameter);
                lastNozzleDiameter = nozzleDiameter;
                changes = true;
            }

            return changes;
        }
    }
}