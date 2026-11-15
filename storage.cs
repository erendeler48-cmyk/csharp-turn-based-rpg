using tbrpg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text.Json;

namespace Tbrpg
{
    public class Enemy
    {
        public string name { get; set; } = String.Empty;
        public int health { get; set; }
        public int atk { get; set; }
        public int criticalChance { get; set; }
        public int level { get; set; }
        public int experience { get; set; }
        public int id { get; set; }
    }

    public class Player
    {
        public int health { get; set; }
        public int maxhealth { get; set; }
        public int atk { get; set; }
        public int criticalChance { get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int maxxp { get; set; } = 100;
        public int def { get; set; }
        public int mp { get; set; }
        public int maxmp { get; set; }
    }

    public class Spell
    {
        public string name { get; set; } = String.Empty;
        public int damage { get; set; }
        public int cost { get; set; }
        public int level { get; set; }
        public int isunlocked { get; set; }
    }
}

internal class Storage
{
    public static bool rungame = true;
    public static List<Enemy> enemylist = new List<Enemy>();
    Dictionary<string, Spell> enemies = new Dictionary<string, Spell>();
    public static void SavePlayer(Player player)
    {

        string json = JsonSerializer.Serialize(player);
        File.WriteAllText("player.json", json);
    }

    public static Player LoadPlayer()
    {
        if (!File.Exists("player.json"))
        {
            return new Player { health = 100, maxhealth = 100, atk = 12, criticalChance = 5, level = 1, xp = 0, maxmp = 20};
        }
        string json = File.ReadAllText("player.json");


        var result = JsonSerializer.Deserialize<Player>(json);
        return result;
    }

    public static void SaveEnemy(Enemy enemy)
    {
        if (!enemylist.Contains(enemy))
        {
            enemylist.Add(enemy);
        }
        string json = JsonSerializer.Serialize(enemylist);
        File.WriteAllText("enemy.json", json);
    }
    public static void LoadEnemy()
    {
        if (!File.Exists("enemy.json"))
        {
            Console.WriteLine("There is no monster file");
        }
        if (File.Exists("enemy.json"))
        {
            string json = File.ReadAllText("enemy.json");
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
            };
            enemylist = JsonSerializer.Deserialize<List<Enemy>>(json, option);
            return;
        }
    }
    public static Dictionary<string, Spell> Spells1 = new Dictionary<string, Spell>()
    {
    { "Fireball", new Spell { name = "Fireball", damage = 25, cost = 15, level = 1, isunlocked = 1 } },
    { "Ice Bolt", new Spell { name = "Ice Bolt", damage = 18, cost = 10, level = 1, isunlocked = 1 } },
    { "Lightning Strike", new Spell { name = "Lightning Strike", damage = 45, cost = 30, level = 3, isunlocked = 0 } },
    { "Life Drain", new Spell { name = "Life Drain", damage = 20, cost = 20, level = 2, isunlocked = 0 } },
    { "Pyroclasm", new Spell { name = "Pyroclasm", damage = 80, cost = 55, level = 5, isunlocked = 0 } }
    };
    public static Dictionary<string, Spell> Unlockedspells = new Dictionary<string, Spell>();
    public static void Spells()
    {
        foreach (var spell in Spells1)
        {
            if (spell.Value.isunlocked == 1)
            {
                Unlockedspells.Add(spell.Key, spell.Value);
            }
            else
            {
            continue;
            }
        }
    }
}


