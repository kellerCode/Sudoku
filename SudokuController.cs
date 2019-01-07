using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LincolnGames.UI.MVC.Models;

namespace LincolnGames.UI.MVC.Controllers
{
    public class SudokuController : Controller
    {
        // GET: Sudoku
        public ActionResult Index(string type)
        {
            // full list that will be broken into the 3 parts of the Model then passed to the view
            int[] fullList = new int[81];
            switch (type)
            {
                case null:
                    fullList = GetEasy();
                    break;
                case "blank":
                    fullList = GetBlank();
                    break;
                case "easy":
                    fullList = GetEasy();
                    break;
                case "medium":
                    fullList = GetMedium();
                    break;
                case "hard":
                    fullList = GetHard();
                    break;
                default:
                    break;
            }
            //Get full array from above, Break into 3 model lists to pass into the view. rows1-3, rows4-6, rows7-9;


            List<int> rows1to3 = new List<int>();
            List<int> rows4to6 = new List<int>();
            List<int> rows7to9 = new List<int>();
            for (int i = 0; i < 27; i++)
            {
                rows1to3.Add(fullList[i]);
            }
            for (int i = 27; i < 54; i++)
            {
                rows4to6.Add(fullList[i]);
            }
            for (int i = 54; i < 81; i++)
            {
                rows7to9.Add(fullList[i]);
            }
            SudokuModel nbrList = new SudokuModel();
            nbrList.rows1to3 = rows1to3;
            nbrList.rows4to6 = rows4to6;
            nbrList.rows7to9 = rows7to9;
            return View(nbrList);
        }

