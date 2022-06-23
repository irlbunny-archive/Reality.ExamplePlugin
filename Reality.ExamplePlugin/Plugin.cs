using Reality.ExamplePlugin.Unreal.CoreUObject;
using Reality.ExamplePlugin.Unreal.Engine;
using Reality.ModLoader.Plugins;
using Reality.ModLoader.Unreal.CoreUObject;
using Reality.ModLoader.Utilities;
using System;

namespace Reality.ExamplePlugin
{
    public class Plugin : UnrealPlugin
    {
        public override string Name => "Example Plugin";
        public override string Author => "Kaitlyn";
        public override string Version => "1.0.0";

        private UObject _defaultFont;

        public override void OnGameInitialized()
        {
            // Uncomment this if you want to dump all objects into logs as soon as the game is initialized.
            /*for (var i = 0; i < Objects.Count; i++)
            {
                var obj = Objects[i];
                if (obj != null)
                    Logger.Info($"{obj.GetFullName()}{(obj.IsA<UProperty>() ? $", Offset: 0x{obj.Cast<UProperty>().Offset:X8}" : string.Empty)}");
            }*/
        }

        public override bool OnProcessEvent(UObject obj, UObject func, IntPtr parms)
        {
            //Logger.Info($"Object = {obj.GetFullName()}, Function = {func.GetFullName()}"); // Uncomment this if you want to log events.

            if (func.GetName() == "ReceiveDrawHUD" && obj.IsA<UHUD>())
            {
                if (_defaultFont == null)
                {
                    for (var i = 0; i < Objects.Count; i++)
                    {
                        var objObj = Objects[i];
                        if (objObj != null && objObj.IsA("Font") && objObj.GetName().Contains("Burbank"))
                        {
                            _defaultFont = objObj;
                            break;
                        }
                    }

                    Logger.Info("Found default font!");
                }

                obj.Cast<UHUD>().DrawText("Hello world, from Reality!", new FLinearColor(1f, 1f, 1f, 1f), 50f, 50f, _defaultFont, 1f, false);
            }

            return true; // Return "true" if base-game ProcessEvent should be called after running our own code, etc.
        }
    }
}
