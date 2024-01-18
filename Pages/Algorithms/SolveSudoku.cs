namespace GettingStarted.Pages.Algorithms
{
    //http://aspadvice.com/blogs/rbirkby/archive/2007/08/23/Silverlight-Sudoku-with-LINQ.aspx
    public static class SolveSudoku
    {
        static string rows = "ABCDEFGHI";
        static string cols = "123456789";
        static string digits = "123456789";
        static string[] squares = cross(rows, cols);
        static Dictionary<string, IEnumerable<string>> peers;
        static Dictionary<string, IGrouping<string, string[]>> units;

        static string[] cross(string A, string B)
        {
            return (from a in A
                    from b in B
                    select "" + a + b).ToArray();
        }

        static SolveSudoku()
        {

            var unitlist = ((from c in cols
                             select cross(rows, c.ToString()))
                                  .Concat(from r in rows
                                          select cross(r.ToString(), cols))
                                  .Concat(from rs in (new[] { "ABC", "DEF", "GHI" })
                                          from cs in (new[] { "123", "456", "789" })
                                          select cross(rs, cs)));

            units = (from s in squares from u in unitlist where u.Contains(s) group u by s into g select g).ToDictionary(g => g.Key);
            peers = (from s in squares from u in units[s] from s2 in u where s2 != s group s2 by s into g select g).ToDictionary(g => g.Key, g => g.Distinct());

        }

        static string[][] zip(string[] A, string[] B)
        {
            var n = Math.Min(A.Length, B.Length);
            string[][] sd = new string[n][];
            for (var i = 0; i < n; i++)
            {
                sd[i] = new string[] { A[i].ToString(), B[i].ToString() };
            }
            return sd;
        }
        public static Dictionary<string, string> parse_grid(string grid)
        {
            var grid2 = from c in grid where "0.-123456789".Contains(c) select c;
            var values = squares.ToDictionary(s => s, s => digits); //To start, every square can be any digit

            foreach (var sd in zip(squares, (from s in grid select s.ToString()).ToArray()))
            {
                var s = sd[0];
                var d = sd[1];

                if (digits.Contains(d) && assign(values, s, d) == null)
                {
                    return null;
                }
            }
            return values;
        }

        public static Dictionary<string, string> search(Dictionary<string, string> values)
        {
            if (values == null)
            {
                return null;
            }
            if (all(from s in squares select values[s].Length == 1 ? "" : null))
            {
                return values;
            }
            var s2 = (from s in squares
                      where values[s].Length > 1
                      orderby values[s].Length
                      ascending
                      select s).First();

            return some(from d in values[s2]
                        select search(assign(new Dictionary<string, string>(values), s2, d.ToString())));
        }

        static Dictionary<string, string> assign(Dictionary<string, string> values, string s, string d)
        {
            if (all(from d2 in values[s]
                    where d2.ToString() != d
                    select eliminate(values, s, d2.ToString())))
            {
                return values;
            }
            return null;
        }

        /// <summary>Eliminate d from values[s]; propagate when values or places &lt;= 2.</summary>
        static Dictionary<string, string> eliminate(Dictionary<string, string> values, string s, string d)
        {
            if (!values[s].Contains(d))
            {
                return values;
            }
            values[s] = values[s].Replace(d, "");
            if (values[s].Length == 0)
            {
                return null; //Contradiction: removed last value
            }
            else if (values[s].Length == 1)
            {
                //If there is only one value (d2) left in square, remove it from peers
                var d2 = values[s];
                if (!all(from s2 in peers[s]
                         select eliminate(values, s2, d2)))
                {
                    return null;
                }
            }

            //Now check the places where d appears in the units of s
            foreach (var u in units[s])
            {
                var dplaces = from s2 in u
                              where values[s2].Contains(d)
                              select s2;
                if (dplaces.Count() == 0)
                {
                    return null;
                }
                else if (dplaces.Count() == 1)
                {
                    // d can only be in one place in unit; assign it there
                    if (assign(values, dplaces.First(), d) == null)
                    {
                        return null;
                    }
                }
            }
            return values;
        }

        static bool all<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e == null) return false;
            }
            return true;
        }

        static T some<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e != null) return e;
            }
            return default(T);
        }
        static string Center(this string s, int width)
        {
            var n = width - s.Length;
            if (n <= 0) return s;
            var half = n / 2;

            if (n % 2 > 0 && width % 2 > 0) half++;

            return new string(' ', half) + s + new String(' ', n - half);
        }
        static List<List<int>> print_board(Dictionary<string, string> values)
        {
            if (values == null) return null;

            var width = 1 + (from s in squares
                             select values[s].Length).Max();
            var ls = new List<List<int>>();
            foreach (var r in rows)
            {
                var temp = string.Join("",
                        (from c in cols select values["" + r + c].Center(width)).ToArray());
                ls.Add(temp.Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToList());
            }

            Console.WriteLine();
            return ls;
        }

        public static List<List<int>> Solve(string arr)
        {
            return print_board(search(parse_grid(arr)));
        }
    }
}
