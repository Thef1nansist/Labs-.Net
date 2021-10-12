namespace Task2
{
    public static class Extensions
    {
        public static TestMatrix Sum(this TestMatrix matrix1, TestMatrix matrix2)
        {
            var length = 0;

            if (matrix1.Size != matrix2.Size)
            {
                if (matrix1.Size > matrix2.Size)
                {
                    length = matrix1.Size;
                    matrix2 = new TestMatrix(createNewArr(length, matrix2));
                }
                else
                {
                    length = matrix2.Size;
                    matrix1 = new TestMatrix(createNewArr(length, matrix1));
                }
            }

            int[] newMatrix = new int[length];

            for (var i = 0; i < length; i++)
            {
                newMatrix[i] = matrix1[i, i] + matrix2[i, i];
            }

            return new TestMatrix(newMatrix);
        }

        private static int[] createNewArr(int lenght, TestMatrix matrix)
        {
            var newMatrix = new int[lenght];

            for (var i = 0; i < matrix.Size; i++)
            {
                newMatrix[i] += matrix[i, i];
            }

            return newMatrix;
        }
    }
}
