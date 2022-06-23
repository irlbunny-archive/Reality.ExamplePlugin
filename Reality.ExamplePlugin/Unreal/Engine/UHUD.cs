using Reality.ExamplePlugin.Unreal.CoreUObject;
using Reality.ModLoader.Unreal.Core;
using Reality.ModLoader.Unreal.CoreUObject;

namespace Reality.ExamplePlugin.Unreal.Engine
{
    internal class UHUD : UObject
    {
        private static UObject _drawTextFunction;

        public void DrawText(string text, FLinearColor textColor,
                float screenX, float screenY,
                UObject font, float scale,
                bool bScalePosition)
        {
            if (_drawTextFunction == null)
                _drawTextFunction = FindObject("Function /Script/Engine.HUD.DrawText");

            var parms = FMemory.MallocZero(0x35);

            var textInternal = new FString(text);
            textInternal.WriteStruct(parms, false);
            textColor.WriteStruct(parms + 0x10, false);

            Memory.WriteSingle(parms, 0x20, screenX);
            Memory.WriteSingle(parms, 0x24, screenY);

            Memory.WriteIntPtr(parms, 0x28, font.BaseAddress);

            Memory.WriteSingle(parms, 0x30, scale);

            Memory.WriteUInt8(parms, 0x34, (byte) (bScalePosition ? 1 : 0));

            ProcessEvent(_drawTextFunction.BaseAddress, parms);
        }
    }
}
