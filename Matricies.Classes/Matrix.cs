using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Matricies.Classes.MathematicalHelper;

namespace Matricies.Classes
{
    public class Matrix
    {
        #region Properties

        private int _Height;

        private int _Width;

        private bool _IsSquare;


        /// <summary>
        /// Encapsulated array to store matrix. Elements accessed at InternalArray[y,x] for coordinates (x,y) to give more intative definitons.
        /// </summary>
        private decimal[,] InternalArray { get; set; }

        /// <summary>
        /// Width of the matrix
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }
            private set
            {
                //Check when this value changes weater the matrix is square and update this value
                _IsSquare = value == _Height;
                _Width = value;
            }
        }
        
        /// <summary>
        /// Height fo the matrix
        /// </summary>
        public int Height
        {
            get
            {
                return _Height;
            }
            private set
            {
                //Check when this value changes weater the matrix is square and update this value
                _IsSquare = value == _Width;
                _Height = value;
            }
        }

        /// <summary>
        /// Is the matrix square 
        /// </summary>
        public bool IsSquare
        {
            get
            {
                return _IsSquare;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Instatiates a matrix of all 0's
        /// </summary>
        /// <param name="width">With of matrix to generate</param>
        /// <param name="height">Height of matrix to generate</param>
        public Matrix(int width, int height)
        {
            Height = height;
            Width = width;
            InternalArray = new decimal[width, height];
        }

        /// <summary>
        /// Pass a 2d array to map to a new matrix
        /// </summary>
        /// <param name="matrix">Array to become matrix</param>
        public Matrix(decimal[,] matrix)
        {
            Height = matrix.GetLength(1);
            Width = matrix.GetLength(0);
            InternalArray = matrix;
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Returns the element at coorinate (x,y). Zero indexed.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns></returns>
        public decimal GetElement(int x, int y)
        {
            ValidateRange(x, y);
            return InternalArray[y, x];
        }

        /// <summary>
        /// Ensures the values of x and y passed in are not out of bounds
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ValidateRange(int x, int y)
        {
            if (x > Width)
            {
                throw new ArgumentOutOfRangeException("Atempted to access element outside of x bound of Matrix");
            }
            else if (y > Height)
            {
                throw new ArgumentOutOfRangeException("Atempted to access element outside of y bound of Matrix");
            }
        }

        /// <summary>
        /// Set the element of the matrix at coordinate (x,y)
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="value">new value</param>
        /// <returns></returns>
        public decimal SetElement(int x, int y, decimal value)
        {
            ValidateRange(x, y);
            return InternalArray[y, x] = value;
        }

        /// <summary>
        /// Test the determinant and squareness of the matrix to discover if it is invertable
        /// </summary>
        /// <returns></returns>
        public bool IsInveritible()
        {
            if (!IsSquare)
            {
                return false;
            }
            else {
                bool determinantNonZero = Determinant() != 0;
                return IsSquare && determinantNonZero;
            }
        }

        /// <summary>
        /// Returns a section of the matrix as a new matrix. Assumes until end.
        /// </summary>
        /// <param name="startx">The x coordinate to start at</param>
        /// <param name="starty">The y coordinate to sart at</param>
        /// <returns></returns>
        public Matrix Submatrix(int startx, int starty)
        {
            ValidateRange(startx, starty);
            return GetSubMatrix(startx, starty, Width, Height);
        }

        /// <summary>
        /// Retuns a section of the matrix with specified coordinates
        /// </summary>
        /// <param name="startx">The x coordinate to start at</param>
        /// <param name="starty">The y coordinate to start at</param>
        /// <param name="endx">The x coordinate to end at</param>
        /// <param name="endy">The y coordinate to end at</param>
        /// <returns></returns>
        private Matrix GetSubMatrix(int startx, int starty, int endx, int endy)
        {

            var subMatrixArray = new decimal[endx - startx, endy - starty];
            for (int x = 0; x < endx - startx; x++)
            {
                for (int y = 0; y < endy - starty; y++)
                {
                    subMatrixArray[x, y] = InternalArray[startx + x, starty + y];
                }
            }
            return new Matrix(subMatrixArray);
        }

        /// <summary>
        /// Retuns a section of the matrix with specified coordinates
        /// </summary>
        /// <param name="startx">The x coordinate to start at</param>
        /// <param name="starty">The y coordinate to start at</param>
        /// <param name="endx">The x coordinate to end at</param>
        /// <param name="endy">The y coordinate to end at</param>
        /// <returns></returns>
        public Matrix Submatrix(int startx, int starty, int endx, int endy)
        {
            //Check argumetns provided are of correct form
            ValidateRange(startx, starty);
            ValidateRange(endx, endy);
            if (startx > endx || starty > endy)
            {
                throw new ArgumentException("The end range must be greater than the start range");
            }
            return GetSubMatrix(startx, starty, endx, endy);
        }


        /// <summary>
        /// Calculates the derminant of a square matrix
        /// </summary>
        /// <returns></returns>
        public decimal Determinant()
        {
            if (!IsSquare)
            {
                throw new ArgumentException("Determinant is only defined for square matricies");
            }
            return GetDeterminantRecursively(this);
        }

        /// <summary>
        /// Recursive method to reduce the size of the matrix until of width 2 where the determinant is known
        /// </summary>
        /// <param name="matrix">Matrix of the determinant to be found</param>
        /// <returns></returns>
        private decimal GetDeterminantRecursively(Matrix matrix)
        {
            //It is a given that it is square at this point. Only check width
            if (matrix.Width == 2)
            {
                // If 2 by 2 then we can easily and quickly calculate the determinant and return this
                return matrix.GetElement(0, 0) * matrix.GetElement(1, 1) - matrix.GetElement(1, 0) * matrix.GetElement(0, 1);
            }
            else
            {
                decimal runningTotal = 0;
                //Strip out the sub matricies and call again with smaller matricies
                for (int x = 0; x < matrix.Width; x++)
                {
                    var submatrixForDeterminant = GetDeterminantSubmatricies(matrix, x);
                    runningTotal += (decimal)Math.Pow(-1,x) * matrix.GetElement(x, 0) * GetDeterminantRecursively(submatrixForDeterminant);
                }
                return runningTotal;
            }         
        }

        /// <summary>
        /// Moves along the top row returning a submatrix without the top row and column we are considering
        /// </summary>
        /// <param name="matrix">Matrix to get determinant submatrix from</param>
        /// <param name="elementy">y column to exlude from new matrix</param>
        /// <returns></returns>
        private Matrix GetDeterminantSubmatricies(Matrix matrix, int elementx)
        {
            var subMatrixArray = new decimal[matrix.Width - 1, matrix.Height - 1];
            for (int x = 0; x < elementx; x++)
            {
                for (int y = 1; y < matrix.Height; y++)
                {
                    subMatrixArray[y -1, x] = matrix.GetElement(x, y);
                }
            }

            for (int x = elementx + 1; x < matrix.Width; x++)
            {
                for (int y = 1; y < matrix.Height; y++)
                {
                    subMatrixArray[y - 1, x - 1] = matrix.GetElement(x, y);
                }
            }
            return new Matrix(subMatrixArray);
        }

        #endregion

        
        //Basic mathematical operations are different for matricies, so overload the operators to give correct funcationality

        #region Operator Definitions

        /// <summary>
        /// Performs the opperation on all elements in a matrix
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operation"></param>
        private static void ElementWiseOperation(decimal left, Matrix right, Func<decimal, decimal, decimal> operation)
        {
            for (int x = 0; x < right.Width; x++)
            {
                for (int y = 0; y < right.Height; y++)
                {
                    right.InternalArray[x, y] = operation(right.InternalArray[x, y], left);
                }
            }
        }

        /// <summary>
        /// Performs multiplication between matricies
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Width != right.Height)
            {
                throw new ArgumentException("A matrix of width " + left.Width + " only has a product defined for a matricies of height " + left.Width);
            }
            return left;
        }

        //Symteric operations need overloads for type1 ~ matrix as well as matrix ~ type1 (where ~ is an arbitary operator)
        #region Symetric Operators (Given an abritary operator ~ then a~b ==> b~a)
        #region Multiplication
        public static Matrix operator *(Matrix left, decimal right)
        {
            return right * left;
        }

        public static Matrix operator *(Matrix left, int right)
        {
            return right * left;
        }

        public static Matrix operator *(int left, Matrix right)
        {
            return (decimal)left * right;
        }

        public static Matrix operator *(decimal left, Matrix right)
        {
            ElementWiseOperation(left, right, Multiply);
            return right;
        }

        public static Matrix operator *(Matrix left, double right)
        {
            return right * left;
        }

        public static Matrix operator *(double left, Matrix right)
        {
            return (decimal)left * right;
        }
        #endregion

        #region Addition

        public static Matrix operator +(decimal left, Matrix right)
        {
            ElementWiseOperation(left, right, Add);
            return right;
        }

        public static Matrix operator +(Matrix left, decimal right)
        {

            return right + left;
        }

        public static Matrix operator +(double left, Matrix right)
        {
            return (decimal)left + right;
        }

        public static Matrix operator +(Matrix left, double right)
        {

            return right + left;
        }

        public static Matrix operator +(int left, Matrix right)
        {
            return (decimal)left + right;
        }

        public static Matrix operator +(Matrix left, int right)
        {

            return right + left;
        }
        #endregion
        #endregion

        //Non symetirc operations only need overloads for either type1 ~ matrix OR matrix ~ type1 (where ~ is an arbitary operator)
        //This is becuase 5 - matrix makes no sense but matrix - 5 does
        #region Symetric Operators (Given an abritary operator ~ then a~b =/=> b~a)

        #region Subtraction
        public static Matrix operator -(Matrix left, decimal right)
        {
            ElementWiseOperation(right, left, Substract);
            return left;
        }

        public static Matrix operator -(Matrix left, double right)
        {
            return left - (decimal)right;
        }

        public static Matrix operator -(Matrix left, int right)
        {
            return left - (decimal)right;
        }
        #endregion

        #region Division
        public static Matrix operator /(Matrix left, decimal right)
        {
            ElementWiseOperation(right, left, Divide);
            return left;
        }

        public static Matrix operator /(Matrix left, double right)
        {
            return left / (decimal)right;
        }

        public static Matrix operator /(Matrix left, int right)
        {
            return left / (decimal)right;
        } 
        #endregion
        #endregion

        #endregion
    }
}
