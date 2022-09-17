using System;

class Program
{

    public static Int32[][] InitializeMatrix(Int32 vertices)
    {
        Int32[][] ret = new Int32[vertices][];
        for (int i = 0; i < ret.Length; i++)
        {
            ret[i] = new Int32[vertices];
        }
        return ret;
    }

    public static void PrintMatrix(Int32[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write("{0} ", matrix[i][j]);
            }
            Console.WriteLine();
        }
    }

    // Added here
    public static Int32[][] RotateMatrix(Int32[][] matrix)
    {
        Int32[][] ret = InitializeMatrix(matrix.Length);
        for (int i = 0; i < ret.Length; i++)
        {
            for (int j = 0; j < ret[i].Length; j++)
            {
                ret[j][matrix.Length - i - 1] = matrix[i][j];
            }
        }
        return ret;
    }


    public static void Main(string[] args)
    {
        Int32 vertices = Convert.ToInt32(Console.ReadLine());
        Int32[][] adjacencyMatrix = InitializeMatrix(vertices);
        Int32 edges = Convert.ToInt32(Console.ReadLine());
        Int32 i, j, c;
        for (c = 0; c < edges;)
        {
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            if (inputs[0] == "" | inputs[1] == "") break;
            if (Convert.ToInt32(inputs[0]) > vertices |
                Convert.ToInt32(inputs[1]) > vertices) continue;
            i = Convert.ToInt32(inputs[0]);
            j = Convert.ToInt32(inputs[1]);
            ++adjacencyMatrix[i - 1][j - 1];
            ++adjacencyMatrix[j - 1][i - 1];
            ++c;
        }
        Console.WriteLine("{0}", c);
        PrintMatrix(adjacencyMatrix);
        Console.WriteLine();
        PrintMatrix(RotateMatrix(adjacencyMatrix));
    }
}