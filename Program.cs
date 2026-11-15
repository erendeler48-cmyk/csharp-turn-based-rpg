using System.Data;
using System.Net.Security;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Tbrpg
    {
        internal class Program
        {
            static void Main(string[] args)
            {
            Storage.Spells();
            var player = Storage.LoadPlayer();
            Storage.LoadEnemy();
                List<Enemy> enemylist = Storage.enemylist;
                var Rungame = Storage.rungame;
            var ingame = true;
            var playerturn = true;
            while (Rungame == true)
                {
                    Console.WriteLine("Welcome to the game!");
                    Console.WriteLine("1. Start Game");
                    Console.WriteLine("2. Exit");
                    var input = Console.ReadLine();
                        if (input == "1")
                    {
                        while (ingame==true)
                        {
                            Console.WriteLine("Sherching area...");

                            Random Enemyrandom = new Random();
                        int x = Enemyrandom.Next(0, enemylist.Count);
                        var originalenemy = (enemylist[x]);
                        var enemy = new Enemy()
                        {
                            name = originalenemy.name,
                            health = originalenemy.health,
                            atk = originalenemy.atk,
                            criticalChance = originalenemy.criticalChance,
                            experience = originalenemy.experience,
                            level = originalenemy.level,
                            id = originalenemy.id,
                        };
                        
                        
                            Random enemylevel = new Random();
                            enemy.level = enemylevel.Next(1, 5);
                            enemy.health = enemy.health + 5 * enemy.level;
                            enemy.atk = enemy.atk + 2 * enemy.level;
                            enemy.criticalChance = enemy.criticalChance + 1 * enemy.level;
                            enemy.experience = enemy.experience + 10 * enemy.level;
                            

                        Console.WriteLine("You have encountered a " + enemy.level + "lvl " + enemy.name);
                            var combat = true;
                            Console.WriteLine("1. Attack");
                            Console.WriteLine("2. Run");
                            Console.WriteLine("3. Rest");
                            var combatinput = Console.ReadLine();
                        if (combatinput == "1")
                        {
                            while (combat == true)
                            {
                                if (player.health > 0 && enemy.health > 0)
                                {
                                    Console.WriteLine($"Your health: {player.health}");
                                    Console.WriteLine($"Your mana: {player.mp}");
                                    Console.WriteLine($"Enemy health: {enemy.health}");
                                    Console.WriteLine("1. Attack, 2. Defence, 3. Spells");
                                    string input2 = Console.ReadLine().ToLower() switch
                                    {
                                        "1" => "Attack",
                                        "attack" => "Attack",
                                        "2" => "Defence",
                                        "defence" => "Defence",
                                        "3" => "Spells",
                                        "spells" => "Spells",
                                        _ => "Invalid"

                                    };
                                    if (input2 == "Attack")
                                    {
                                        Functions.PlayerAttack(player, enemy);
                                        Functions.EnemyAttack(player, enemy);
                                        Console.ReadKey();
                                    }
                                    if (input2 == "Defence")
                                    {
                                        Functions.Defence(player, enemy);
                                        Console.ReadKey();
                                    }
                                    if (input2 == "Spells")
                                    {
                                        Functions.Spells(player, enemy);
                                        Functions.EnemyAttack(player, enemy);
                                        Console.ReadKey();
                                    }

                                }
                                if (player.health <= 0)
                                {
                                    Console.WriteLine("You have died!");
                                    return;
                                }
                                if (enemy.health <= 0)
                                {
                                    Console.WriteLine("You won!!");
                                    combat = false;
                                    player.xp += enemy.experience;
                                    Console.WriteLine($"Your currect xp is:{player.xp}");
                                    if (player.xp >= player.maxxp)
                                    {
                                        player.xp -= player.maxxp;
                                        Functions.LevelUp(player);
                                    }
                                }
                                Storage.SavePlayer(player);
                            }
                        }
                        if (combatinput == "2")
                        {
                            return;
                        }
                        if (combatinput == "3")
                        {
                            Functions.Rest(player);
                        }
                    }
                }
                }
            }
        }
    }
