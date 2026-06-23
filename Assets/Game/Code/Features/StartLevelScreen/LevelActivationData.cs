using System;

namespace Features.StartLevelScreen
{
    internal class LevelActivationData
    {
        public bool IsFree => UnlockCost == 0;
        public bool IsAdPassAvailable { get; private set; }
        public int UnlockCost { get; private set; }

        public LevelActivationData(int unlockCost, bool isAdPassAvailable)
        {
            if (unlockCost < 0)
                throw new ArgumentException("Unlock cost cannot be negative");
            UnlockCost = unlockCost;
            IsAdPassAvailable = !IsFree && isAdPassAvailable;
        }
    }
}