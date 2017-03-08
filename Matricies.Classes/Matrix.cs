using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Matricies.Classes.MathematicalHelper;

namespace Matricies.Classes
{
    public class Matrix2D
    {
        #region Properties

        private int _Height;

        private int _Width;

        private bool _IsSquare;


        /// <summary>
        /// Encapsulated array to store matrix. Elements accessed at InternalArray[y,x] for coordinates (x,y) to give mroe intative definitons.
        /// </summary>
        private decimal[,] InternalArray { get; set; }

        public int Width
        {
            get
            {
                return _Width;
            }
            private set
            {
                _IsSquare = value == _Height;
                _Width = value;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }
            private set
            {
                _IsSquare = value == _Width;
                _Height = value;
            }
        }

        public bool IsSquare
        {
            get
            {
                return _IsSquare;
            }
        }

        #endregion Properties

        #region Constructors
        public Matrix2D(int width, int height)
        {
            Height = height;
            Width = width;
            InternalArray = new decimal[width, height];
        }

        public Matrix2D(decimal[,] matrix)
        {
            Height = matrix.GetLength(1);
            Width = matrix.GetLength(0);
            InternalArray = matrix;
        }
        #endregion
        
        #region Methods
        public decimal GetElement(int x, int y)
        {
            ValidateRange(x, y);
            return InternalArray[y, x];
        }

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

        public decimal SetElement(int x, int y, decimal value)
        {
            ValidateRange(x, y);
            return InternalArray[y, x] = value;
        }

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

        public Matrix2D Submatrix(int startx, int starty)
        {
            ValidateRange(startx, starty);
            return GetSubMatrix(startx, starty, Width, Height);
        }

        private Matrix2D GetSubMatrix(int startx, int starty, int endx, int endy)
        {

            var subMatrixArray = new decimal[endx - startx, endy - starty];
            for (int x = 0; x < endx - startx; x++)
            {
                for (int y = 0; y < endy - starty; y++)
                {
                    subMatrixArray[x, y] = InternalArray[startx + x, starty + y];
                }
            }
            return new Matrix2D(subMatrixArray);
        }

        public Matrix2D Submatrix(int startx, int starty, int endx, int endy)
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

        public decimal Determinant()
        {
            if (!IsSquare)
            {
                throw new ArgumentException("Determinant is only defined for square matricies");
            }
            return GetDeterminantRecursively(this);
        }

        private decimal GetDeterminantRecursively(Matrix2D matrix)
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

        //Need to replace this with a triagnularise function then calculate the determinant with the product of the diangonal elements
        /// <summary>
        /// Moves along the top row returning a submatrix without the top row and column we are considering
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="elementy"></param>
        /// <returns></returns>
        private Matrix2D GetDeterminantSubmatricies(Matrix2D matrix, int elementx)
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
            return new Matrix2D(subMatrixArray);
        }

        #endregion

        #region Operator Definitions

        private static void ElementWiseOperation(decimal left, Matrix2D right, Func<decimal, decimal, decimal> operation)
        {
            for (int x = 0; x < right.Width; x++)
            {
                for (int y = 0; y < right.Height; y++)
                {
                    right.InternalArray[x, y] = operation(right.InternalArray[x, y], left);
                }
            }
        }

        public static Matrix2D operator *(Matrix2D left, Matrix2D right)
        {
            if (left.Width != right.Height)
            {
                throw new ArgumentException("A matrix of width " + left.Width + " only has a product defined for a matricies of height " + left.Width);
            }
            return left;
        }

        //Symteric operations need overloads for type1 ~ matrix as well as matrix ~ type1 (where ~ is an arbitary operator)
        #region Symetric Operators (Given an abritary operator ~ then a~b ==> b~a)
        public static Matrix2D operator *(Matrix2D left, decimal right)
        {
            return right * left;
        }

        public static Matrix2D operator *(decimal left, Matrix2D right)
        {
            ElementWiseOperation(left, right, Multiply);
            return right;
        }

        public static Matrix2D operator +(decimal left, Matrix2D right)
        {
            ElementWiseOperation(left, right, Add);
            return right;
        }

        public static Matrix2D operator +(Matrix2D left, decimal right)
        {

            return right + left;
        }

        public static Matrix2D operator *(Matrix2D left, double right)
        {
            return right * left;
        }

        public static Matrix2D operator *(double left, Matrix2D right)
        {
            return (decimal)left*right;
        }

        public static Matrix2D operator +(double left, Matrix2D right)
        {
            return(decimal)left + right;
        }

        public static Matrix2D operator +(Matrix2D left, double right)
        {

            return right + left;
        }

        public static Matrix2D operator *(Matrix2D left, int right)
        {
            return right * left;
        }

        public static Matrix2D operator *(int left, Matrix2D right)
        {
            return (decimal)left * right;
        }

        public static Matrix2D operator +(int left, Matrix2D right)
        {
            return (decimal)left + right;
        }

        public static Matrix2D operator +(Matrix2D left, int right)
        {

            return right+left;
        }
        #endregion

        //Non symetirc operations only need overloads for either type1 ~ matrix OR matrix ~ type1 (where ~ is an arbitary operator)
        //This is becuase 5 - matrix makes no sense but matrix - 5 does
        #region Symetric Operators (Given an abritary operator ~ then a~b =/=> b~a)
        public static Matrix2D operator -(Matrix2D left, decimal right)
        {
            ElementWiseOperation(right, left, Substract);
            return left;
        }

        public static Matrix2D operator -(Matrix2D left, double right)
        {
            return left - (decimal)right;
        }

        public static Matrix2D operator -(Matrix2D left, int right)
        {
            return left - (decimal)right;
        }

        public static Matrix2D operator /(Matrix2D left, decimal right)
        {
            ElementWiseOperation(right, left, Divide);
            return left;
        }

        public static Matrix2D operator /(Matrix2D left, double right)
        {
            return left / (decimal)right;
        }

        public static Matrix2D operator /(Matrix2D left, int right)
        {
            return left / (decimal)right;
        }

        #endregion

        #endregion
    }
}
