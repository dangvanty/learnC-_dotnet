// See https://aka.ms/new-console-template for more information
using LearnUnitTest.TipsCSharp;

List<int> rankedScores = new List<int> { 100, 100, 50, 40, 40, 20, 10 };
List<int> playerScores = new List<int> { 5, 9, 25, 50, 120, 100 };

List<int> result = ExInHackerRank.ClimbingLeaderboard(rankedScores, playerScores);

Console.WriteLine("Result: " + string.Join(", ", result));
//---------------------------------------------------------
//---------------------------------------------------------

