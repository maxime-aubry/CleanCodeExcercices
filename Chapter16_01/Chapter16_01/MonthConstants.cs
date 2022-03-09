/* ========================================================================
 * JCommon : a free general purpose class library for the Java(tm) platform
 * ========================================================================
 *
 * (C) Copyright 2000-2005, by Object Refinery Limited and Contributors.
 * 
 * Project Info:  http://www.jfree.org/jcommon/index.html
 *
 * This library is free software; you can redistribute it and/or modify it 
 * under the terms of the GNU Lesser General Public License as published by 
 * the Free Software Foundation; either version 2.1 of the License, or 
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
 * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, 
 * USA.  
 *
 * [Java is a trademark or registered trademark of Sun Microsystems, Inc. 
 * in the United States and other countries.]
 *
 * -------------------
 * MonthConstants.java
 * -------------------
 * (C) Copyright 2002, 2003, by Object Refinery Limited.
 *
 * Original Author:  David Gilbert (for Object Refinery Limited);
 * Contributor(s):   -;
 *
 * $Id: MonthConstants.java,v 1.4 2005/11/16 15:58:40 taqua Exp $
 *
 * Changes
 * -------
 * 29-May-2002 : Version 1 (code moved from SerialDate class) (DG);
 *
 */

/**
 * Useful constants for months.  Note that these are NOT equivalent to the
 * constants defined by java.util.Calendar (where JANUARY=0 and DECEMBER=11).
 * <P>
 * Used by the SerialDate and RegularTimePeriod classes.
 *
 * @author David Gilbert
 */
namespace Chapter16_01
{
    public class MonthConstants
    {
        /** Constant for January. */
        public const int JANUARY = 1;

        /** Constant for February. */
        public const int FEBRUARY = 2;

        /** Constant for March. */
        public const int MARCH = 3;

        /** Constant for April. */
        public const int APRIL = 4;

        /** Constant for May. */
        public const int MAY = 5;

        /** Constant for June. */
        public const int JUNE = 6;

        /** Constant for July. */
        public const int JULY = 7;

        /** Constant for August. */
        public const int AUGUST = 8;

        /** Constant for September. */
        public const int SEPTEMBER = 9;

        /** Constant for October. */
        public const int OCTOBER = 10;

        /** Constant for November. */
        public const int NOVEMBER = 11;

        /** Constant for December. */
        public const int DECEMBER = 12;
    }
}
