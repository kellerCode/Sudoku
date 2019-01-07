using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LincolnGames.UI.MVC.Models
{
    public class SudokuModel
    {
        public List<int> rows1to3 { get; set; }
        public List<int> rows4to6 { get; set; }
        public List<int> rows7to9 { get; set; }
    }
}