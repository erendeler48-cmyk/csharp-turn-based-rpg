using System;   
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tbrpg
{
    internal class Functions
    {
            private static  Random criticalhit = new Random();
            static  int criticalhitroll;
        public static void PlayerAttack(Player player, Enemy enemy)
        {
            criticalhitroll = criticalhit.Next(1, 101);
            if (criticalhitroll <= player.criticalChance)
            {
                int criticaldamage = player.atk * 2;
                enemy.health -= criticaldamage;
                Console.WriteLine($"Critical hit! You hit the {enemy.name} for {criticaldamage} damage!");
                return;
            }
            if (criticalhitroll > player.criticalChance)
            {
                int damage = player.atk;
                enemy.health -= damage;
                Console.WriteLine($"You hit the {enemy.name} for {damage} damage!");
                return;
            }
        }
        public static void EnemyAttack(Player player, Enemy enemy)
        {
            criticalhitroll = criticalhit.Next(1, 101);
            if (criticalhitroll <= enemy.criticalChance)
            {
                int criticaldamage = enemy.atk * 2;
                player.health -= criticaldamage;
                Console.WriteLine($"Critical hit! The {enemy.name} hit you for {criticaldamage} damage!");
                return;
            }
            if (criticalhitroll > enemy.criticalChance)
            {
                int damage = enemy.atk;
                player.health -= damage;
                Console.WriteLine($"The {enemy.name} hit you for {damage} damage!");
                return;
            }
        }
        public static void Rest(Player player)
        {
           
                player.health = player.maxhealth;
                player.mp = player.maxmp;
                Console.WriteLine($"You have rested and restored your health to {player.health}!");
                return;
            
        }
        public static void Defence(Player player, Enemy enemy)
        {
            criticalhitroll = criticalhit.Next(1, 101);
            if (criticalhitroll <= enemy.criticalChance)
            {
                int criticaldamage = enemy.atk * 2 - player.def;
                player.health -= criticaldamage;
                Console.WriteLine($"Critical hit! The {enemy.name} hit you for {criticaldamage} damage!");
                return;
            }
            if (criticalhitroll > enemy.criticalChance)
            {
                int damage = enemy.atk - player.def;
                player.health -= damage;
                Console.WriteLine($"The {enemy.name} hit you for {damage} damage!");
                return;
            }
        }
        public static void Spells(Player player, Enemy enemy)
        {
            List<string> spellNames = Storage.Unlockedspells.Keys.ToList();
            if (Storage.Unlockedspells != null && Storage.Unlockedspells.Count > 0)
            {
                Console.WriteLine("Your unlocked spells:");
                for (int i = 0; i < spellNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {spellNames[i]}");
                }
                int spellinput = Convert.ToInt32(Console.ReadLine() switch
                {
                    string y => y,
                    _ => throw new ArgumentException("Invalid input. Please enter a number.")
                });
                if (player.mp < Storage.Unlockedspells[spellNames[spellinput - 1]].cost)
                {
                    Console.WriteLine("You don't have enough mana to cast that spell!");
                    return;
                }
                if (player.mp >= Storage.Unlockedspells[spellNames[spellinput - 1]].cost)
                {
                    player.mp -= Storage.Unlockedspells[spellNames[spellinput - 1]].cost;
                    enemy.health -= Storage.Unlockedspells[spellNames[spellinput - 1]].damage;
                    Console.WriteLine($"You cast {spellNames[spellinput - 1]} and dealt {Storage.Unlockedspells[spellNames[spellinput - 1]].damage} damage to the {enemy.name}!");
                }

                return;
            }
            else { Console.WriteLine("You have no spells yet!"); };
        }
        public static void LevelUp(Player player)
            {
                player.level++;
                player.maxhealth += 10;
                player.atk += 2;
                player.criticalChance += 1;
                player.xp = 0;
                player.maxxp += 50;
            player.def += 1;
            player.maxmp += 5;
            Console.WriteLine($"You leveled up! You are now level {player.level}!");
            }
        }
    }