        public int[] GetEasy()
        {
            List<int[]> easyArrays = new List<int[]>();
            int[] easy1 = new int[] { 0, 3, 0, 0, 2, 7, 9, 0, 1, 9, 0, 2, 0, 0, 3, 0, 0, 8, 0, 1, 8, 9, 0, 0, 2, 0, 0, 0, 2, 0, 0, 3, 0, 0, 0, 0, 0, 4, 0, 5, 6, 1, 0, 7, 0, 0, 0, 0, 0, 9, 0, 0, 8, 0, 0, 0, 1, 0, 0, 5, 8, 2, 0, 2, 0, 0, 3, 0, 0, 4, 0, 7, 3, 0, 5, 2, 8, 0, 0, 9, 0 };
            easyArrays.Add(easy1);
            int[] easy2 = new int[] { 3, 0, 0, 0, 0, 5, 4, 0, 0, 0, 0, 2, 0, 3, 0, 1, 9, 0, 5, 0, 1, 6, 0, 4, 0, 0, 3, 0, 1, 0, 0, 6, 9, 0, 3, 2, 0, 0, 6, 0, 0, 0, 8, 0, 0, 9, 2, 0, 4, 8, 0, 0, 7, 0, 1, 0, 0, 3, 0, 6, 2, 0, 7, 0, 7, 8, 0, 5, 0, 3, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 6, };
            easyArrays.Add(easy2);
            int[] easy3 = new int[] { 1, 0, 0, 0, 3, 8, 0, 9, 7, 0, 3, 2, 0, 0, 0, 4, 0, 5, 0, 8, 5, 4, 0, 0, 3, 0, 0, 0, 5, 0, 6, 0, 0, 0, 2, 0, 3, 0, 0, 9, 0, 1, 0, 0, 8, 0, 1, 0, 0, 0, 3, 0, 5, 0, 0, 0, 8, 0, 0, 9, 7, 1, 0, 2, 0, 3, 0, 0, 0, 8, 4, 0, 4, 7, 0, 8, 6, 0, 0, 0, 9 };
            easyArrays.Add(easy3);
            int[] easy4 = new int[] { 0, 0, 5, 0, 0, 7, 9, 0, 0, 1, 0, 0, 9, 4, 8, 0, 6, 0, 0, 3, 6, 0, 0, 0, 0, 0, 7, 0, 6, 0, 2, 0, 4, 0, 0, 9, 0, 4, 9, 0, 8, 0, 7, 2, 0, 8, 0, 0, 7, 0, 6, 0, 5, 0, 6, 0, 0, 0, 0, 0, 2, 9, 0, 0, 1, 0, 8, 2, 9, 0, 0, 5, 0, 0, 4, 1, 0, 0, 3, 0, 0 };
            easyArrays.Add(easy4);
            int[] easy5 = new int[] { 0, 6, 0, 4, 0, 0, 8, 3, 0, 9, 7, 0, 5, 0, 0, 6, 0, 1, 8, 0, 0, 0, 2, 0, 0, 0, 0, 0, 5, 9, 2, 0, 0, 0, 0, 0, 6, 0, 4, 0, 1, 0, 2, 0, 5, 0, 0, 0, 0, 0, 4, 3, 7, 0, 0, 0, 0, 0, 9, 0, 0, 0, 4, 3, 0, 6, 0, 0, 8, 0, 2, 7, 0, 1, 5, 0, 0, 2, 0, 8, 0 };
            easyArrays.Add(easy5);
            Random rand = new Random();
            int randIndex = rand.Next(0, easyArrays.Count());

            int[] selectedArray = easyArrays[randIndex];

            return selectedArray;
        }
        public int[] GetMedium()
        {

            List<int[]> mediumArrays = new List<int[]>();

            int[] medium1 = new int[] { 9, 7, 0, 0, 0, 3, 0, 0, 6, 0, 0, 1, 0, 4, 0, 0, 0, 2, 0, 0, 4, 2, 9, 0, 0, 1, 0, 0, 2, 0, 3, 0, 0, 5, 0, 0, 4, 0, 0, 7, 0, 9, 0, 0, 8, 0, 0, 5, 0, 0, 1, 0, 7, 0, 0, 4, 0, 0, 8, 6, 3, 0, 0, 5, 0, 0, 0, 3, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 0, 8, 9 };

            mediumArrays.Add(medium1);

            int[] medium2 = new int[] { 0, 6, 2, 9, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 2, 1, 0, 1, 6, 0, 7, 3, 0, 0, 0, 8, 0, 3, 0, 0, 0, 6, 0, 2, 0, 0, 0, 5, 6, 0, 3, 1, 0, 6, 3, 9, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 9, 4, 0, 0, 0, 0, 9, 7, 6, 0 };

            mediumArrays.Add(medium2);

            int[] medium3 = new int[] { 0, 5, 0, 1, 0, 0, 0, 7, 0, 3, 0, 0, 2, 5, 0, 0, 0, 9, 0, 0, 7, 3, 0, 0, 5, 0, 0, 0, 3, 4, 0, 0, 2, 0, 0, 0, 9, 0, 0, 0, 1, 0, 0, 0, 5, 0, 0, 0, 7, 0, 0, 9, 6, 0, 0, 0, 3, 0, 0, 8, 2, 0, 0, 7, 0, 0, 0, 3, 1, 0, 0, 8, 0, 8, 0, 0, 0, 5, 0, 1, 0 };

            mediumArrays.Add(medium3);

            int[] medium4 = new int[] { 0, 0, 4, 0, 0, 8, 7, 9, 0, 5, 6, 0, 0, 9, 0, 0, 0, 8, 0, 7, 0, 1, 0, 0, 0, 0, 0, 0, 8, 0, 9, 0, 0, 2, 0, 3, 0, 0, 3, 0, 4, 0, 9, 0, 0, 9, 0, 5, 0, 0, 3, 0, 7, 0, 0, 0, 0, 0, 0, 2, 0, 3, 0, 2, 0, 0, 0, 1, 0, 0, 6, 9, 0, 4, 1, 5, 0, 0, 8, 0, 0 };

            mediumArrays.Add(medium4);

            int[] medium5 = new int[] { 0, 0, 2, 7, 0, 0, 0, 9, 5, 0, 9, 0, 8, 0, 5, 3, 0, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 5, 4, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 5, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 9, 0, 0, 8, 0, 0, 0, 2, 0, 0, 0, 0, 6, 5, 0, 8, 0, 1, 0, 9, 2, 0, 0, 0, 4, 7, 0, 0 };

            mediumArrays.Add(medium5);

            Random rand = new Random();
            int randIndex = rand.Next(0, mediumArrays.Count());

            int[] selectedArray = mediumArrays[randIndex];

            return selectedArray;
        }

