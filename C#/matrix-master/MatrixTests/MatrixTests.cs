using System;
using MatrixLibrary;
using NUnit.Framework;

namespace MatrixTests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001)]
    public class Tests
    {
        #region Startup Data

        #region ArraysCreateMatrix

        private static readonly object[] ArraysCreateMatrix =
        {
            new object[]
            {
                new double[3, 4]
                {
                    {1, 2, 3, 4},
                    {1, 2, 3, 4},
                    {1, 2, 3, 4}
                }
            }
        };

        #endregion

        #region ArraysEqualsException

        private static readonly object[] ArraysEqualsException =
        {
            new object[]
            {
                new double[,]{{1 ,1}}, 
                
                new double[,]
                {
                    {4, 3, 2},
                    {4, 3, 2},
                    {4, 3, 2},
                    {4, 3, 2}
                }
            }
        };

        #endregion
        
        #region ArraysPlusOperator

        private static readonly object[] ArraysPlusOperator =
        {
            new object[]
            {
                new double[3, 4]
                {
                    {1, 2, 3, 4},
                    {1, 2, 3, 4},
                    {1, 2, 3, 4}
                },
                new double[3, 4]
                {
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                },
                new double[3, 4]
                {
                    {5, 5, 5, 5},
                    {5, 5, 5, 5},
                    {5, 5, 5, 5},
                }
            }
        };

        #endregion

        #region ArraysPlusAndMinusOperatorException

        private static readonly object[] ArraysPlusAndMinusOperatorException =
        {
            new object[] {new double[1, 1] { { 1 } }, new double[1, 0] { { }}},
        };

        #endregion
        
        #region ArraysMinusOperator

        private static readonly object[] ArraysMinusOperator =
        {
            new object[]
            {
                new double[3, 4]
                {
                    {1, 2, 3, 4},
                    {1, 2, 3, 4},
                    {1, 2, 3, 4}
                },
                new double[3, 4]
                {
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                },
                new double[3, 4]
                {
                    {-3, -1, 1, 3},
                    {-3, -1, 1, 3},
                    {-3, -1, 1, 3},
                }
            }
        };

        #endregion
        
        #region ArraysOperatorMultiply

        private static readonly object[] ArraysOperatorMultiply =
        {
            new object[]
            {
                new double[2, 2] {{2, 2}, {2, 2}}, new double[2, 2] {{2, 2}, {2, 2}}, new double[2, 2] {{8, 8}, {8, 8}}
            },
            new object[]
            {
                new double[2, 3]
                {
                    {1, 4, 2},
                    {2, 5, 1}
                },
                new double[3, 3]
                {
                    {3, 4, 2},
                    {3, 5, 7},
                    {1, 2, 1}
                },
                new double[2, 3]
                {
                    {17, 28, 32},
                    {22, 35, 40}
                }
            },
            new object[]
            {
                new double[4, 3]
                {
                    {1, 2, 3},
                    {1, 2, 3},
                    {1, 2, 3},
                    {1, 2, 3}
                },
                new double[3, 4]
                {
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                },
                new double[4, 4]
                {
                    {24, 18, 12, 6},
                    {24, 18, 12, 6},
                    {24, 18, 12, 6},
                    {24, 18, 12, 6}
                }
            }
        };
        
        #endregion
        
        #region ArraysOperatorMultiplyException

        private static readonly object[] ArraysOperatorMultiplyException =
        {
            new object[] {new double[1, 1] {{1}}, new double[0, 0] { }},
        };

        #endregion

        #region ArraysEquals

        private static readonly object[] ArraysEquals =
        {
            new object[] {new double[1, 1] {{1}}, new double[1, 1] { {1} }, true},
            new object[] {new double[1, 1] {{1}}, new double[1, 1] { {-1} }, false}
        };

        #endregion

        #region ArraysEqualsTrowsExceptions

        private static readonly object[] ArraysEqualsTrowsExceptions =
        {
            new object[] {new double[1,2]{{1, 2}}, new double[2,2]{{1, 2}, {1, 2}}},
            new object[] {new double[2,1]{{1}, {1}}, new double[2,2]{{1, 2}, {1, 2}}}
        };

        #endregion
        
        #endregion

        #region Low

        [TestCaseSource(nameof(ArraysCreateMatrix))]
        public void CreateMatrix_WithArray_PublicProperties_ReturnsCorrectValues(double[,] expectedArray)
        {
            var expectedRows = expectedArray.GetLength(0);
            var expectedColumns = expectedArray.GetLength(1);

            var matrix = new Matrix(expectedArray);

            Assert.AreEqual(expectedRows, matrix.Rows);
            Assert.AreEqual(expectedColumns, matrix.Columns);
        }
        
        [TestCase(3, 4)]
        [TestCase(3, 5)]
        [TestCase(2, 2)]
        public void CreateMatrix_WithDimensions_PublicProperties_ReturnsCorrectValues(int expectedRows,
            int expectedColumns)
        {
            var matrix = new Matrix(expectedRows, expectedColumns);

            Assert.AreEqual(expectedRows, matrix.Rows);
            Assert.AreEqual(expectedColumns, matrix.Columns);
        }

        [TestCaseSource(nameof(ArraysCreateMatrix))]
        public void Indexer_GetEachElement_ShouldReturnValue(double[,] array)
        {
            var matrix = new Matrix(array);

            var isValid = true;
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (Math.Abs(matrix[i, j] - array[i, j]) > 0.001) isValid = false;
                }
            }

            Assert.AreEqual(true, isValid, message: "Indexer works incorrectly.");
        }
        
        [TestCase(4, 3)]
        [TestCase(3, 4)]
        [TestCase(2, 2)]
        public void Indexer_SetElement_ShouldChangeValue(int rows, int columns)
        {
            var matrix = new Matrix(rows, columns);
            const int expected1 = 1337;
            const int expected2 = 228;

            matrix[rows - 1, columns - 1] = expected1;
            matrix[0, 0] = expected2;

            Assert.AreEqual(expected1, matrix[rows - 1, columns - 1],
                message: "Set property in indexer works incorrectly.");
            Assert.AreEqual(expected2, matrix[0, 0], message: "Set property in indexer works incorrectly.");
        }

        [TestCaseSource(nameof(ArraysOperatorMultiply))]
        public void Multiply_Matrix_ReturnsResultMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1.Multiply(matrix2);

            Assert.AreEqual(expected.Array, actual.Array, "Multiply method works incorrectly.");
        }
        
        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Add_Matrix_ReturnsResultMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1.Add(matrix2);

            Assert.AreEqual(expected.Array, actual.Array, message: "Add method works incorrectly.");
        }
        
        [TestCaseSource(nameof(ArraysMinusOperator))]
        public void Subtract_Matrix_ReturnsResultMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1.Subtract(matrix2);

            Assert.AreEqual(expected.Array, actual.Array, message: "Subtract method works incorrectly.");
        }
        
        [TestCaseSource(nameof(ArraysCreateMatrix))]
        public void ToArray_ReturnsMatrixAsArray(double[,] expectedArray)
        {
            var matrix = new Matrix(expectedArray);

            var arrayMatrix = matrix.Array;

            Assert.AreEqual(expectedArray, arrayMatrix,
                message: "ToArray method returns array that is not equal to expected.");
            
        }
        
        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void PlusOperator_AddingMatrices_ReturnsMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1 + matrix2;

            Assert.AreEqual(expected.Array, actual.Array, message: "Plus operator works incorrectly.");
        }
        
        [TestCaseSource(nameof(ArraysMinusOperator))]
        public void MinusOperator_SubtractingMatrices_ReturnsMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1 - matrix2;

            Assert.AreEqual(expected.Array, actual.Array, message: "Minus operator works incorrectly.");
        }
        
        [TestCaseSource(nameof(ArraysOperatorMultiply))]
        public void MultiplyOperator_MultiplyMatrices_ReturnsMatrix(double[,] array1, double[,] array2,
            double[,] expectedArray)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            var expected = new Matrix(expectedArray);

            var actual = matrix1 * matrix2;

            Assert.AreEqual(expected.Array, actual.Array, message: "Multiply operator works incorrectly.");
        }
        #endregion
        
        //TODO: Uncomment this if you want to check your task for advanced unit tests
        /*
        #region Advanced
        
        [TestCase(4, 3)]
        [TestCase(3, 4)]
        public void Indexer_GetElementOutOfRange_ArgumentExceptionThrown(int rows, int columns)
        {
            var matrix = new Matrix(rows, columns);
            var expectedException = typeof(ArgumentException);
            
            var actException = Assert.Catch(() => _ = matrix[-1, -1]);

            Assert.AreEqual(expectedException, actException.GetType(),
                message: "Indexer should throw argument exception in case of nonexistent index.");
        }

        [TestCase(4, 3)]
        [TestCase(3, 4)]
        public void Indexer_SetElementOutOfRange_ArgumentExceptionThrown(int rows, int columns)
        {
            var matrix = new Matrix(rows, columns);
            var expectedException = typeof(ArgumentException);

            var actException = Assert.Catch(() => matrix[-1, -1] = 1337);

            Assert.AreEqual(expectedException, actException.GetType(), 
                message: "Set property in indexer should throw argument exception in case of nonexistent index.");
        }
        

        [TestCase(-1, 2)]
        [TestCase(1, -2)]
        public void CreateMatrix_WithNegativeDimensions_ArgumentOutOfRangeExceptionThrown(int rows, int columns)
        {
            var expectedException = typeof(ArgumentOutOfRangeException);

            var actException = Assert.Catch(() => new Matrix(rows, columns));

            Assert.AreEqual(expectedException, actException.GetType(), message: "Matrix can't be created with negative dimensions.");
        }

        [Test]
        public void CreateMatrix_WithNull_ArgumentNullExceptionThrown()
        {
            var expectedException = typeof(ArgumentNullException);

            var actException = Assert.Catch(() => new Matrix(null));

            Assert.AreEqual(expectedException, actException.GetType(), 
                message: "Matrix can't be created with null argument.");
        }
        
        [TestCaseSource(nameof(ArraysPlusAndMinusOperatorException))]
        public void PlusOperator_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => _ = matrix1 + matrix2);

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), 
                message: "Plus operator should throw matrix exception in case of inappropriate matrices dimensions.");
        }

        [TestCaseSource(nameof(ArraysPlusAndMinusOperatorException))]
        public void MinusOperator_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => _ = matrix1 - matrix2);

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), 
                message: "Minus operator should throw matrix exception in case of inappropriate matrices dimensions.");
        }
        
        [TestCaseSource(nameof(ArraysOperatorMultiplyException))]
        public void MultiplyOperator_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => _ = matrix1 * matrix2);

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), message:
                "Multiply operator should throw matrix exception in case of inappropriate matrices dimensions.");
        }
        
        [TestCaseSource(nameof(ArraysOperatorMultiplyException))]
        public void Multiply_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            
            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => matrix1.Multiply(matrix2));

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), message: "Multiply method should throw matrix exception in case of inappropriate matrices dimensions.");
        }
        
        [TestCaseSource(nameof(ArraysPlusAndMinusOperatorException))]
        public void Add_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);
            
            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => matrix1.Add(matrix2));

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), message: "Add method should throw matrix exception in case of inappropriate matrices dimensions.");
        }
        
        [TestCaseSource(nameof(ArraysPlusAndMinusOperatorException))]
        public void Subtract_MatricesHaveInappropriateDimensions_MatrixExceptionThrown(double[,] array1,
            double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            var expectedException = Type.GetType("MatrixLibrary.MatrixException, MatrixLibrary");
            var actException = Assert.Catch(() => matrix1.Subtract(matrix2));

            Assert.NotNull(expectedException, message: "'MatrixException' is not implemented.");
            Assert.AreEqual(expectedException, actException.GetType(), message: "Subtract method should throw matrix exception in case of inappropriate matrices dimensions.");
        }

        [Test]
        public void PlusOperator_ThrowsArgumentNullExceptions_IfFirstArgumentIsNull()
        {
            Matrix matrix1 = null;
            Matrix matrix2 = new Matrix(1, 1);

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 + matrix2;
            },message:"Operator '+' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void PlusOperator_ThrowsArgumentNullExceptions_IfSecondArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 + matrix2;
            },message:"Operator '+' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void SubtractOperator_ThrowsArgumentNullExceptions_IfFirstArgumentIsNull()
        {
            Matrix matrix1 = null;
            Matrix matrix2 = new Matrix(1, 1);

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 - matrix2;
            },message:"Operator '-' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void SubtractOperator_ThrowsArgumentNullExceptions_IfSecondArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 - matrix2;
            },message:"Operator '-' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void MultiplyOperator_ThrowsArgumentNullExceptions_IfFirstArgumentIsNull()
        {
            Matrix matrix1 = null;
            Matrix matrix2 = new Matrix(1, 1);

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 * matrix2;
            },message:"Operator '*' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void MultiplyOperator_ThrowsArgumentNullExceptions_IfSecondArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1 * matrix2;
            },message:"Operator '*' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void Add_ThrowsArgumentNullExceptions_IfArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1.Add(matrix2);
            },message:"Method 'Add' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void Subtract_ThrowsArgumentNullExceptions_IfArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1.Subtract(matrix2);
            },message:"Method 'Subtract' should throw ArgumentNullException if one of arguments is null.");
        }
        
        [Test]
        public void Multiply_ThrowsArgumentNullExceptions_IfArgumentIsNull()
        {
            Matrix matrix1 = new Matrix(1, 1);
            Matrix matrix2 = null;

            Assert.Catch<ArgumentNullException>(() =>
            {
                var res1 = matrix1.Multiply(matrix2);
            },message:"Method 'Multiply' should throw ArgumentNullException if one of arguments is null.");
        }
        

        [TestCaseSource(nameof(ArraysEquals))]
        public void Equals_CompareMatrices_ReturnsCorrectBoolean(double[,] array1, double[,] array2,
            bool expectedResult)
        {
            // Arrange
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            // Act
            var actualResult = matrix1.Equals(matrix2);

            // Assert
            Assert.AreEqual(expectedResult, actualResult,
                message: "Equals method doesn't compares matrices correctly.");
        }
        
        [Test]
        public void Equals_CompareWithNull_ReturnsFalse()
        {
            // Arrange
            var array = new double[2, 2] {{1, 2}, {1, 2}};
            var matrix = new Matrix(array);

            // Act
            var result = matrix.Equals(null);
            
            // Assert
            Assert.AreEqual(false, result, message: "Equals method doesn't compares matrices correctly.");
        }
        
        [Test]
        public void Equals_CompareWithNotMatrix_ReturnsFalse()
        {
            var array = new double[2, 2] {{1, 2}, {1, 2}};
            var matrix = new Matrix(array);

            var result = matrix.Equals(1337);
            
            Assert.AreEqual(false, result, message: "Equals method doesn't compares matrices correctly.");
        }
        
        [TestCaseSource(nameof(ArraysEqualsTrowsExceptions))]
        public void Equals_CompareIncomparableMatrices_DoesntThrowException(double[,] array1, double[,] array2)
        {
            var matrix1 = new Matrix(array1);
            var matrix2 = new Matrix(array2);

            Assert.DoesNotThrow(() => { 
                var result1 = matrix1.Equals(matrix2);
                var result2 = matrix2.Equals(matrix1);
            }, message:"Equals should not throw exceptions.");
        }
        
        [TestCaseSource(nameof(ArraysCreateMatrix))]
        public void Clone_Should_ReturnDeepCopy(double[,] array)
        {
            var matrix = new Matrix(array);

            var matrixClone = (Matrix) matrix.Clone();

            var referenceEquals = ReferenceEquals(matrix, matrixClone);
            
            Assert.AreEqual(matrix, matrixClone, 
                message: "Matrices should be equal.");
            Assert.AreEqual(false, referenceEquals, 
                message: "Matrix and its clone should not refer to the same object.");
        }
        
        #endregion
        
        */
    }
}
