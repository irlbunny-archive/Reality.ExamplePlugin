using Reality.ModLoader.Memory;

namespace Reality.ExamplePlugin.Unreal.CoreUObject
{
    internal class FLinearColor : MemoryStruct
    {
        public float R
        {
            get => ReadSingle(0);
            set => WriteSingle(0, value);
        }

        public float G
        {
            get => ReadSingle(4);
            set => WriteSingle(4, value);
        }

        public float B
        {
            get => ReadSingle(8);
            set => WriteSingle(8, value);
        }

        public float A
        {
            get => ReadSingle(0xC);
            set => WriteSingle(0xC, value);
        }

        public FLinearColor()
            : base()
        { }

        public FLinearColor(float r, float g, float b, float a)
            : base()
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override int ObjectSize => 0x10;
    }
}
