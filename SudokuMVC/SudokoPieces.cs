/*
 * Created by SharpDevelop.
 * User: Jordan Lee
 * Date: 12/9/2006
 * Time: 9:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Specialized;

namespace SudokuMVC
{
	/// <summary>
	/// Description of SudokoPieces.
	/// </summary>
    
	public class SudokoGrid
	{
		private SudokoCell sc0 = null;
		private SudokoCell sc1 = null;
		private SudokoCell sc2 = null;
		private SudokoCell sc3 = null;
		private SudokoCell sc4 = null;
		private SudokoCell sc5 = null;
		private SudokoCell sc6 = null;
		private SudokoCell sc7 = null;
		private SudokoCell sc8 = null;
		
		private SudokoRow srow0 = null;
		private SudokoRow srow1 = null;
		private SudokoRow srow2 = null;
		private SudokoRow srow3 = null;
		private SudokoRow srow4 = null;
		private SudokoRow srow5 = null;
		private SudokoRow srow6 = null;
		private SudokoRow srow7 = null;
		private SudokoRow srow8 = null;
		
		private SudokoCol scol0 = null;
		private SudokoCol scol1 = null;
		private SudokoCol scol2 = null;
		private SudokoCol scol3 = null;
		private SudokoCol scol4 = null;
		private SudokoCol scol5 = null;
		private SudokoCol scol6 = null;
		private SudokoCol scol7 = null;
		private SudokoCol scol8 = null;
		
		public SudokoGrid(string[,,] strGrid)
		{
            string[,] strItems = null;
            int i, j, k = 0;

            for (i = 0; i < 9; i++)
            {
                strItems = new string[3, 3];
                for (j = 0; j < 3; j++)
                {
                    for (k = 0; k < 3; k++)
                    {
                        //strItems[k, j] = txtGrid[i, k, j].Text;
                        strItems[k, j] = strGrid[i, k, j];
                    }
                }

                switch (i)
                {
                    case 0:
                        sc0 = new SudokoCell(strItems, "0");
                        break;
                    case 1:
                        sc1 = new SudokoCell(strItems, "1");
                        break;
                    case 2:
                        sc2 = new SudokoCell(strItems, "2");
                        break;
                    case 3:
                        sc3 = new SudokoCell(strItems, "3");
                        break;
                    case 4:
                        sc4 = new SudokoCell(strItems, "4");
                        break;
                    case 5:
                        sc5 = new SudokoCell(strItems, "5");
                        break;
                    case 6:
                        sc6 = new SudokoCell(strItems, "6");
                        break;
                    case 7:
                        sc7 = new SudokoCell(strItems, "7");
                        break;
                    case 8:
                        sc8 = new SudokoCell(strItems, "8");
                        break;
                    default:
                        break;
                }
            }

            srow0 = new SudokoRow(sc0, sc1, sc2, 0, 0);
            srow1 = new SudokoRow(sc0, sc1, sc2, 1, 1);
            srow2 = new SudokoRow(sc0, sc1, sc2, 2, 2);
            srow3 = new SudokoRow(sc3, sc4, sc5, 0, 3);
            srow4 = new SudokoRow(sc3, sc4, sc5, 1, 4);
            srow5 = new SudokoRow(sc3, sc4, sc5, 2, 5);
            srow6 = new SudokoRow(sc6, sc7, sc8, 0, 6);
            srow7 = new SudokoRow(sc6, sc7, sc8, 1, 7);
            srow8 = new SudokoRow(sc6, sc7, sc8, 2, 8);

            scol0 = new SudokoCol(sc0, sc3, sc6, 0, 0);
            scol1 = new SudokoCol(sc0, sc3, sc6, 1, 1);
            scol2 = new SudokoCol(sc0, sc3, sc6, 2, 2);
            scol3 = new SudokoCol(sc1, sc4, sc7, 0, 3);
            scol4 = new SudokoCol(sc1, sc4, sc7, 1, 4);
            scol5 = new SudokoCol(sc1, sc4, sc7, 2, 5);
            scol6 = new SudokoCol(sc2, sc5, sc8, 0, 6);
            scol7 = new SudokoCol(sc2, sc5, sc8, 1, 7);
            scol8 = new SudokoCol(sc2, sc5, sc8, 2, 8);
		}
		
		public bool Solved()
		{
			bool boolRet = false;
			
			if (!sc0.HasAll9() || !sc1.HasAll9() || !sc2.HasAll9() || !sc3.HasAll9() || !sc4.HasAll9() || !sc5.HasAll9() || !sc6.HasAll9() || !sc7.HasAll9() || !sc8.HasAll9())
			{
				boolRet = false;
			}
			else
			{
				boolRet = true;
			}
			
			if (!srow0.HasAll9() || !srow1.HasAll9() || !srow2.HasAll9() || !srow3.HasAll9() || !srow4.HasAll9() || !srow5.HasAll9() || !srow6.HasAll9() || !srow7.HasAll9() || !srow8.HasAll9())
			{
				boolRet = false;
			}
			else
			{
				boolRet = true;
			}
			
			if (!scol0.HasAll9() || !scol1.HasAll9() || !scol2.HasAll9() || !scol3.HasAll9() || !scol4.HasAll9() || !scol5.HasAll9() || !scol6.HasAll9() || !scol7.HasAll9() || !scol8.HasAll9())
			{
				boolRet = false;
			}
			else
			{
				boolRet = true;
			}
			
			return boolRet;
		}
		
		public SudokoCell GetCell(int index)
		{
			SudokoCell scTmp = null;
			
			switch (index)
			{
				case 0:
					scTmp = sc0;
					break;
				case 1:
					scTmp = sc1;
					break;
				case 2:
					scTmp = sc2;
					break;
				case 3:
					scTmp = sc3;
					break;
				case 4:
					scTmp = sc4;
					break;
				case 5:
					scTmp = sc5;
					break;
				case 6:
					scTmp = sc6;
					break;
				case 7:
					scTmp = sc7;
					break;
				case 8:
					scTmp = sc8;
					break;
				default:
					scTmp = null;
					break;
			}
			
			return scTmp;
		}
		
		public SudokoRow GetRow(int index)
		{
			SudokoRow srowTmp = null;
			
			switch (index)
			{
				case 0:
					srowTmp = srow0;
					break;
				case 1:
					srowTmp = srow1;
					break;
				case 2:
					srowTmp = srow2;
					break;
				case 3:
					srowTmp = srow3;
					break;
				case 4:
					srowTmp = srow4;
					break;
				case 5:
					srowTmp = srow5;
					break;
				case 6:
					srowTmp = srow6;
					break;
				case 7:
					srowTmp = srow7;
					break;
				case 8:
					srowTmp = srow8;
					break;
				default:
					srowTmp = null;
					break;
			}
			
			return srowTmp;
		}
		
		public SudokoCol GetCol(int index)
		{
			SudokoCol scolTmp = null;
			
			switch (index)
			{
				case 0:
					scolTmp = scol0;
					break;
				case 1:
					scolTmp = scol1;
					break;
				case 2:
					scolTmp = scol2;
					break;
				case 3:
					scolTmp = scol3;
					break;
				case 4:
					scolTmp = scol4;
					break;
				case 5:
					scolTmp = scol5;
					break;
				case 6:
					scolTmp = scol6;
					break;
				case 7:
					scolTmp = scol7;
					break;
				case 8:
					scolTmp = scol8;
					break;
				default:
					scolTmp = null;
					break;
			}
			
			return scolTmp;
		}
		
		public void SetCellValue(SudokoCell sc, int row, int col, string strVal)
		{
			sc.SetValue(row, col, strVal);
			
			//System.Windows.Forms.MessageBox.Show("CELL NUM = " + sc.strNumber + ", ROW = " + row.ToString() + ", COL = " + col.ToString() + ", VAL = " + strVal);
			
			srow0 = new SudokoRow(sc0, sc1, sc2, 0, 0);
			srow1 = new SudokoRow(sc0, sc1, sc2, 1, 1);
			srow2 = new SudokoRow(sc0, sc1, sc2, 2, 2);
			srow3 = new SudokoRow(sc3, sc4, sc5, 0, 3);
			srow4 = new SudokoRow(sc3, sc4, sc5, 1, 4);
			srow5 = new SudokoRow(sc3, sc4, sc5, 2, 5);
			srow6 = new SudokoRow(sc6, sc7, sc8, 0, 6);
			srow7 = new SudokoRow(sc6, sc7, sc8, 1, 7);
			srow8 = new SudokoRow(sc6, sc7, sc8, 2, 8);
			
			scol0 = new SudokoCol(sc0, sc3, sc6, 0, 0);
			scol1 = new SudokoCol(sc0, sc3, sc6, 1, 1);
			scol2 = new SudokoCol(sc0, sc3, sc6, 2, 2);
			scol3 = new SudokoCol(sc1, sc4, sc7, 0, 3);
			scol4 = new SudokoCol(sc1, sc4, sc7, 1, 4);
			scol5 = new SudokoCol(sc1, sc4, sc7, 2, 5);
			scol6 = new SudokoCol(sc2, sc5, sc8, 0, 6);
			scol7 = new SudokoCol(sc2, sc5, sc8, 1, 7);
			scol8 = new SudokoCol(sc2, sc5, sc8, 2, 8);
		}
		
		public void SetRowValue(SudokoRow srow, int index, string strVal)
		{
			//srow.SetValue(index, strVal);
			SudokoCell scTmp = null;
			int col = 0;
			int row = 0;
			
			//System.Windows.Forms.MessageBox.Show("ROW NUM = " + srow.intNumber.ToString() + ", INDEX = " + index.ToString() + ", VAL = " + strVal);
			
			switch (srow.intNumber)
			{
				case 0:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = 0;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc1;
						col = 0;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc2;
						col = 0;
						row = index - 6;
					}
					break;
				case 1:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = 1;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc1;
						col = 1;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc2;
						col = 1;
						row = index - 6;
					}
					break;
				case 2:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = 2;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc1;
						col = 2;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc2;
						col = 2;
						row = index - 6;
					}
					break;
				case 3:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc3;
						col = 0;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = 0;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc5;
						col = 0;
						row = index - 6;
					}
					break;
				case 4:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc3;
						col = 1;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = 1;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc5;
						col = 1;
						row = index - 6;
					}
					break;
				case 5:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc3;
						col = 2;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = 2;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc5;
						col = 2;
						row = index - 6;
					}
					break;
				case 6:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc6;
						col = 0;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc7;
						col = 0;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = 0;
						row = index - 6;
					}
					break;
				case 7:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc6;
						col = 1;
						row = index;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc7;
						col = 1;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = 1;
						row = index - 6;
					}
					break;
				case 8:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc6;
						col = 2;
						row = index;
					}if (index >= 3 && index <= 5) 
					{
						scTmp = sc7;
						col = 2;
						row = index - 3;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = 2;
						row = index - 6;
					}
					break;
				default:
					break;
			}
			
			SetCellValue(scTmp, row, col, strVal);
		}
		
		public void SetColValue(SudokoCol scol, int index, string strVal)
		{
			//scol.SetValue(index, strVal);
			SudokoCell scTmp = null;
			int col = 0;
			int row = 0;
			
			//System.Windows.Forms.MessageBox.Show("COL NUM = " + scol.intNumber.ToString() + ", INDEX = " + index.ToString() + ", VAL = " + strVal);
			
			switch (scol.intNumber)
			{
				case 0:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = index;
						row = 0;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc3;
						col = index - 3;
						row = 0;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc6;
						col = index - 6;
						row = 0;
					}
					break;
				case 1:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = index;
						row = 1;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc3;
						col = index - 3;
						row = 1;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc6;
						col = index - 6;
						row = 1;
					}
					break;
				case 2:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc0;
						col = index;
						row = 2;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc3;
						col = index - 3;
						row = 2;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc6;
						col = index - 6;
						row = 2;
					}
					break;
				case 3:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc1;
						col = index;
						row = 0;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = index - 3;
						row = 0;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc7;
						col = index - 6;
						row = 0;
					}
					break;
				case 4:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc1;
						col = index;
						row = 1;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = index - 3;
						row = 1;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc7;
						col = index - 6;
						row = 1;
					}
					break;
				case 5:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc1;
						col = index;
						row = 2;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc4;
						col = index - 3;
						row = 2;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc7;
						col = index - 6;
						row = 2;
					}
					break;
				case 6:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc2;
						col = index;
						row = 0;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc5;
						col = index - 3;
						row = 0;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = index - 6;
						row = 0;
					}
					break;
				case 7:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc2;
						col = index;
						row = 1;
					}
					if (index >= 3 && index <= 5) 
					{
						scTmp = sc5;
						col = index - 3;
						row = 1;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = index - 6;
						row = 1;
					}
					break;
				case 8:
					if (index >= 0 && index <= 2) 
					{
						scTmp = sc2;
						col = index;
						row = 2;
					}if (index >= 3 && index <= 5) 
					{
						scTmp = sc5;
						col = index - 3;
						row = 2;
					}
					if (index >= 6 && index <= 8) 
					{
						scTmp = sc8;
						col = index - 6;
						row = 2;
					}
					break;
				default:
					break;
			}
			
			SetCellValue(scTmp, row, col, strVal);
		}
		
		public string[,,] GetPuzzle()
		{
			int i = 0;
			int j = 0;
			int k = 0;
			string[,,] Grid = new string[9, 3, 3];
			SudokoCell scTmp = null;
			
			for (i = 0; i < 9; i++)
			{
				switch (i)
				{
					case 0:
						scTmp = sc0;
						break;
					case 1:
						scTmp = sc1;
						break;
					case 2:
						scTmp = sc2;
						break;
					case 3:
						scTmp = sc3;
						break;
					case 4:
						scTmp = sc4;
						break;
					case 5:
						scTmp = sc5;
						break;
					case 6:
						scTmp = sc6;
						break;
					case 7:
						scTmp = sc7;
						break;
					case 8:
						scTmp = sc8;
						break;
					default:
						scTmp = null;
						break;
				}
				
				for (j = 0; j < 3; j++)
				{
					for (k = 0; k < 3; k++)
					{
						//Grid[i, k, j] = txtGrid[i, k, j].Text;
						Grid[i, k, j] = scTmp.GetNumber(k, j);
					}
				}
			}
			
			return Grid;
		}
	}
	
	public class SudokoCell
	{
		private string[,] strItems = new string[3,3];
		
		public string strNumber = "";
		
		public SudokoCell(string[,] strSrc, string strNum)
		{
			strItems = strSrc;
			strNumber = strNum;
		}
		
		public SudokoCell()
		{
			
		}
		
		public string[] GetRow(int index)
		{
			string[] strRow = new string[3];
			int i = 0;
			
			for (i = 0; i < 3; i++)
			{
				//strRow[i] = strItems[index, i];
				strRow[i] = strItems[i, index];
			}
			
			return strRow;
		}
		
		public string[] GetCol(int index)
		{
			string[] strCol = new string[3];
			int i = 0;
			
			for (i = 0; i < 3; i++)
			{
				//strCol[i] = strItems[i, index];
				strCol[i] = strItems[index, i];
			}
			
			return strCol;
		}
		
		public bool HasNumber(string strNum)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j ++)
				{
					if (strItems[j, i] == strNum)
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool HasAll9()
		{
			string[] strNums = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
			bool boolNumFound = false;
			
			for (int k = 0; k < 9; k++)
			{
				boolNumFound = false;
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j ++)
					{
						if (strItems[j, i] == strNums[k])
						{
							boolNumFound = true;
						}
					}
				}
				if (!boolNumFound)
				{
					return false;
				}
			}
			return true;
		}
		
		public void SetValue(int row, int col, string strVal)
		{
			strItems[row, col] = strVal;
		}
		
		public string GetNumber(int row, int col)
		{
			return strItems[row, col];
		}
		
		public string[,] GetPosition(string strNum)
		{
			string[,] strPos = new string[1, 1];
			
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j ++)
				{
					if (strItems[j, i] == strNum)
					{
						strPos[0,0] = strItems[j, i];
					}
				}
			}
			return strPos;
		}
		
		public int GetPositionX(string strNum)
		{
			int intPos = 0;
			
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j ++)
				{
					if (strItems[j, i] == strNum)
					{
						intPos = j;
					}
				}
			}
			return intPos;
		}
		
		public int GetPositionY(string strNum)
		{
			int intPos = 0;
			
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j ++)
				{
					if (strItems[j, i] == strNum)
					{
						intPos = i;
					}
				}
			}
			return intPos;
		}
	}
	
	public class SudokoRow
	{
		private string[] strRow = new string[9];
		private Hashtable hashStickyNums = new Hashtable();
		
		public int intNumber = 0;
		
		public SudokoRow(SudokoCell sc1, SudokoCell sc2, SudokoCell sc3, int index, int intNum)
		{
			string[] strTmp = null;
			
			strTmp = sc1.GetRow(index);
			strRow[0] = strTmp[0];
			strRow[1] = strTmp[1];
			strRow[2] = strTmp[2];
			
			strTmp = sc2.GetRow(index);
			strRow[3] = strTmp[0];
			strRow[4] = strTmp[1];
			strRow[5] = strTmp[2];
			
			strTmp = sc3.GetRow(index);
			strRow[6] = strTmp[0];
			strRow[7] = strTmp[1];
			strRow[8] = strTmp[2];
			
			intNumber = intNum;
		}
		
		public SudokoRow()
		{
			
		}
		
		public Hashtable GetSticky()
		{
			return hashStickyNums;
		}
		
		public void UpdateSticky(string strAction, int index, string strVal)
		{
			switch (strAction)
			{
				case "a":
					try
					{
						hashStickyNums.Remove(index);
					}
					catch (Exception)
					{
						//DO NOTHING - JUST MOVE ON
					}
					hashStickyNums.Add(index, strVal);
					break;
				case "di":
					hashStickyNums.Remove(index);
					break;
				case "dv":
					if (hashStickyNums.ContainsValue(strVal))
					{
						for (int i = 0; i < hashStickyNums.Keys.Count; i++)
						{
							if (hashStickyNums[i].ToString() == strVal)
							{
								hashStickyNums.Remove(i);
							}
						}
					}
					break;
				default:
					break;
			}
		}
		
		public bool HasNumberInSticky(string strNum)
		{
			bool boolRet = false;
			
			if (hashStickyNums.ContainsValue(strNum))
			{
				boolRet = true;
			}
			
			return boolRet;
		}
		
		public bool HasNumber(string strNum)
		{
			for (int i = 0; i < 9; i++)
			{
				if (strRow[i] == strNum)
				{
					return true;
				}
			}
			return false;
		}
		
		public bool HasAll9()
		{
			string[] strNums = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
			bool boolNumFound = false;
			
			for (int k = 0; k < 9; k++)
			{
				boolNumFound = false;
				for (int i = 0; i < 9; i++)
				{
					if (strRow[i] == strNums[k])
					{
						boolNumFound = true;
					}
				}
				if (!boolNumFound)
				{
					return false;
				}
			}
			return true;
		}
		
		public void SetValue(int index, string strVal)
		{
			strRow[index] = strVal;
		}
		
		public string GetNumber(int index)
		{
			return strRow[index];
		}
		
		public int GetPosition(string strNum)
		{
			int tmp = 0;
			
			for (int i = 0; i < 9; i++)
			{
				if (strRow[i] == strNum)
				{
					tmp = i;
				}
			}
			return tmp;
		}
	}
	
	public class SudokoCol
	{
		private string[] strCol = new string[9];
		private Hashtable hashStickyNums = new Hashtable();
	
		
		public int intNumber = 0;
		
		public SudokoCol(SudokoCell sc1, SudokoCell sc2, SudokoCell sc3, int index, int intNum)
		{
			string[] strTmp = null;
			
			strTmp = sc1.GetCol(index);
			strCol[0] = strTmp[0];
			strCol[1] = strTmp[1];
			strCol[2] = strTmp[2];
			
			strTmp = sc2.GetCol(index);
			strCol[3] = strTmp[0];
			strCol[4] = strTmp[1];
			strCol[5] = strTmp[2];
			
			strTmp = sc3.GetCol(index);
			strCol[6] = strTmp[0];
			strCol[7] = strTmp[1];
			strCol[8] = strTmp[2];
			
			intNumber = intNum;
		}
		
		public SudokoCol()
		{
			
		}
		
		public Hashtable GetSticky()
		{
			return hashStickyNums;
		}
		
		public void UpdateSticky(string strAction, int index, string strVal)
		{
			switch (strAction)
			{
				case "a":
					try
					{
						hashStickyNums.Remove(index);
					}
					catch (Exception)
					{
						//DO NOTHING - JUST MOVE ON
					}
					hashStickyNums.Add(index, strVal);
					break;
				case "di":
					hashStickyNums.Remove(index);
					break;
				case "dv":
					if (hashStickyNums.ContainsValue(strVal))
					{
						for (int i = 0; i < hashStickyNums.Keys.Count; i++)
						{
							if (hashStickyNums[i].ToString() == strVal)
							{
								hashStickyNums.Remove(i);
							}
						}
					}
					break;
				default:
					break;
			}
		}
		
		public bool HasNumberInSticky(string strNum)
		{
			bool boolRet = false;
			
			if (hashStickyNums.ContainsValue(strNum))
			{
				boolRet = true;
			}
			
			return boolRet;
		}
		
		public bool HasNumber(string strNum)
		{
			for (int i = 0; i < 9; i++)
			{
				if (strCol[i] == strNum)
				{
					return true;
				}
			}
			return false;
		}
		
		public bool HasAll9()
		{
			string[] strNums = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
			bool boolNumFound = false;
			
			for (int k = 0; k < 9; k++)
			{
				boolNumFound = false;
				for (int i = 0; i < 9; i++)
				{
					if (strCol[i] == strNums[k])
					{
						boolNumFound = true;
					}
				}
				if (!boolNumFound)
				{
					return false;
				}
			}
			return true;
		}
		
		public void SetValue(int index, string strVal)
		{
			strCol[index] = strVal;
		}
		
		public string GetNumber(int index)
		{
			return strCol[index];
		}
		
		public int GetPosition(string strNum)
		{
			int tmp = 0;
			
			for (int i = 0; i < 9; i++)
			{
				if (strCol[i] == strNum)
				{
					tmp = i;
				}
			}
			return tmp;
		}
	}
}
