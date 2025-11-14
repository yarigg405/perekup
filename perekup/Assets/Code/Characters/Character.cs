using System;


namespace Assets.Code.Characters
{
    [Serializable]
    public sealed class Character
    {
        public int[] Stats = new int[6];
        public string VisualName;
        public string Guid;
    }
}
