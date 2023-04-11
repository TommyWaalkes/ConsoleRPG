using RPGConsoleGame;

CharacterFactory cf = new CharacterFactory();
Player Player = cf.CreateByHand(1);
//while (true)
//{
    Player enemy = cf.GenerateRandom(Player.Stats.Level);
    Battle b = new Battle(Player, enemy);
    b.Round();
//}
