using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuMVC
{
    /* NOTES:
     * textbox cell mapping from old program: txt10 is COL 1, ROW 0.  I don't know why I did it that way, but I did.
     * The general idea is to count from top left to bottom right.
     */

    public class SudokuSolver
    {
        private string strUnsolvedPuzzle = "";
        private string strSolvedPuzzle = "";

        public SudokoGrid sGrid = null;

        public SudokuSolver(string strInitialPuzzle)
        {
            strUnsolvedPuzzle = strInitialPuzzle;
            strSolvedPuzzle = strInitialPuzzle;
        }

        public string SolvePuzzle()
        {
            string[, ,] Grid = new string[9, 3, 3];
            int i, j, k = 0;
            int i2 = 0;
            int intLoopCnt = 0;
            string strRetCell = "";
            string strRetCol = "";
            string strRetRow = "";
            int intStuckCnt = 0;
            bool boolCell = false;
            bool boolRow = false;
            bool boolCol = false;

            #region Load Grid
            Grid[0, 0, 0] = strUnsolvedPuzzle.Substring(0, 1);
            Grid[0, 1, 0] = strUnsolvedPuzzle.Substring(1, 1);
            Grid[0, 2, 0] = strUnsolvedPuzzle.Substring(2, 1);
            Grid[0, 0, 1] = strUnsolvedPuzzle.Substring(9, 1);
            Grid[0, 1, 1] = strUnsolvedPuzzle.Substring(10, 1);
            Grid[0, 2, 1] = strUnsolvedPuzzle.Substring(11, 1);
            Grid[0, 0, 2] = strUnsolvedPuzzle.Substring(18, 1);
            Grid[0, 1, 2] = strUnsolvedPuzzle.Substring(19, 1);
            Grid[0, 2, 2] = strUnsolvedPuzzle.Substring(20, 1);

            Grid[1, 0, 0] = strUnsolvedPuzzle.Substring(3, 1);
            Grid[1, 1, 0] = strUnsolvedPuzzle.Substring(4, 1);
            Grid[1, 2, 0] = strUnsolvedPuzzle.Substring(5, 1);
            Grid[1, 0, 1] = strUnsolvedPuzzle.Substring(12, 1);
            Grid[1, 1, 1] = strUnsolvedPuzzle.Substring(13, 1);
            Grid[1, 2, 1] = strUnsolvedPuzzle.Substring(14, 1);
            Grid[1, 0, 2] = strUnsolvedPuzzle.Substring(21, 1);
            Grid[1, 1, 2] = strUnsolvedPuzzle.Substring(22, 1);
            Grid[1, 2, 2] = strUnsolvedPuzzle.Substring(23, 1);

            Grid[2, 0, 0] = strUnsolvedPuzzle.Substring(6, 1);
            Grid[2, 1, 0] = strUnsolvedPuzzle.Substring(7, 1);
            Grid[2, 2, 0] = strUnsolvedPuzzle.Substring(8, 1);
            Grid[2, 0, 1] = strUnsolvedPuzzle.Substring(15, 1);
            Grid[2, 1, 1] = strUnsolvedPuzzle.Substring(16, 1);
            Grid[2, 2, 1] = strUnsolvedPuzzle.Substring(17, 1);
            Grid[2, 0, 2] = strUnsolvedPuzzle.Substring(24, 1);
            Grid[2, 1, 2] = strUnsolvedPuzzle.Substring(25, 1);
            Grid[2, 2, 2] = strUnsolvedPuzzle.Substring(26, 1);

            Grid[3, 0, 0] = strUnsolvedPuzzle.Substring(27, 1);
            Grid[3, 1, 0] = strUnsolvedPuzzle.Substring(28, 1);
            Grid[3, 2, 0] = strUnsolvedPuzzle.Substring(29, 1);
            Grid[3, 0, 1] = strUnsolvedPuzzle.Substring(36, 1);
            Grid[3, 1, 1] = strUnsolvedPuzzle.Substring(37, 1);
            Grid[3, 2, 1] = strUnsolvedPuzzle.Substring(38, 1);
            Grid[3, 0, 2] = strUnsolvedPuzzle.Substring(45, 1);
            Grid[3, 1, 2] = strUnsolvedPuzzle.Substring(46, 1);
            Grid[3, 2, 2] = strUnsolvedPuzzle.Substring(47, 1);

            Grid[4, 0, 0] = strUnsolvedPuzzle.Substring(30, 1);
            Grid[4, 1, 0] = strUnsolvedPuzzle.Substring(31, 1);
            Grid[4, 2, 0] = strUnsolvedPuzzle.Substring(32, 1);
            Grid[4, 0, 1] = strUnsolvedPuzzle.Substring(39, 1);
            Grid[4, 1, 1] = strUnsolvedPuzzle.Substring(40, 1);
            Grid[4, 2, 1] = strUnsolvedPuzzle.Substring(41, 1);
            Grid[4, 0, 2] = strUnsolvedPuzzle.Substring(48, 1);
            Grid[4, 1, 2] = strUnsolvedPuzzle.Substring(49, 1);
            Grid[4, 2, 2] = strUnsolvedPuzzle.Substring(50, 1);

            Grid[5, 0, 0] = strUnsolvedPuzzle.Substring(33, 1);
            Grid[5, 1, 0] = strUnsolvedPuzzle.Substring(34, 1);
            Grid[5, 2, 0] = strUnsolvedPuzzle.Substring(35, 1);
            Grid[5, 0, 1] = strUnsolvedPuzzle.Substring(42, 1);
            Grid[5, 1, 1] = strUnsolvedPuzzle.Substring(43, 1);
            Grid[5, 2, 1] = strUnsolvedPuzzle.Substring(44, 1);
            Grid[5, 0, 2] = strUnsolvedPuzzle.Substring(51, 1);
            Grid[5, 1, 2] = strUnsolvedPuzzle.Substring(52, 1);
            Grid[5, 2, 2] = strUnsolvedPuzzle.Substring(53, 1);

            Grid[6, 0, 0] = strUnsolvedPuzzle.Substring(54, 1);
            Grid[6, 1, 0] = strUnsolvedPuzzle.Substring(55, 1);
            Grid[6, 2, 0] = strUnsolvedPuzzle.Substring(56, 1);
            Grid[6, 0, 1] = strUnsolvedPuzzle.Substring(63, 1);
            Grid[6, 1, 1] = strUnsolvedPuzzle.Substring(64, 1);
            Grid[6, 2, 1] = strUnsolvedPuzzle.Substring(65, 1);
            Grid[6, 0, 2] = strUnsolvedPuzzle.Substring(72, 1);
            Grid[6, 1, 2] = strUnsolvedPuzzle.Substring(73, 1);
            Grid[6, 2, 2] = strUnsolvedPuzzle.Substring(74, 1);

            Grid[7, 0, 0] = strUnsolvedPuzzle.Substring(57, 1);
            Grid[7, 1, 0] = strUnsolvedPuzzle.Substring(58, 1);
            Grid[7, 2, 0] = strUnsolvedPuzzle.Substring(59, 1);
            Grid[7, 0, 1] = strUnsolvedPuzzle.Substring(66, 1);
            Grid[7, 1, 1] = strUnsolvedPuzzle.Substring(67, 1);
            Grid[7, 2, 1] = strUnsolvedPuzzle.Substring(68, 1);
            Grid[7, 0, 2] = strUnsolvedPuzzle.Substring(75, 1);
            Grid[7, 1, 2] = strUnsolvedPuzzle.Substring(76, 1);
            Grid[7, 2, 2] = strUnsolvedPuzzle.Substring(77, 1);

            Grid[8, 0, 0] = strUnsolvedPuzzle.Substring(60, 1);
            Grid[8, 1, 0] = strUnsolvedPuzzle.Substring(61, 1);
            Grid[8, 2, 0] = strUnsolvedPuzzle.Substring(62, 1);
            Grid[8, 0, 1] = strUnsolvedPuzzle.Substring(69, 1);
            Grid[8, 1, 1] = strUnsolvedPuzzle.Substring(70, 1);
            Grid[8, 2, 1] = strUnsolvedPuzzle.Substring(71, 1);
            Grid[8, 0, 2] = strUnsolvedPuzzle.Substring(78, 1);
            Grid[8, 1, 2] = strUnsolvedPuzzle.Substring(79, 1);
            Grid[8, 2, 2] = strUnsolvedPuzzle.Substring(80, 1);
            #endregion

            //LOAD INITIAL PUZZLE
            sGrid = new SudokoGrid(Grid);

            while (!sGrid.Solved())
            {
                intLoopCnt++;
                boolCell = true;
                boolRow = true;
                boolCol = true;

                //LOOK FOR A NUMBER
                for (i = 0; i < 9; i++)
                {
                    strRetCell = CheckCell(sGrid.GetCell(i));
                    if (strRetCell != "0")
                    {
                        boolCell = false;
                    }
                }

                for (i = 0; i < 9; i++)
                {
                    strRetRow = CheckRow(sGrid.GetRow(i));
                    if (strRetRow != "0")
                    {
                        boolRow = false;
                    }
                }

                for (i = 0; i < 9; i++)
                {
                    strRetCol = CheckCol(sGrid.GetCol(i));
                    if (strRetCol != "0")
                    {
                        boolCol = false;
                    }
                }

                if (boolCell && boolRow && boolCol && intStuckCnt > 3) //WERE STUCK
                {
                    break;
                }
                else
                {
                    intStuckCnt++;
                }
            }

            //FILL IN WHAT WE FOUND
            Grid = sGrid.GetPuzzle();

            char[] temp = strSolvedPuzzle.ToCharArray();
            int[] iCellBase = new int[] { 0, 3, 6, 27, 30, 33, 54, 57, 60 };

            for (i2 = 0; i2 < 9; i2++) //Cell
            {
                for (j = 0; j < 3; j++) //col - y
                {
                    for (k = 0; k < 3; k++) //row - x
                    {
                        //txtGrid[i2, k, j].Text = Grid[i2, k, j];
                        temp[iCellBase[i2] + k + (j * 9)] = Grid[i2, k, j][0];
                    }
                }
            }
            strSolvedPuzzle = new string(temp);

            return strSolvedPuzzle;
        }

        string CheckCell(SudokoCell sCell)
        {
            if (!sCell.HasAll9())
            {
                SudokoRow sr1 = null;
                SudokoRow sr2 = null;
                SudokoRow sr3 = null;
                SudokoCol sc1 = null;
                SudokoCol sc2 = null;
                SudokoCol sc3 = null;
                //Hashtable hashStickyTmp = null;
                int i, j, k = 0;

                switch (sCell.strNumber)
                {
                    case "0":
                        sr1 = sGrid.GetRow(0);
                        sr2 = sGrid.GetRow(1);
                        sr3 = sGrid.GetRow(2);

                        sc1 = sGrid.GetCol(0);
                        sc2 = sGrid.GetCol(1);
                        sc3 = sGrid.GetCol(2);
                        break;
                    case "1":
                        sr1 = sGrid.GetRow(0);
                        sr2 = sGrid.GetRow(1);
                        sr3 = sGrid.GetRow(2);

                        sc1 = sGrid.GetCol(3);
                        sc2 = sGrid.GetCol(4);
                        sc3 = sGrid.GetCol(5);
                        break;
                    case "2":
                        sr1 = sGrid.GetRow(0);
                        sr2 = sGrid.GetRow(1);
                        sr3 = sGrid.GetRow(2);

                        sc1 = sGrid.GetCol(6);
                        sc2 = sGrid.GetCol(7);
                        sc3 = sGrid.GetCol(8);
                        break;
                    case "3":
                        sr1 = sGrid.GetRow(3);
                        sr2 = sGrid.GetRow(4);
                        sr3 = sGrid.GetRow(5);

                        sc1 = sGrid.GetCol(0);
                        sc2 = sGrid.GetCol(1);
                        sc3 = sGrid.GetCol(2);
                        break;
                    case "4":
                        sr1 = sGrid.GetRow(3);
                        sr2 = sGrid.GetRow(4);
                        sr3 = sGrid.GetRow(5);

                        sc1 = sGrid.GetCol(3);
                        sc2 = sGrid.GetCol(4);
                        sc3 = sGrid.GetCol(5);
                        break;
                    case "5":
                        sr1 = sGrid.GetRow(3);
                        sr2 = sGrid.GetRow(4);
                        sr3 = sGrid.GetRow(5);

                        sc1 = sGrid.GetCol(6);
                        sc2 = sGrid.GetCol(7);
                        sc3 = sGrid.GetCol(8);
                        break;
                    case "6":
                        sr1 = sGrid.GetRow(6);
                        sr2 = sGrid.GetRow(7);
                        sr3 = sGrid.GetRow(8);

                        sc1 = sGrid.GetCol(0);
                        sc2 = sGrid.GetCol(1);
                        sc3 = sGrid.GetCol(2);
                        break;
                    case "7":
                        sr1 = sGrid.GetRow(6);
                        sr2 = sGrid.GetRow(7);
                        sr3 = sGrid.GetRow(8);

                        sc1 = sGrid.GetCol(3);
                        sc2 = sGrid.GetCol(4);
                        sc3 = sGrid.GetCol(5);
                        break;
                    case "8":
                        sr1 = sGrid.GetRow(6);
                        sr2 = sGrid.GetRow(7);
                        sr3 = sGrid.GetRow(8);

                        sc1 = sGrid.GetCol(6);
                        sc2 = sGrid.GetCol(7);
                        sc3 = sGrid.GetCol(8);
                        break;
                }

                SudokoCell sCellTemp = null;
                string strTmpNum = "";
                int cnt = 0;

                //CHECK NUMBERS
                for (i = 0; i < 9; i++)
                {
                    sCellTemp = new SudokoCell();
                    strTmpNum = (i + 1).ToString();
                    cnt = 0;

                    if (sCell.HasNumber(strTmpNum))
                    {
                        continue;
                    }

                    //MARK FILLED IN BOXES IN TMP CELL
                    for (j = 0; j < 3; j++) //col var
                    {
                        for (k = 0; k < 3; k++) //row var
                        {
                            if (sCell.GetNumber(k, j) != "" && sCell.GetNumber(k, j) != null && sCell.GetNumber(k, j) != "0")
                            {
                                sCellTemp.SetValue(k, j, "X");
                            }
                        }
                    }

                    //PUT CODE HERE TO HANDLE STICKY NUMBERS
                    //STICKY NUMBERS ARE NUMBERS WHERE YOU KNOW THEIR COL OR ROW, BUT NOT
                    //EXACT BOXES.  !!! CODE ENDED UP IN COL AND ROW CHECKS !!!
                    //APPLY STICKY

                    //END STICKY

                    //CHECK ROWS FOR NUMBER
                    if (sr1.HasNumber(strTmpNum))
                    {
                        sCellTemp.SetValue(0, 0, "X");
                        sCellTemp.SetValue(1, 0, "X");
                        sCellTemp.SetValue(2, 0, "X");
                    }

                    if (sr2.HasNumber(strTmpNum))
                    {
                        sCellTemp.SetValue(0, 1, "X");
                        sCellTemp.SetValue(1, 1, "X");
                        sCellTemp.SetValue(2, 1, "X");
                    }

                    if (sr3.HasNumber(strTmpNum))
                    {
                        sCellTemp.SetValue(0, 2, "X");
                        sCellTemp.SetValue(1, 2, "X");
                        sCellTemp.SetValue(2, 2, "X");
                    }

                    //CHECK COLS FOR NUMBER
                    if (sc1.HasNumber(strTmpNum))
                    //if (sc1.GetPosition(strTmpNum) != 0)
                    {
                        sCellTemp.SetValue(0, 0, "X");
                        sCellTemp.SetValue(0, 1, "X");
                        sCellTemp.SetValue(0, 2, "X");
                    }

                    if (sc2.HasNumber(strTmpNum))
                    //if (sc2.GetPosition(strTmpNum) != 0)
                    {
                        sCellTemp.SetValue(1, 0, "X");
                        sCellTemp.SetValue(1, 1, "X");
                        sCellTemp.SetValue(1, 2, "X");
                    }

                    if (sc3.HasNumber(strTmpNum))
                    //if (sc3.GetPosition(strTmpNum) != 0)
                    {
                        sCellTemp.SetValue(2, 0, "X");
                        sCellTemp.SetValue(2, 1, "X");
                        sCellTemp.SetValue(2, 2, "X");
                    }


                    //CHECK FOR HOW MANY EMPTY
                    for (j = 0; j < 3; j++) //col var
                    {
                        for (k = 0; k < 3; k++) //row var
                        {
                            //Grid[i, k, j] = txtGrid[i, k, j].Text;
                            if (sCellTemp.GetNumber(k, j) == "" || sCellTemp.GetNumber(k, j) == null)
                            {
                                cnt++;
                            }
                        }
                    }

                    //IF JUST 1 THEN FILL IN
                    if (cnt == 1)
                    {
                        for (j = 0; j < 3; j++) //col var
                        {
                            for (k = 0; k < 3; k++) //row var
                            {
                                //Grid[i, k, j] = txtGrid[i, k, j].Text;
                                if (sCellTemp.GetNumber(k, j) == "" || sCellTemp.GetNumber(k, j) == null)
                                {
                                    sGrid.SetCellValue(sCell, k, j, strTmpNum);
                                    return strTmpNum;
                                }
                            }
                        }
                    }
                }
            }

            return "0";
        }

        string CheckRow(SudokoRow sRow)
        {
            if (!sRow.HasAll9())
            {
                SudokoCell scTmp = null;
                SudokoRow sRowTemp = null;
                SudokoCol sc0 = sGrid.GetCol(0);
                SudokoCol sc1 = sGrid.GetCol(1);
                SudokoCol sc2 = sGrid.GetCol(2);
                SudokoCol sc3 = sGrid.GetCol(3);
                SudokoCol sc4 = sGrid.GetCol(4);
                SudokoCol sc5 = sGrid.GetCol(5);
                SudokoCol sc6 = sGrid.GetCol(6);
                SudokoCol sc7 = sGrid.GetCol(7);
                SudokoCol sc8 = sGrid.GetCol(8);
                int i, j, cnt = 0;
                string strTempNum = "";

                //CHECK FOR NUMBERS
                for (i = 0; i < 9; i++)
                {
                    sRowTemp = new SudokoRow();
                    strTempNum = (i + 1).ToString();
                    cnt = 0;

                    if (sRow.HasNumber(strTempNum))
                    {
                        continue;
                    }

                    for (j = 0; j < 9; j++)
                    {
                        if (sRow.GetNumber(j) != "" && sRow.GetNumber(j) != null && sRow.GetNumber(j) != "0")
                        {
                            sRowTemp.SetValue(j, "X");
                        }
                    }

                    //k = sRow.GetPosition(strTempNum);
                    //if (k != 0)
                    //{
                    //	sRowTemp.SetValue(k, "X");
                    //}

                    //if (sc0.HasNumber(strTempNum) && (sRow.GetNumber(0) == "" || sRow.GetNumber(0) == null))
                    if (sc0.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(0, "X");
                    }
                    //if (sc1.HasNumber(strTempNum) && (sRow.GetNumber(1) == "" || sRow.GetNumber(1) == ""))
                    if (sc1.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(1, "X");
                    }
                    //if (sc2.HasNumber(strTempNum) && (sRow.GetNumber(2) == "" || sRow.GetNumber(2) == ""))
                    if (sc2.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(2, "X");
                    }
                    //if (sc3.HasNumber(strTempNum) && (sRow.GetNumber(3) == "" || sRow.GetNumber(3) == ""))
                    if (sc3.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(3, "X");
                    }
                    //if (sc4.HasNumber(strTempNum) && (sRow.GetNumber(4) == "" || sRow.GetNumber(4) == ""))
                    if (sc4.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(4, "X");
                    }
                    //if (sc5.HasNumber(strTempNum) && (sRow.GetNumber(5) == "" || sRow.GetNumber(5) == ""))
                    if (sc5.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(5, "X");
                    }
                    //if (sc6.HasNumber(strTempNum) && (sRow.GetNumber(6) == "" || sRow.GetNumber(6) == ""))
                    if (sc6.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(6, "X");
                    }
                    //if (sc7.HasNumber(strTempNum) && (sRow.GetNumber(7) == "" || sRow.GetNumber(7) == ""))
                    if (sc7.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(7, "X");
                    }
                    //if (sc8.HasNumber(strTempNum) && (sRow.GetNumber(8) == "" || sRow.GetNumber(8) == ""))
                    if (sc8.HasNumber(strTempNum))
                    {
                        sRowTemp.SetValue(8, "X");
                    }

                    //PUT CODE HERE TO CHECK IF A CELL HAS A NUMBER
                    switch (sRow.intNumber)
                    {
                        case 0:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 1:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 2:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 3:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 4:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 5:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 6:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 7:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 8:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sRowTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    for (j = 0; j < 9; j++)
                    {
                        if (sRowTemp.GetNumber(j) == "" || sRowTemp.GetNumber(j) == null)
                        {
                            cnt++;
                        }
                    }

                    if (cnt == 1)
                    {
                        for (j = 0; j < 9; j++)
                        {
                            if (sRowTemp.GetNumber(j) == "" || sRowTemp.GetNumber(j) == null)
                            {
                                //sRow.SetValue(i, strTempNum);
                                if (sRow.HasNumberInSticky(strTempNum))
                                {
                                    sRow.UpdateSticky("dv", i, strTempNum);
                                }
                                sGrid.SetRowValue(sRow, j, strTempNum);
                                return strTempNum;
                            }
                        }
                    }
                }

                //IF WE MADE IT HERE THAN WE HAVE MORE THAN 1 SPOT OPEN
                //FIRST IDENTIFY WHAT WERE MISSING
                string strMissing = "";
                for (j = 0; j < 9; j++)
                {
                    strTempNum = (j + 1).ToString();
                    if (!sRow.HasNumber(strTempNum))
                    {
                        strMissing += strTempNum;
                    }
                }

                //CHECK EACH ROW.  IF A ROW HAS N-1 NUMMBERS THAN THIS EMPTY SPOT IS THE N-1 NUMBER
                string strMissingTmp = "";
                SudokoCol srTmp = null;

                for (i = 0; i < 9; i++) //FOR LOOP TO MOVE UP ROW POSISITIONS
                {
                    switch (sRow.intNumber)
                    {
                        case 0:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(2);
                            }

                            break;
                        case 1:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(2);
                            }

                            break;
                        case 2:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(2);
                            }

                            break;
                        case 3:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(5);
                            }

                            break;
                        case 4:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(5);
                            }

                            break;
                        case 5:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(5);
                            }

                            break;
                        case 6:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(6);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(7);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        case 7:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(6);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(7);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        case 8:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(6);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(7);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        default:
                            break;
                    }

                    switch (i)
                    {
                        case 0:
                            srTmp = sc0;
                            break;
                        case 1:
                            srTmp = sc1;
                            break;
                        case 2:
                            srTmp = sc2;
                            break;
                        case 3:
                            srTmp = sc3;
                            break;
                        case 4:
                            srTmp = sc4;
                            break;
                        case 5:
                            srTmp = sc5;
                            break;
                        case 6:
                            srTmp = sc6;
                            break;
                        case 7:
                            srTmp = sc7;
                            break;
                        case 8:
                            srTmp = sc8;
                            break;
                        default:
                            srTmp = null;
                            break;
                    }

                    if (sRow.GetNumber(i) == "" || sRow.GetNumber(i) == null)
                    {
                        strMissingTmp = strMissing;
                        for (j = 0; j < strMissing.Length; j++) //CHECK COL
                        {
                            if (srTmp.HasNumber(strMissing.Substring(j, 1)))
                            {
                                strMissingTmp = strMissingTmp.Replace(strMissing.Substring(j, 1), " "); //CLEAR NUMBER WITH A SPACE
                            }
                        }

                        for (j = 0; j < strMissing.Length; j++) //CHECK CELL
                        {
                            if (scTmp.HasNumber(strMissing.Substring(j, 1)) && strMissing.Substring(j, 1) != " ")
                            {
                                strMissingTmp = strMissingTmp.Replace(strMissing.Substring(j, 1), " "); //CLEAR NUMBER WITH A SPACE
                            }
                        }

                        if (strMissingTmp.Trim().Length == 1) //FOUND YOU
                        {
                            if (sRow.HasNumberInSticky(strMissingTmp.Trim()))
                            {
                                //sRow.UpdateSticky("dv", i, strMissingTmp.Trim());
                            }
                            sGrid.SetRowValue(sRow, i, strMissingTmp.Trim());
                            return strTempNum;
                        }
                        else
                        {
                            strMissingTmp = strMissingTmp.Replace(" ", "");
                            for (j = 0; j < strMissingTmp.Length; j++)
                            {
                                //if (sRow.HasNumberInSticky(strMissingTmp.Substring(j, 1)))
                                //{
                                //continue;
                                //}
                                //sRow.UpdateSticky("a", i, strMissingTmp.Substring(j, 1));
                            }
                        }
                    }
                }
            }

            return "0";
        }

        string CheckCol(SudokoCol sCol)
        {
            if (!sCol.HasAll9())
            {
                SudokoCell scTmp = null;
                SudokoCol sColTemp = null;
                SudokoRow sr0 = sGrid.GetRow(0);
                SudokoRow sr1 = sGrid.GetRow(1);
                SudokoRow sr2 = sGrid.GetRow(2);
                SudokoRow sr3 = sGrid.GetRow(3);
                SudokoRow sr4 = sGrid.GetRow(4);
                SudokoRow sr5 = sGrid.GetRow(5);
                SudokoRow sr6 = sGrid.GetRow(6);
                SudokoRow sr7 = sGrid.GetRow(7);
                SudokoRow sr8 = sGrid.GetRow(8);
                int i, j, cnt = 0;
                string strTempNum = "";

                //LOOK FOR NUMBERS
                for (i = 0; i < 9; i++)
                {
                    sColTemp = new SudokoCol();
                    strTempNum = (i + 1).ToString();
                    cnt = 0;


                    if (sCol.HasNumber(strTempNum))
                    {
                        continue;
                    }

                    for (j = 0; j < 9; j++)
                    {
                        if (sCol.GetNumber(j) != "" && sCol.GetNumber(j) != null && sCol.GetNumber(j) != "0")
                        {
                            sColTemp.SetValue(j, "X");
                        }
                    }


                    //k = sCol.GetPosition(strTempNum);
                    //if (k != 0)
                    //{
                    //sColTemp.SetValue(k, "X");
                    //}

                    //if (sr0.HasNumber(strTempNum) && (sCol.GetNumber(0) == "" || sCol.GetNumber(0) == null))
                    if (sr0.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(0, "X");
                    }
                    //if (sr1.HasNumber(strTempNum) && (sCol.GetNumber(1) == "" || sCol.GetNumber(1) == null))
                    if (sr1.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(1, "X");
                    }
                    //if (sr2.HasNumber(strTempNum) && (sCol.GetNumber(2) == "" || sCol.GetNumber(2) == null))
                    if (sr2.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(2, "X");
                    }
                    //if (sr3.HasNumber(strTempNum) && (sCol.GetNumber(3) == "" || sCol.GetNumber(3) == null))
                    if (sr3.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(3, "X");
                    }
                    //if (sr4.HasNumber(strTempNum) && (sCol.GetNumber(4) == "" || sCol.GetNumber(4) == null))
                    if (sr4.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(4, "X");
                    }
                    //if (sr5.HasNumber(strTempNum) && (sCol.GetNumber(5) == "" || sCol.GetNumber(5) == null))
                    if (sr5.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(5, "X");
                    }
                    //if (sr6.HasNumber(strTempNum) && (sCol.GetNumber(6) == "" || sCol.GetNumber(6) == null))
                    if (sr6.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(6, "X");
                    }
                    //if (sr7.HasNumber(strTempNum) && (sCol.GetNumber(7) == "" || sCol.GetNumber(7) == null))
                    if (sr7.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(7, "X");
                    }
                    //if (sr8.HasNumber(strTempNum) && (sCol.GetNumber(8) == "" || sCol.GetNumber(8) == null))
                    if (sr8.HasNumber(strTempNum))
                    {
                        sColTemp.SetValue(8, "X");
                    }

                    //PUT CODE HERE TO CHECK IF A CELL HAS A NUMBER

                    switch (sCol.intNumber)
                    {
                        case 0:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 1:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 2:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(0);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(3);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(6);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 3:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 4:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 5:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(1);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(4);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(7);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 6:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 7:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        case 8:
                            for (j = 0; j < 9; j++)
                            {
                                if (j >= 0 && j <= 2)
                                {
                                    scTmp = sGrid.GetCell(2);
                                }
                                if (j >= 3 && j <= 5)
                                {
                                    scTmp = sGrid.GetCell(5);
                                }
                                if (j >= 6 && j <= 8)
                                {
                                    scTmp = sGrid.GetCell(8);
                                }

                                if (scTmp.HasNumber(strTempNum))
                                {
                                    sColTemp.SetValue(j, "X");
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    for (j = 0; j < 9; j++)
                    {
                        if (sColTemp.GetNumber(j) == "" || sColTemp.GetNumber(j) == null)
                        {
                            cnt++;
                        }
                    }

                    if (cnt == 1)
                    {
                        for (j = 0; j < 9; j++)
                        {
                            if (sColTemp.GetNumber(j) == "" || sColTemp.GetNumber(j) == null)
                            {
                                sCol.SetValue(i, strTempNum);
                                //if (sCol.HasNumberInSticky(strTempNum))
                                //{
                                //sCol.UpdateSticky("dv", i, strTempNum);
                                //}
                                sGrid.SetColValue(sCol, j, strTempNum);
                                return strTempNum;
                            }
                        }
                    }
                }

                //IF WE MADE IT HERE THAN WE HAVE MORE THAN 1 SPOT OPEN
                //FIRST IDENTIFY WHAT WERE MISSING
                string strMissing = "";
                for (j = 0; j < 9; j++)
                {
                    strTempNum = (j + 1).ToString();
                    if (!sCol.HasNumber(strTempNum))
                    {
                        strMissing += strTempNum;
                    }
                }

                //CHECK EACH ROW.  IF A ROW HAS N-1 NUMMBERS THAN THIS EMPTY SPOT IS THE N-1 NUMBER
                string strMissingTmp = "";
                SudokoRow srTmp = null;

                for (i = 0; i < 9; i++) //FOR LOOP TO MOVE UP COL POSISITIONS
                {
                    switch (sCol.intNumber)
                    {
                        case 0:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(6);
                            }

                            break;
                        case 1:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(6);
                            }

                            break;
                        case 2:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(0);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(3);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(6);
                            }

                            break;
                        case 3:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(7);
                            }

                            break;
                        case 4:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(7);
                            }

                            break;
                        case 5:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(1);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(4);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(7);
                            }

                            break;
                        case 6:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(2);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(5);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        case 7:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(2);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(5);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        case 8:
                            if (i >= 0 && i <= 2)
                            {
                                scTmp = sGrid.GetCell(2);
                            }
                            if (i >= 3 && i <= 5)
                            {
                                scTmp = sGrid.GetCell(5);
                            }
                            if (i >= 6 && i <= 8)
                            {
                                scTmp = sGrid.GetCell(8);
                            }

                            break;
                        default:
                            break;
                    }

                    switch (i)
                    {
                        case 0:
                            srTmp = sr0;
                            break;
                        case 1:
                            srTmp = sr1;
                            break;
                        case 2:
                            srTmp = sr2;
                            break;
                        case 3:
                            srTmp = sr3;
                            break;
                        case 4:
                            srTmp = sr4;
                            break;
                        case 5:
                            srTmp = sr5;
                            break;
                        case 6:
                            srTmp = sr6;
                            break;
                        case 7:
                            srTmp = sr7;
                            break;
                        case 8:
                            srTmp = sr8;
                            break;
                        default:
                            srTmp = null;
                            break;
                    }

                    if (sCol.GetNumber(i) == "" || sCol.GetNumber(i) == null)
                    {
                        strMissingTmp = strMissing;
                        for (j = 0; j < strMissing.Length; j++) //CHECK ROW
                        {
                            if (srTmp.HasNumber(strMissing.Substring(j, 1)))
                            {
                                strMissingTmp = strMissingTmp.Replace(strMissing.Substring(j, 1), " "); //CLEAR NUMBER WITH A SPACE
                            }
                        }

                        for (j = 0; j < strMissing.Length; j++) //CHECK CELL
                        {
                            if (scTmp.HasNumber(strMissing.Substring(j, 1)) && strMissing.Substring(j, 1) != " ")
                            {
                                strMissingTmp = strMissingTmp.Replace(strMissing.Substring(j, 1), " "); //CLEAR NUMBER WITH A SPACE
                            }
                        }

                        if (strMissingTmp.Trim().Length == 1) //FOUND YOU
                        {
                            //if (sCol.HasNumberInSticky(strMissingTmp.Trim()))
                            //{
                            //sCol.UpdateSticky("dv", i, strMissingTmp.Trim());
                            //}
                            sGrid.SetColValue(sCol, i, strMissingTmp.Trim());
                            return strTempNum;
                        }
                        else
                        {
                            strMissingTmp = strMissingTmp.Replace(" ", "");
                            for (j = 0; j < strMissingTmp.Length; j++)
                            {
                                //if (sCol.HasNumberInSticky(strMissingTmp.Substring(j, 1)))
                                //{
                                //continue;
                                //}
                                //sCol.UpdateSticky("a", i, strMissingTmp.Substring(j, 1));
                            }
                        }
                    }
                } //END FOR
            }

            return "0";
        }

        bool GridSolved(string[, ,] tmpGrid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        //Grid[i, k, j] = txtGrid[i, k, j].Text;
                        if (tmpGrid[i, k, j] == "" || tmpGrid[i, k, j] == "0")
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}