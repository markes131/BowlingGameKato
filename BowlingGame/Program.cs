// See https://aka.ms/new-console-template for more information
using BowlingGame;

Console.WriteLine("Hello, World!");

Game game = new Game();

int[] listOfThrowsWithNumberOfRolledPins = new int[] { 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

game.PlayWithListOfThrows(listOfThrowsWithNumberOfRolledPins);
