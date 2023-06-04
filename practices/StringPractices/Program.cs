// See https://aka.ms/new-console-template for more information

//---------
//1 : Sort String ::: 
#region Sort String
// // input "bda" --> ouput: "abd"
// string a = "bad";
// //cach 1 :
// string b = new string(a.OrderBy(c=>c).ToArray());
// //cach 2 :
// string c = string.Join("",a.OrderBy(c=>c).ToArray());
// // cách 3: 
// string d = String.Concat(a.OrderBy(c=>c));

// Console.WriteLine($"String gốc : {a}");
// Console.WriteLine($"Chuyen cach 1: {b}");
// Console.WriteLine($"Chuyen cach 2: {c}");
// Console.WriteLine($"Chuyen cach 3: {d}");
#endregion

//2: Substring
#region SubString 
// string s1 = "This is a test string";
// int begin = 5;
// int end = 5;
// string s2 = s1.Substring(begin,end);
// Console.WriteLine($"s1 = {s1} \n s2 = {s2}");

#endregion
//3: ReverseAndUpperString
#region ReverseAndUpperString
// input:: abc --> output: CBA
    // string s1 = "abc";
    // string s2 = new string(s1.Reverse().ToArray()).ToUpper();
    // Console.WriteLine(s1 + "  ::::  "  +s2 );
#endregion

#region testHackerrank
// static int superDigit(string n, int k)
//     {
//         int len = n.Length;
//         if(len==1)
//         {
//             return int.Parse(n);
//         }else{
//             var sum = n.Select(c=>Convert.ToInt32(c.ToString())).Sum()*k;
//             Console.WriteLine(sum);
//             return superDigit(sum.ToString(),1);
//         }
//         // return 1;
//     }
   
//    Console.WriteLine($"kq::: {superDigit("9875",4)}");
#endregion 


#region check String If length > 3 then Reverse

    /*
    Original strings: The quick brown fox jumps over the lazy dog

    Reverse the words of three or more lengths of the said string:
    ehT kciuq nworb xof spmuj revo eht yzal god
    */
    // string str = "The quick brown fox jumps over the lazy dog";
    // var strArr = str.Split(" ").Select(s=>s.Length>=3 ? new string (s.Reverse().ToArray()):new string(s.ToArray()));
    // string outt = String.Join(" ",strArr);
    // var test = String.Compare("bbc","bc");
    // Console.WriteLine(outt);
    // Console.WriteLine("Ts::::: "+test);
   


#endregion

#region tuble

// (string , string ) ok = ("80","ok");
// var nice = ok;
// (string c, string d) = nice;
// int[] bn = new int[]{1,2,3};

// Console.WriteLine("a là :::: "+ bn.ToString());

#endregion

