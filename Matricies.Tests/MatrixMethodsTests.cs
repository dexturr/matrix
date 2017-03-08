using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matricies.Classes;

namespace Matricies.Tests
{
    [TestClass]
    public class MatrixMethodsTests
    {
        private static Matrix2D matrix { get; set; }
        [ClassInitialize]
        public static void InitTestSuite(TestContext testContext)
        {
            decimal[,] testArray = {    {/*0,0*/ 2.3m, 4.5m, 5.6m , 7.3m, 5.4m},
                                    { 3.3m, 5.5m, 6.6m, 8.3m, 6.4m },
                                    { 4.3m, 6.5m, 7.6m, 9.3m, 7.4m },
                                    { 5.3m, 7.5m, 8.6m, 10.3m, 8.4m /*4,3*/} };
            matrix = new Matrix2D(testArray);
        }
        //Done
        #region GetElementTests
        [TestMethod]
        public void GetElement_ZeroIndex_ReturnsCorrectValue()
        {
            //Arrange
            //Act && Assert
            Assert.AreEqual(2.3m, matrix.GetElement(0,0));

        }

        [TestMethod]
        public void GetElement_MaximumIndex_ReturnsCorrectValue()
        {
            //Arrange
            //Act && Assert
            Assert.AreEqual(8.4m, matrix.GetElement(4,3));

        }

        [TestMethod]
        public void GetElement_OutOfRangeXIndex_ThrowsException()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.GetElement(7, 0);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }
        [TestMethod]
        public void GetElement_OutOfRangeYIndex_ThrowsException()
        {
            try
            {
                matrix.GetElement(0, 16);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }

        #endregion
        //Done 
        #region SetElementTests
        [TestMethod]
        public void SetElement_ZeroIndex_TakesValue()
        {
            //Arrange
            matrix.SetElement(0, 0, 8.6m);

            //Act && Assert
            Assert.AreEqual(8.6m, matrix.GetElement(0, 0));
        }

        [TestMethod]
        public void SetElement_MaximumIndex_TakesValue()
        {
            //Arrange
            matrix.SetElement(4, 3, 3.4m);

            //Act && Assert
            Assert.AreEqual(3.4m, matrix.GetElement(4, 3));

        }

        [TestMethod]
        public void SetElement_OutOfRangeXIndex_ThrowsException()
        {
            //Arrange
            //Act && Asserttry 
            try
            {

                matrix.SetElement(7, 0, 15);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }
        [TestMethod]
        public void SetElement_OutOfRangeYIndex_ThrowsException()
        {
            //Arrange
            //Act && Assert
            try
            {

                matrix.SetElement(0, 16, 15);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }

        #endregion
        //Done
        #region IsSquareTests
        [TestMethod]
        public void IsSquare_WithNonSquareMatrix_ReturnsFalse()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsFalse(matrix.IsSquare);
        }
        [TestMethod]
        public void IsSquare_WithSquareMatrix_ReturnsTrue()
        {
            //Arrange
            decimal[,] testArray = {    {/*0,0*/ 2.3m, 4.5m, 5.6m , 7.3m, 5.4m},
                                    { 3.3m, 5.5m, 6.6m, 8.3m, 6.4m },
                                    { 4.3m, 6.5m, 7.6m, 9.3m, 7.4m },
                                    { 5.3m, 7.5m, 8.6m, 10.3m, 8.4m},
                                    { 5.3m, 7.5m, 8.6m, 10.3m, 8.4m /*4,4*/} };

            //Act
            Matrix2D squareMatrix = new Matrix2D(testArray);

            //Assert
            Assert.IsTrue(squareMatrix.IsSquare);
        }

        [TestMethod]
        public void IsSquare_WithZeroSizeMatrix_ReturnsTrue()
        {
            //Arrange

            Matrix2D zeroSizeMatrix = new Matrix2D(0, 0);

            //Act

            //Assert
            Assert.IsTrue(zeroSizeMatrix.IsSquare);
        }
        #endregion
        //Done
        #region IsInvertible Tests

        [TestMethod]
        public void IsInvertible_WithNonSquareMatrix_ReturnsFalse()
        {
            //Arrange //Act //Assert
            Assert.IsFalse(matrix.IsInveritible());
        }

        [TestMethod]
        public void IsInvertible_WithSquareMatrixAndZeroDeterminant_ReturnsFalse()
        {
            //Arrange //Act //Assert
            Matrix2D matrixWithZeroDeterminant = new Matrix2D(5, 5);

            Assert.IsFalse(matrixWithZeroDeterminant.IsInveritible());
        }

        [TestMethod]
        public void IsInvertiable_WithSquareMatrixAndNonzeroDeterminant_ReturnsTrue()
        {
            //Arrange
            decimal[,] matrixArray = {{1,22,33,54},
                                      {-42,-55,-44,-50},
                                      {3,-34,5,-34},
                                      {43,54,56,78} };
            Matrix2D matrixWithDeterminant = new Matrix2D(matrixArray);


            //Assert
            Assert.IsTrue(matrixWithDeterminant.IsInveritible());

        }

        #endregion
        //MOre to write (Not passing)
        #region Submatrix Test
        [TestMethod]
        public void SubMatrix_WithOutOfRangeStartX_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(7, 0);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }

        }

