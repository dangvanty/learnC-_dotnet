// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Linq;
#region Transform with select



// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
// string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// var PrintTransform = from p in numbers
//                     select strings[p];
// foreach (var item in PrintTransform)
// {
//     Console.WriteLine(item);
// }
#endregion

#region Select with index of item
// int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// var numsInPlace = numbers2.Select((num, index) => (Num: num, InPlace: (num == index)));

// Console.WriteLine("Number: In-place?");
// foreach (var n in numsInPlace)
// {
//     Console.WriteLine($"{n.Num}: {n.InPlace}");
// }
#endregion

#region reverse

string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// var reversedIDigits = (
//     from digit in digits
//     where digit[1] == 'i'
//     select digit)
//     .Reverse();

// Console.WriteLine("A backwards list of the digits with a second character of 'i':");
// foreach (var d in reversedIDigits)
// {
//     Console.WriteLine(d);
// }

#endregion

#region divided2
/*
Expected Output:
The numbers which produce the remainder 0 after divided by 2 are :
0 2 4 6 8
*/
int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var divided2 = numbers4.Where(x=>x%2==0);
foreach (var d in divided2)
{
    Console.WriteLine(d);
}

#endregion

#region using into

string [] strings2 = {"word","hallo","woft","banana","blow"};
var strGroup = from w in strings2
                group w by w[0] into FirtLetterGroup
                select new{
                    FirstLetter = FirtLetterGroup.Key,
                    Count = FirtLetterGroup.Count()
                } ;
strGroup.ToList().ForEach(w=>Console.WriteLine($"firstletter : {w.FirstLetter} ; count : {w.Count}"));
#endregion
Console.ReadLine();
