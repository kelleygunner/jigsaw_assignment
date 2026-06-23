using System;
using Infrastructure.DataTransferring;
using Random = UnityEngine.Random;

namespace Gameplay.Domain
{
    public class GameLevelStartupData : IDto
    {
        public string Id => _id;

        // Will be set in level config for small, medium and large levels
        public int LevelOfDetailsCap { get; private set; }

        // Will be set in level config for small, medium and large levels
        public int DefaultDetailsLevel { get; private set; }
        public int UnlockCost { get; set; }
        public bool IsAdsAvailable { get; private set; }
        public string Name { get; private set; }

        private readonly string _id;
        private int _detailsTier;

        public bool IsReadyToPlay = false;
        
        // for demo
        string[] levelNames =
        {
            "Emerald Bounty",
            "Winter Fairytale",
            "Golden Horizon",
            "Mystic Garden",
            "Crystal Lagoon",
            "Autumn Serenity",
            "Sunset Escape",
            "Moonlit Harbor",
            "Hidden Paradise",
            "Frozen Kingdom",
            "Enchanted Forest",
            "Sapphire Dreams",
            "Coastal Adventure",
            "Whispering Meadows",
            "Ancient Wonders",
            "Tropical Bliss",
            "Velvet Twilight",
            "Starlight Journey",
            "Blooming Valley",
            "Celestial Vista"
        };

        public GameLevelStartupData(string id)
        {
            _id = id;
            IsReadyToPlay = false;

            // Randomize for testing purpose
            LevelOfDetailsCap = Random.Range(3, 6);
            DefaultDetailsLevel = Random.Range(0, LevelOfDetailsCap);
            UnlockCost = Random.Range(0, 3) > 0 ? Random.Range(1, 5) * 100 : 0;
            IsAdsAvailable = UnlockCost > 0 && Random.Range(0, 2) == 0;
            Name = levelNames[Random.Range(0, levelNames.Length)];
        }

        public void SetLevelOfDetails(int tier)
        {
            if (IsReadyToPlay)
                throw new Exception("Trying to Change Level Data which has already been marked as Ready to Play");
            _detailsTier = tier;
        }

        public void Build()
        {
            IsReadyToPlay = true;
        }
    }
}