        [TestMethod]
        public void SubMatrix_WithOutOfRangeStartY_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(0, 16);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }

        }

        [TestMethod]
        public void SubMatrix_WithOutOfRangeEndX_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(0, 0, 16, 1);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }

        }

        [TestMethod]
        public void SubMatrix_WithOutOfRangeEndY_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(0, 0, 1, 16);
                Assert.Fail("Atempted to access out of range element and succeced");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }

        }

        [TestMethod]
        public void SubMatrix_With0SizeMatrix_ReturnsMatrixOfZeroSize()
        {
            //Arrange

            Matrix2D zeroSizeMatrix = new Matrix2D(0, 0);
            //Act

            var subMatrix = zeroSizeMatrix.Submatrix(0, 0);

            Assert.AreEqual(0, subMatrix.Width);
            Assert.AreEqual(0, subMatrix.Height);


            //Assert
        }

        [TestMethod]
        public void SubMatrix_WithStartYGreaterThanEndY_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(1, 1, 0, 2);
                Assert.Fail("End x position must be greater than the x start position");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }
        }

        [TestMethod]
        public void SubMatrix_WithStartXGreaterThanEndX_ThrowsError()
        {
            //Arrange
            //Act && Assert
            try
            {
                matrix.Submatrix(1, 1, 2, 0);
                Assert.Fail("End x position must be greater than the x start position");
            }

            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }
        }

        [TestMethod]
        public void SubMatrix_WithStartXYEqualToEndXY_ReturnsMatrixOfZeroSize()
        {
            //Arrane
            //Act && Assert
            Matrix2D zeroMatrix = matrix.Submatrix(1, 1, 1, 1);
            Assert.AreEqual(0, zeroMatrix.Width);
            Assert.AreEqual(0, zeroMatrix.Height);
        }


        [TestMethod]
        public void SubMatrix_FromOrgin_ReturnsCorrectSubmatrix()
        {
            //Arrange
            //Act
            Matrix2D subMatrix = matrix.Submatrix(0, 0, 1, 1);

            //Assert
            Assert.AreEqual(subMatrix.Width, 1);
            Assert.AreEqual(subMatrix.Height, 1);
            for (int x = 0; x < subMatrix.Width; x++)
            {
                for (int y = 0; y < subMatrix.Height; y++)
                {
                    Assert.AreEqual(subMatrix.GetElement(x, y), matrix.GetElement(x, y));
                }
            }
        }

        [TestMethod]
        public void SubMatrix_FromMiddleOfMatrix_ReturnsCorrectSubmatrix()
        {
            //Arrange
            //Act
            Matrix2D subMatrix = matrix.Submatrix(2, 2, 4, 4);

            //Assert
            Assert.AreEqual(subMatrix.Width, 2);
            Assert.AreEqual(subMatrix.Height, 2);
            for (int x = 0; x < subMatrix.Width; x++)
            {
                for (int y = 0; y < subMatrix.Height; y++)
                {
                    Assert.AreEqual(subMatrix.GetElement(x, y), matrix.GetElement(2 + x, 2 + y));
                }
            }

        }


        #endregion
        //Done
        #region Determinant Tests
        [TestMethod]
        public void Determinant_With2x2Matrix_IsCalulculatedCorrectly()
        {
            //Arrange
            decimal[,] matrixArray = { { 1, -2},
                                       { -5, 2 } };
            Matrix2D matrixWithDeterminant = new Matrix2D(matrixArray);

            //Act //Assert
            Assert.AreEqual(-8, matrixWithDeterminant.Determinant());

        }

        [TestMethod]
        public void Determinant_With3x3Matrix_IsCalculatedCorrectly()
        {
            //Arrange
            decimal[,] matrixArray = { { 1, -2, 4 },
                                       { -5, 2, 0 },
                                       { 1, 0, 3 } };
            Matrix2D matrixWithDeterminant = new Matrix2D(matrixArray);

            //Act //Assert
            Assert.AreEqual(-32, matrixWithDeterminant.Determinant());
        }

        [TestMethod]
        public void Determinant_With4x4Matrix_IsCalculatedCorrectly()
        {
            //Arrange
            decimal[,] matrixArray = {{1,22,33,54},
                                      {-42,-55,-44,-50},
                                      {3,-34,5,-34},
                                      {43,54,56,78} };
            Matrix2D matrixWithDeterminant = new Matrix2D(matrixArray);

            //Act //Assert
            Assert.AreEqual(970052, matrixWithDeterminant.Determinant());

        }

        [TestMethod]
        public void Determinant_WithMatrixOfSize0_ReturnsZero()
        {
            //Arrange
            Matrix2D matrixWithZeroSize = new Matrix2D(0, 0);

            //Act //Assert
            Assert.AreEqual(0, matrixWithZeroSize.Determinant());

        }
        #endregion      
    }
}