        public int[] GetHard()
        {

            List<int[]> hardArrays = new List<int[]>();

            int[] hard1 = new int[] { 7, 0, 0, 1, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 9, 4, 0, 0, 8, 2, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 4, 5, 0, 0, 3, 0, 4, 0, 6, 0, 2, 0, 0, 7, 5, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 6, 3, 0, 0, 6, 4, 3, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 2, 0, 0, 4 };

            hardArrays.Add(hard1);

            int[] hard2 = new int[] { 0, 0, 3, 0, 0, 9, 0, 4, 8, 7, 0, 0, 0, 3, 0, 2, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 2, 6, 0, 5, 0, 0, 0, 0, 7, 0, 0, 7, 9, 0, 1, 6, 0, 0, 9, 0, 0, 0, 0, 7, 0, 2, 5, 0, 0, 0, 3, 0, 0, 0, 5, 0, 0, 0, 2, 0, 5, 0, 0, 0, 6, 4, 8, 0, 7, 0, 0, 1, 0, 0 };

            hardArrays.Add(hard2);

            int[] hard3 = new int[] { 0, 4, 0, 0, 0, 8, 0, 0, 0, 0, 0, 7, 0, 5, 2, 0, 4, 0, 5, 0, 0, 0, 0, 6, 2, 0, 9, 7, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 6, 0, 9, 0, 0, 0, 0, 4, 5, 0, 0, 0, 0, 6, 1, 0, 2, 6, 0, 0, 0, 0, 7, 0, 7, 0, 2, 9, 0, 4, 0, 0, 0, 0, 0, 7, 0, 0, 0, 6, 0 };

            hardArrays.Add(hard3);

            int[] hard4 = new int[] { 0, 0, 0, 8, 3, 5, 0, 2, 0, 6, 0, 0, 0, 0, 0, 5, 0, 0, 0, 3, 0, 0, 9, 0, 8, 0, 0, 9, 8, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 9, 0, 7, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 1, 3, 0, 0, 1, 0, 2, 0, 0, 4, 0, 0, 0, 7, 0, 0, 0, 0, 0, 1, 0, 2, 0, 4, 7, 1, 0, 0, 0 };

            hardArrays.Add(hard4);

            int[] hard5 = new int[] { 0, 0, 0, 9, 0, 0, 0, 7, 4, 7, 1, 0, 0, 2, 8, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 6, 0, 6, 0, 0, 0, 0, 4, 5, 0, 0, 0, 3, 0, 0, 7, 0, 0, 9, 0, 0, 0, 5, 1, 0, 0, 0, 0, 7, 0, 5, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 7, 1, 0, 0, 8, 5, 8, 7, 0, 0, 0, 2, 0, 0, 0 };

            hardArrays.Add(hard5);

            Random rand = new Random();
            int randIndex = rand.Next(0, hardArrays.Count());

            int[] selectedArray = hardArrays[randIndex];

            return selectedArray;
        }

        public int[] GetBlank()
        {
            int[] numbers = new int[81];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 0;
            }

            return numbers;
        }

