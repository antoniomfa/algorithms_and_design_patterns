using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    private static void Main(string[] args)
    {
        #region VARS
        List<int> list = new List<int> { 1, 2, 3, 4 };
        int[] arr1 = new[] { 1, 2, 3 };
        int[] arr2 = new[] { 4, 5, 6 };
        int[] arr3 = new[] { 9, 8, 9 };
        int[][] jagged = new[] { arr1, arr2, arr3 };
        int[] clouds = new[] { 0, 1, 0, 0, 1, 0 };
        string brackets = "{((()))}";
        string valley = "DDUUUUDD";
        List<int> socks = new List<int>() { 1, 2, 1, 2, 1, 3, 2 };
        string alternating = "BBBBB";
        #endregion VARS

        #region METHOD CALLS
        int sumAll = SumAll(list);
        int calcDiffDiag = CalcDiffDiagonal(jagged);
        int minJumps = JumpingClouds(clouds);
        string bracketsMatch = BalancedBrackets(brackets);
        int valleysCount = CountingValleys(8, valley);
        int numPairSocks = NumberOfSocks(socks);
        int playersCompared = ComparePlayers(new Player() { Name = "Antonio", Score = 50 }, new Player() { Name = "Susana", Score = 100 });
        int alternatingChars = AlternatingCharacters(alternating);
        int makeAnagram = MakeAnagram("cde", "dcf");
        int maxToys = MaximumToys(new int[] { 1, 4, 3, 2 }, 7);
        int[] rotatedLeft = RotateLeft(new int[] { 1, 2, 3, 4, 5 }, 2);
        string commonSubstring = TwoStrings("bababaiii", "okokok");
        bool almostEqual = AreAlmostEqual("bank", "kanb");
        int minPartitions = MinPartitions("27346209830709182346");
        #endregion METHOD CALLS

        Console.WriteLine(minPartitions);

        //Console.WriteLine(string.Join(",", rotatedLeft));
    }

    #region PROBLEMS
    // A pair (i, j) is called good if nums[i] == nums[j] and i < j.
    public int NumGoodPairs(int[] nums)
    {
        int num = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    num += 1;
            }
        }

        return num;
    }

    // A decimal number is called deci-binary if each of its digits is either 0 or 1 without any leading zeros.For example, 101 and 1100
    // are deci-binary, while 112 and 3001 are not.
    // Given a string n that represents a positive decimal integer, return the minimum number of positive deci-binary numbers needed so that
    // they sum up to n.
    public static int MinPartitions(string n)
    {
        var max = n.Max() - '0';

        return max;
    }

    // A string swap is an operation where you choose two indices in a string (not necessarily different) and swap the characters at these indices.
    // Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings
    public static bool AreAlmostEqual(string s1, string s2)
    {
        int count = 0;
        List<int> list = new();

        if (s1 == s2)
            return true;

        if (s1.Length != s2.Length) 
            return false;

        for (int i = 0; i < s1.Length; i++)
        {
            // Find idx where values differ
            if (s1[i] != s2[i])
            {
                list.Add(i);
                count++;
            }
        }

        if (count != 2)
            return false;

        if (s1[list[0]] == s2[list[1]] && s1[list[1]] == s2[list[0]])
            return true;

        return false;
    }

    // Revert node list
    public static LinkedNode Reverse(LinkedNode head)
    {
        if (head == null)
            return head;

        // Before first
        LinkedNode prevNode = null;
        LinkedNode currentNode = head;

        while (currentNode != null)
        {
            LinkedNode nextNode = currentNode.Next;
            currentNode.Next = prevNode;
            prevNode = currentNode;
            currentNode = nextNode;
        }

        return prevNode;
    }

    // Check if two strings share a substring
    public static string TwoStrings(string s1, string s2)
    {
        List<char> s1_chars = new();
        List<char> s2_chars = new();

        for (int i = 0; i < s1.Length; i++)
        {
            s1_chars.Add(s1[i]);
        }

        for (int i = 0; i < s2.Length; i++)
        {
            s2_chars.Add(s2[i]);
        }

        s1_chars.RemoveAll(item => s2_chars.Contains(item));

        if (s1_chars.Count != s1.Length)
            return "YES";

        return "NO";
    }

    // Max sum of hourglass array
    public static int HourglassSum(int[][] array)
    {
        int maxSum = int.MinValue;
        int rows = array.Length;
        int columns = array[0].Length;

        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < columns - 2; j++)
            {
                int currentSum = array[i][j] + array[i][j + 1] + array[i][j + 2] +
                    array[i + 1][j + 1] +
                    array[i + 2][j] + array[i + 2][j + 1] + array[i + 2][j + 2];

                maxSum = Math.Max(maxSum, currentSum);
            }
        }

        return maxSum;
    }

    // Rotate an array to the left
    public static int[] RotateLeft(int[] a, int d)
    {
        int arrSize = a.Length;
        int[] finalArr = new int[arrSize];
        int times = d;
        int i = 0;

        if (d == arrSize)
            return a;

        while (times < arrSize)
        {
            finalArr[i] = a[times];

            i++;
            times++;
        }

        times = 0;

        while (times < d)
        {
            finalArr[i] = a[times];

            i++;
            times++;
        }

        return finalArr;
    }

    // Max num of sums that can be made in array
    public static int MaximumToys(int[] prices, int k)
    {
        int maxToys = 0;

        if (k > 0 && prices.Length > 0)
        {
            Array.Sort(prices);

            for (int i = 0; i < prices.Length; i++)
            {
                k -= prices[i];

                if (k < 0)
                    return maxToys;

                maxToys++;
            }
        }

        return maxToys;
    }

    // How many char need to be removed to make anagram
    public static int MakeAnagram(string a, string b)
    {
        int minDeletionsToMakeAnagram = 0;
        int[] a_frequencies = new int[26];
        int[] b_frequencies = new int[26];

        for (int i = 0; i < a.Length; i++)
        {
            char currentChar = a[i];
            int char_to_int = (int)currentChar;
            int position = char_to_int - (int)'a';
            a_frequencies[position]++;
        }

        for (int i = 0; i < b.Length; i++)
        {
            char currentChar = b[i];
            int char_to_int = (int)currentChar;
            int position = char_to_int - (int)'a';
            b_frequencies[position]++;
        }

        for (int i = 0; i < 26; i++)
        {
            int diff = Math.Abs(a_frequencies[i] - b_frequencies[i]);
            minDeletionsToMakeAnagram += diff;
        }

        return minDeletionsToMakeAnagram;
    }

    // How many chars need to be deleted to make alternating string
    public static int AlternatingCharacters(string s)
    {
        int min_deletions = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                min_deletions++;
            }
        }

        return min_deletions;
    }

    // Order two objects by score
    public static int ComparePlayers(Player a, Player b)
    {
        if (a.Name == b.Name)
        {
            a.Name.CompareTo(b.Name);
        }

        return b.Score - a.Score;
    }

    // Minimum difference in array
    public static int MinAbsDifference(int[] arr)
    {
        int minDiff = int.MaxValue;

        // Sort first
        Array.Sort(arr);

        // Iterate, compare and subtract
        for (int i = 0; i < arr.Length; i++)
        {
            int tempDiff = Math.Abs(arr[i] - arr[i + 1]);

            minDiff = Math.Min(minDiff, tempDiff);
        }

        return minDiff;
    }

    // Create new node, insert a node at a specific position and return head node
    public static LinkedNode InsertNodeAtPosition(LinkedNode head, int data, int position)
    {
        LinkedNode newNode = new(data);
        LinkedNode currentNode = head;
        int idx = 0;

        while (idx < position - 1)
        {
            currentNode = currentNode.Next;
            idx++;
        }

        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;

        return head;
    }

    public static int LuckBalance(int k, int[][] contests)
    {
        int maxLuck = 0;
        int luckCount = 0;
        int importance = 0;

        for (int i = 0; i < contests.Length; i++)
        {
            luckCount = contests[i][0];
            importance = contests[i][1];

            Sort<int>(contests, 1);

            if (importance == 1 && k > 0)
            {
                k--;
                maxLuck += luckCount;
            }
            else if (importance == 1 && k == 0)
            {
                maxLuck -= luckCount;
            }

            if (importance == 0)
            {
                maxLuck += luckCount;
            }
        }

        return maxLuck;
    }

    // 2d array sort helper method
    private static void Sort<T>(T[][] data, int col)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
    }

    public static int NumberOfSocks(List<int> socks)
    {
        int socksArrLength = socks.Count;
        List<int> coloredSocks = new();
        List<int> checkedSocks = new();

        for (int i = 0; i < socksArrLength; i++)
        {
            if (!checkedSocks.Contains(socks[i]))
            {
                int count = socks.Count(x => x == socks[i]) / 2;
                coloredSocks.Add(count);
                checkedSocks.Add(socks[i]);
            }
        }

        var sum = coloredSocks.Aggregate((temp, x) => temp + x);

        return sum;

        //int num_pairs = 0;
        //List<int> set = new List<int>();

        //if (socks.Count == 0)
        //    return num_pairs;

        //for (int i = 0; i < socks.Count; i++)
        //{
        //    if (!set.Contains(socks[i]))
        //    {
        //        set.Add(socks[i]);
        //    }
        //    else
        //    {
        //        num_pairs++;
        //        set.Remove(socks[i]);
        //    }
        //}

        //return num_pairs;
    }

    public static int CountingValleys(int n, string s)
    {
        int altitute = 0;
        int num_valleys = 0;
        var str = s.ToCharArray();

        for (int i = 0; i < n; i++)
        {
            if (str[i].ToString() == "U")
            {
                if (altitute == -1)
                    num_valleys++;

                altitute++;
            }
            if (str[i].ToString() == "D")
            {
                altitute--;
            }
        }

        return num_valleys;
    }

    public static int minSum(List<int> num, int k)
    {
        int n = num.Count;

        for (int i = 0; i < k; i++)
        {
            var maxIdx = CalcMaxIdx(num);

            if (num[maxIdx] == 1)
                break;

            num[maxIdx] = num[maxIdx] / 2 + num[maxIdx] % 2;
        }

        return num.Sum();
    }

    private static int CalcMaxIdx(List<int> array)
    {
        int maxIdx = 0;

        int max = array[0];

        for (int i = 1; i < array.Count; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIdx = i;
            }
        }

        return maxIdx;
    }

    public static int SumAll(List<int> arr)
    {
        int sum = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            sum = sum + arr[i];
        }

        return sum;
    }

    public static int CalcDiffDiagonal(int[][] numbers)
    {
        int sum_left_to_right = 0;
        int sum_right_to_left = 0;
        int rows = numbers.Length;
        int cols = numbers[0].Length;
        int i = 0;
        int j = 0;
        int k = 0;
        int l = numbers.Length - 1;

        while (i < rows && j < cols && k < rows && l >= 0)
        {
            sum_left_to_right += numbers[i][j];
            sum_right_to_left += numbers[k][l];
            i += 1;
            j += 1;
            k += 1;
            l -= 1;
        }

        return Math.Abs(sum_left_to_right - sum_right_to_left);
    }

    public static Node LowestCommonAncestor(Node root, int val1, int val2)
    {
        if (val1 > root.Data && val2 > root.Data)
        {
            return LowestCommonAncestor(root.Right, val1, val2);
        }

        if (val2 < root.Data && val2 < root.Data)
        {
            return LowestCommonAncestor(root.Left, val1, val2);
        }

        return root;
    }

    public static int JumpingClouds(int[] c)
    {
        int num_jumps = 0;
        int i = 0;

        while (i < c.Length - 1)
        {
            if (c[i + 2] == 1 || i + 2 == c.Length)
            {
                i++;
            }
            else
            {
                i += 2;
            }

            num_jumps++;
        }


        return num_jumps;
    }

    public static string BalancedBrackets(string s)
    {
        Stack<string> stack = new Stack<string>();
        List<string> list = new List<string>();
        string popped_val = string.Empty;

        foreach (var c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                list.Add(c.ToString());
            }
            else
            {
                if (list.Count == 0)
                {
                    return "NO";
                }
                else
                {
                    popped_val = list.LastOrDefault();
                    list.RemoveAt(list.Count - 1);

                    if (c == '(' || c == '{' || c == '[')
                    {
                        return "NO";
                    }
                    else if (c == '}' && popped_val != "{")
                    {
                        return "NO";
                    }
                    else if (c == ']' && popped_val != "[")
                    {
                        return "NO";
                    }
                }
            }
        }

        if (list.Count == 0)
            return "YES";
        else
            return "NO";
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public class LinkedNode
    {
        public LinkedNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }
        public LinkedNode Next { get; set; }
    }

    public class Player
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }
    #endregion METHODS
}