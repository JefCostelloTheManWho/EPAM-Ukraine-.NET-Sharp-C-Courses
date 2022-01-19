using System;

namespace MatrixLibrary
{
    public class MatrixException : Exception
    {
        public double Rows { get; }
        public double Columns { get; }
        public MatrixException(string message, double rows, double columns)
         : base(message)
        {
            Rows = rows;
            Columns = columns;
        }
    }
    public class Matrix : ICloneable
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double[,] Array { get; }
        public Matrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
            {
                throw new ArgumentOutOfRangeException($"{rows} or {columns} have negative dimensions");
            }
            this.Rows = rows;
            this.Columns = columns;
            this.Array = new double[rows, columns];
        }
        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"Array{array} is null");
            }
            if (array.GetLength(0) < 0 || array.GetLength(1) < 0)
            {
                throw new MatrixException($"{array.GetLength(0)} or {array.GetLength(1)} have negative dimensions", array.GetLength(0), array.GetLength(1));
            }
            this.Rows = array.GetLength(0);
            this.Columns = array.GetLength(1);
            this.Array = array;
        }
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0)
                {
                    throw new ArgumentException($"{row} and {column} have wrong arguments");
                }
                return Array[row, column];
            }
            set
            {
                if (row < 0 || column < 0)
                {
                    throw new ArgumentException($"{row} and {column} have wrong arguments");
                }
                Array[row, column] = value;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException($"Matrix is null {matrix1}");
            }
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Columns and rows are not same", matrix1.Columns, matrix2.Columns);
            }
            Matrix newMatrix = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int row = 0; row < newMatrix.Rows; row++)
            {
                for (int col = 0; col < newMatrix.Columns; col++)
                {
                    newMatrix[row, col] += matrix1[row, col] + matrix2[row, col];
                }
            }
            return newMatrix;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException($"Matrix is null {matrix1}");
            }
            Matrix matrix = new Matrix(matrix1.Rows, matrix1.Columns);
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Columns and rows are not same", matrix1.Columns, matrix2.Columns);
            }
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    matrix[row, col] += matrix1[row, col] - matrix2[row, col];
                }
            }
            return matrix;
        }
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException($"Matrix is null {matrix1}");
            }
            if ((matrix1.Rows <= 0 && matrix1.Columns <= 0) || (matrix2.Rows <= 0 && matrix2.Columns <= 0))
            {
                throw new MatrixException("Matrix don't have elements", matrix1.Rows, matrix2.Rows);
            }
            Matrix newMatrix = new Matrix(matrix1.Rows, matrix2.Columns);
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix2.Columns; col++)
                {
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        newMatrix[row, col] += matrix1[row, k] * matrix2[k, col];
                    }
                }
            }
            return newMatrix;
        }
        public Matrix Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException($"{matrix} is null.");
            }
            if (this.Columns != matrix.Columns || this.Rows != matrix.Rows)
            {
                throw new MatrixException($"Matrix should be has same rows and columns", matrix.Rows, matrix.Columns);
            }
            var newMatrix = new Matrix(matrix.Rows, matrix.Columns);
            matrix = new Matrix(matrix.Array);
            for (int row = 0; row < newMatrix.Rows; row++)
            {
                for (int col = 0; col < newMatrix.Columns; col++)
                {
                    newMatrix[row, col] = this[row, col] + matrix[row, col];
                }
            }
            return newMatrix;
        }
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException($"{matrix} is null.");
            }
            if (this.Columns != matrix.Columns || this.Rows != matrix.Rows)
            {
                throw new MatrixException($"Matrix should be has same rows and columns", matrix.Rows, matrix.Columns);
            }
            matrix = new Matrix(matrix.Array);
            var newMatrix = new Matrix(this.Rows, this.Columns);
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    newMatrix[row, col] = this[row, col] - matrix[row, col];
                }
            }
            return newMatrix;
        }
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException($"{matrix} is null");
            }
            if ((this.Columns == 0 && this.Rows == 0) || (matrix.Rows == 0 && matrix.Columns == 0))
            {
                throw new MatrixException($"Matrix is empty", matrix.Columns, matrix.Rows);
            }
            Matrix newMatrix;
            if (this.Rows == matrix.Columns && this.Columns == matrix.Rows)
            {
                newMatrix = new Matrix(this.Rows, matrix.Columns);
            }
            else
            {
                newMatrix = new Matrix(this.Rows, this.Columns);
            }
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    for (int k = 0; k < this.Columns; k++)
                    {
                        newMatrix[row, col] += this[row, k] * matrix[k, col];
                    }
                }
            }
            return newMatrix;
        }
        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            if ((matrix is null) || obj.GetType() != this.GetType() || (this.Rows != matrix.Rows) || (this.Columns != matrix.Columns))
            {
                return false;
            }
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (Array[row, col] != matrix.Array[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return this.Array.GetHashCode();
        }
    }
}
