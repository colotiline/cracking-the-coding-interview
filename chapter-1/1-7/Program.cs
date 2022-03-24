// See https://aka.ms/new-console-template for more information
var matrix = new int[3, 4]
{
    { 1, 2, 3, 4 },
    { 5, 0, 6, 7 },
    { 8, 9, 10, 0 }
};

WriteMatrix(matrix);

SetMatrixZeroes(matrix);

WriteMatrix(matrix);

static void WriteMatrix(int[,] image)
{
    for (var i = 0; i < image.GetLength(0); i++)
    {
        for (var j = 0; j < image.GetLength(1); j++)
        {
            Console.Write(image[i, j]);
            Console.Write('\t');
        }

        Console.Write('\n');
    }

    Console.Write('\n');
}

static void SetMatrixZeroes(int[,] matrix)
{
    var zeroesRows = new HashSet<int>();
    var zeroesColumns = new HashSet<int>();

    for (var row = 0; row < matrix.GetLength(0); row++)
    {
        for (var column = 0; column < matrix.GetLength(1); column++)
        {
            if (matrix[row, column] == 0)
            {
                zeroesRows.Add(row);
                zeroesColumns.Add(column);
            }
        }
    }

    for (var row = 0; row < matrix.GetLength(0); row++)
    {
        for (var column = 0; column < matrix.GetLength(1); column++)
        {
            if 
            (
                zeroesRows.Contains(row)
                || zeroesColumns.Contains(column)
            )
            {
                matrix[row, column] = 0;
            }
        }
    }
}