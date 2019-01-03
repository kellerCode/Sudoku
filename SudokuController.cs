using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LincolnGames.UI.MVC.Controllers
{
    public class SudokuController : Controller
    {
        // GET: Sudoku
        public ActionResult Index()
        {
            return View();
        }

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