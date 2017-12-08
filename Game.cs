using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{

    public static Game current;
    public Character knight;
    public Character zombie;
    public Character orc;
    public int health;

    public int points;
    public Game()
    {
        knight = new Character();
        zombie = new Character();
        orc = new Character();
        health = PointSystem.health;

        points = PointSystem.points;
    }

}
