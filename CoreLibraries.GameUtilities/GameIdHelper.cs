// This file is part of CoreLibraries.GameUtilities by heyitsleo.
// 
// Created: 10/30/2019 @ 3:31 PM.

using System.Collections.Generic;
using System.Data;

namespace CoreLibraries.GameUtilities
{
    public static class GameIdHelper
    {
        public const string ID_MW = "MOST_WANTED";
        public const string ID_MW_64 = "MOST_WANTED_64";
        public const string ID_CARBON = "CARBON";
        public const string ID_PROSTREET = "PROSTREET";
        public const string ID_UNDERCOVER = "UNDERCOVER";
        public const string ID_WORLD = "WORLD";

        private static readonly ISet<string> IdList = new HashSet<string>
        {
            ID_MW,
            ID_MW_64,
            ID_CARBON,
            ID_PROSTREET,
            ID_UNDERCOVER,
            ID_WORLD
        };

        private static readonly Dictionary<string, ISet<string>> FeatureDictionary = new Dictionary<string, ISet<string>>();

        public static void AddFeature(string gameId, string featureId)
        {
            if (!FeatureDictionary.ContainsKey(gameId))
                FeatureDictionary[gameId] = new HashSet<string>();
            FeatureDictionary[gameId].Add(featureId);
        }

        public static bool IsFeatureAvailable(string gameId, string featureId)
        {
            return FeatureDictionary.TryGetValue(gameId, out var fd) && fd.Contains(featureId);
        }

        public static void AddGame(string gameId)
        {
            if (!IdList.Add(gameId))
            {
                throw new DuplicateNameException($"{gameId} already added");
            }
        }

        public static bool IsValid(string gameId)
        {
            return IdList.Contains(gameId);
        }

        public static ISet<string> GetIdList()
        {
            return IdList;
        }
    }
}