// See https://aka.ms/new-console-template for more information
var image = new int[3, 3] 
{   
    { 0, 1, 2 },
    { 3, 4, 5 },
    { 6, 7, 8 }
};

WriteImage(image);

RotateImageClockwise90(image);

WriteImage(image);

static void RotateImageClockwise90(int[,] image)
{
    var length = image.GetLength(0);

    for (int row = 0; row < length / 2; row++)
    {
        for (int column = row; column < length - row - 1; column++)
        {
            int top = image[row, column];
            
            image[row, column] = image[length - 1 - column, row];
            
            image[length - 1 - column, row] = 
                image[length - 1 - row, length - 1 - column];
            
            image[length - 1 - row, length - 1 - column] = 
                image[column, length - 1 - row];
            
            image[column, length - 1 - row] = top;
        }
    }
}

static void WriteImage(int[,] image)
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