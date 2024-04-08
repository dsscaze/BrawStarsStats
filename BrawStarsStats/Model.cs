using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawStarsStats
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Icon
    {
        [JsonProperty("id")]
        public int Id;
    }

    public class Club
    {
        [JsonProperty("tag")]
        public string Tag;

        [JsonProperty("name")]
        public string Name;
    }

    public class StarPower
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;
    }

    public class Gadget
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;
    }

    public class Brawler
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("power")]
        public int Power;

        [JsonProperty("rank")]
        public int Rank;

        [JsonProperty("trophies")]
        public int Trophies;

        [JsonProperty("highestTrophies")]
        public int HighestTrophies;

        [JsonProperty("starPowers")]
        public List<StarPower> StarPowers;

        [JsonProperty("gadgets")]
        public List<Gadget> Gadgets;
    }

    public class PlayerRequest
    {
        [JsonProperty("tag")]
        public string Tag;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("nameColor")]
        public string NameColor;

        [JsonProperty("icon")]
        public Icon Icon;

        [JsonProperty("trophies")]
        public int Trophies;

        [JsonProperty("highestTrophies")]
        public int HighestTrophies;

        [JsonProperty("expLevel")]
        public int ExpLevel;

        [JsonProperty("expPoints")]
        public int ExpPoints;

        [JsonProperty("isQualifiedFromChampionshipChallenge")]
        public bool IsQualifiedFromChampionshipChallenge;

        [JsonProperty("3vs3Victories")]
        public int _3vs3Victories;

        [JsonProperty("soloVictories")]
        public int SoloVictories;

        [JsonProperty("duoVictories")]
        public int DuoVictories;

        [JsonProperty("bestRoboRumbleTime")]
        public int BestRoboRumbleTime;

        [JsonProperty("bestTimeAsBigBrawler")]
        public int BestTimeAsBigBrawler;

        [JsonProperty("club")]
        public Club Club;

        [JsonProperty("brawlers")]
        public List<Brawler> Brawlers;
    }


}
