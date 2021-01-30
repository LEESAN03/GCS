using System;
using System.Collections.Generic;
using System.Text;

namespace VIKGroundStation
{
    /// <summary>
    /// Simple representation of a x/y coordinate
    /// </summary>
    public class Point_1
    {
        private Double _x;
        private Double _y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="X">The X point.</param>
        /// <param name="Y">The Y point.</param>
        public Point_1(Double X, Double Y)
        {
            _x = X;
            _y = Y;
        }

        /// <summary>
        /// Gets or sets the X point.
        /// </summary>
        /// <value>The X point.</value>
        public Double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Gets or sets the Y point.
        /// </summary>
        /// <value>The Y point.</value>
        public Double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Point_1)
            {
                Point_1 p = (Point_1)obj;
                return _x == p._x && +_y == p._y;
            }
            else
                return false;
        }

    }
}