        //CHECKING USER ANSWER BELOW
        public JsonResult puzzle(List<int> sec1, List<int> sec2, List<int> sec3, List<int> sec4, List<int> sec5, List<int> sec6, List<int> sec7, List<int> sec8, List<int> sec9)
        {
            //List to compare all rows, columns, and sections to
            List<int> answer = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Getting first three rows--below
            List<List<int>> sec1to3 = new List<List<int>> { sec1, sec2, sec3 };
            //Initializing first three rows list.
            List<int> row1 = new List<int>();
            List<int> row2 = new List<int>();
            List<int> row3 = new List<int>();
            foreach (List<int> item in sec1to3)
            {
                row1.Add(item[0]);
                row1.Add(item[1]);
                row1.Add(item[2]);
                row2.Add(item[3]);
                row2.Add(item[4]);
                row2.Add(item[5]);
                row3.Add(item[6]);
                row3.Add(item[7]);
                row3.Add(item[8]);
            }
            //Getting rows 4 through 6--below
            List<List<int>> sec4to6 = new List<List<int>> { sec4, sec5, sec6 };
            //Initializing rows 4 through 6 list.
            List<int> row4 = new List<int>();
            List<int> row5 = new List<int>();
            List<int> row6 = new List<int>();
            foreach (List<int> item in sec4to6)
            {
                row4.Add(item[0]);
                row4.Add(item[1]);
                row4.Add(item[2]);
                row5.Add(item[3]);
                row5.Add(item[4]);
                row5.Add(item[5]);
                row6.Add(item[6]);
                row6.Add(item[7]);
                row6.Add(item[8]);
            }
            //Getting rows 7 through 9--below
            List<List<int>> sec7to9 = new List<List<int>> { sec7, sec8, sec9 };
            //Initializing rows 7 through 9 list.
            List<int> row7 = new List<int>();
            List<int> row8 = new List<int>();
            List<int> row9 = new List<int>();
            foreach (List<int> item in sec7to9)
            {
                row7.Add(item[0]);
                row7.Add(item[1]);
                row7.Add(item[2]);
                row8.Add(item[3]);
                row8.Add(item[4]);
                row8.Add(item[5]);
                row9.Add(item[6]);
                row9.Add(item[7]);
                row9.Add(item[8]);
            }

            //Checking all of the columns by looping through each row and passing in the index of each to make up the column. 
            //Then checking that column against the 'answer' List above.. if fails redirect to index with message
            for (int i = 0; i < 9; i++)
            {
                List<int> indexes = new List<int>();
                indexes.Add(row1[i]);
                indexes.Add(row2[i]);
                indexes.Add(row3[i]);
                indexes.Add(row4[i]);
                indexes.Add(row5[i]);
                indexes.Add(row6[i]);
                indexes.Add(row7[i]);
                indexes.Add(row8[i]);
                indexes.Add(row9[i]);
                indexes.Sort();
                if (indexes.SequenceEqual(answer))
                {

                }
                else
                {
                    var message = "wrong";
                    return Json(new { message = message });
                }
            }
            //Check all rows for 1 through 9***
            List<List<int>> allRows = new List<List<int>> { row1, row2, row3, row4, row5, row6, row7, row8, row9 };
            for (int i = 0; i < 9; i++)
            {
                List<int> checkRow = allRows[i];
                checkRow.Sort();
                if (checkRow.SequenceEqual(answer))
                {

                }
                else
                {
                    var message = "wrong";
                    return Json(new { message = message });
                }
            }

            //check all sections below***
            sec1.Sort();
            sec2.Sort();
            sec3.Sort();
            sec4.Sort();
            sec5.Sort();
            sec6.Sort();
            sec7.Sort();
            sec8.Sort();
            sec9.Sort();
            if (sec1.SequenceEqual(answer) && sec2.SequenceEqual(answer) && sec3.SequenceEqual(answer) && sec4.SequenceEqual(answer) && sec5.SequenceEqual(answer) && sec6.SequenceEqual(answer) && sec7.SequenceEqual(answer) && sec8.SequenceEqual(answer) && sec9.SequenceEqual(answer))
            {
                var message = "correct";
                return Json(new { message = message });
            }
            else
            {
                var message = "wrong";
                return Json(new { message = message });
            }

        }
    }
}