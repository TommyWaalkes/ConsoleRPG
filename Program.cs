using RPGConsoleGame;

CharacterFactory cf = new CharacterFactory();
Player player = cf.DecidePlayerCreation(1);
player.Stats.Xp += 10000;
player.Stats.LevelUp(player.Growths);
//Player Player = cf.CreateByHand(1);
//while (true)
//{
//    Player enemy = cf.GenerateRandom(player.Stats.Level);
//    Battle b = new Battle(player, enemy);
//   BattleState result =  b.Round();
//Console.WriteLine(result);
//}
