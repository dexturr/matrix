using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matricies.Classes;

namespace Matricies.Tests
{
    [TestClass]
    public class MatrixOperatorTests
    {
        private static Matrix2D GetTestMatrix()
        {
            decimal[,] testArray = {    {/*0,0*/ 1m, 2m, 3m , 4m, 5m},
                                    { 6m, 7m, 8m, 9m, 10m },
                                    { 11m, 12m, 13m, 14m, 15m},
                                    { 16m, 17m, 18m, 19m, 20m /*4,3*/} };
            var matrix = new Matrix2D(testArray);
            return matrix;
        }

        #region Multiply

        [TestMethod]
        public void MatrixMultiplyRightOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = matrix * 2;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2, newMatrix.GetElement(0, 0));
            Assert.AreEqual(40, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyRightOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix * 2.3m;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(46m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyRightOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix * 2.3;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(46m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyRightOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix * 3.2f;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(64, (double)newMatrix.GetElement(4, 3), 0.00001);
        }

        [TestMethod]
        public void MatrixMultiplyLeftOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = 2 * matrix;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2, newMatrix.GetElement(0, 0));
            Assert.AreEqual(40, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyLeftOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 2.3m * matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(46m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyLeftOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 2.3 * matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(46m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixMultiplyLeftOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 3.2f * matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(64, (double)newMatrix.GetElement(4, 3), 0.00001);
        }

        #endregion

        #region Add

        [TestMethod]
        public void MatrixAddRightOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = matrix + 2;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddRightOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix + 2.3m;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddRightOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix + 2.3;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddRightOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix + 3.2f;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(4.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(23.2, (double)newMatrix.GetElement(4, 3), 0.00001);
        }

        [TestMethod]
        public void MatrixAddLeftOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = 2 + matrix;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddLeftOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 2.3m + matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddLeftOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 2.3 + matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(3.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(22.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixAddLeftOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = 3.2f + matrix;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(4.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(23.2, (double)newMatrix.GetElement(4, 3), 0.00001);
        }

        #endregion

        #region Divide

        [TestMethod]
        public void MatrixDivideRightOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = matrix / 2;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(0.5m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(10m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixDivideRightOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix / 2.3m;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(1 / 2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(20 / 2.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixDivideRightOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix / 2.3;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(1 / 2.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(20 / 2.3m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixDivideRightOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix / 3.2f;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(1 / 3.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(20 / 3.2, (double)newMatrix.GetElement(4, 3), 0.00001);
        }
        #endregion

        #region Subtract

        [TestMethod]
        public void MatrixSubtractRightOperator_WithIntegerValue_EvaluatesCorrectly()
        {
            //Arrange
            Matrix2D matrix = GetTestMatrix();


            //Act
            var newMatrix = matrix - 2;

            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(-1, newMatrix.GetElement(0, 0));
            Assert.AreEqual(18, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixSubtractRightOperator_WithDecimalValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix - 2.3m;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(-1.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(17.7m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixSubtractRightOperator_WithDoubleValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix - 2.3;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(-1.3m, newMatrix.GetElement(0, 0));
            Assert.AreEqual(17.7m, newMatrix.GetElement(4, 3));
        }

        [TestMethod]
        public void MatrixSubtractRightOperator_WithFloatValue_EvaluatesCorrectly()
        {
            //Arrange


            //Act
            Matrix2D matrix = GetTestMatrix();
            var newMatrix = matrix - 3.2f;
            //Assert

            //The returned matrix is the one we started with
            Assert.IsTrue(newMatrix.Equals(matrix));

            Assert.AreEqual(-2.2, (double)newMatrix.GetElement(0, 0), 0.00001);
            Assert.AreEqual(16.8, (double)newMatrix.GetElement(4, 3), 0.00001);
        }
        #endregion

    }
}
