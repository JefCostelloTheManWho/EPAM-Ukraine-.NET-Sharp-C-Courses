using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {
        //The implementation of your tasks should look like this:
        public static string TaskExample(IEnumerable<string> stringList)
        {
            return stringList.Aggregate<string>((x, y) => x + y);
        }

        #region Low

        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Where(x => (x[0] == c && x[^1] == c) && x.Length - 1 > 1).AsEnumerable();
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.Length).OrderBy(x => x);
        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x[0].ToString() + x[^1].ToString());
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(s => s.Length == k && Char.IsDigit(s[^1])).OrderBy(x => x);
        }

        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(x => ((x % 2) != 0)).OrderBy(x => x).Select(x => x.ToString());
        }

        #endregion

        #region Middle

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            var newStrings = stringList.Join(numbers, str => str.Length, num => num, 
                (str, num) => 
                 new string(stringList.Where(s => s.Length == str.Length).FirstOrDefault(x => char.IsDigit(x[0]) && x.Length == num) ?? "Not found")).Distinct();
            return newStrings;

        }
        
        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {

            return (from n in integerList where n % 2 == 0 select n)
                .Except(integerList.Skip(k)).Reverse();

        }

        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            return integerList.TakeWhile(num => num <= d)
                .Union(integerList.Skip(k))
                .OrderByDescending(num=>num);
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            return stringList.GroupBy(str => str.FirstOrDefault())
                .Select(gr => gr.Sum(item => item.Length).ToString() + "-" + gr.Key.ToString())
                .OrderByDescending(res => int.Parse(res.Substring(0, res.IndexOf("-"))))
                .ThenBy(res => res[^1]);

        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList.OrderBy(c => c).
                GroupBy(i => i.Length, str => str[^1].ToString().ToUpper())
                .Select(s => s.Aggregate((a, b) => a + b)).OrderByDescending(c => c.Length);
        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            var schooCount = nameList.Distinct().GroupBy(x => x.Year).Distinct().Select(x => 
            new YearSchoolStat {  NumberOfSchools = x.Select(x => x.SchoolNumber).Distinct().Count(),
                                  Year = x.Key
            }).OrderBy(x=>x.NumberOfSchools).ThenBy(x=>x.Year);
            return schooCount;

        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.Join(integerList2, item1 => item1.ToString()[^1], item2 => item2.ToString()[^1],
                (item1, item2) => new NumberPair { Item1 = item1, Item2 = item2 }).OrderBy(x => x.Item1)
                .ThenBy(x => x.Item1.ToString()[^1] == x.Item2.ToString()[^1] ? x.Item2 : x.Item1);
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return nameList.Join(yearList, name => name.Year, year => year,
                (name, year) => new YearSchoolStat { NumberOfSchools = name.SchoolNumber, Year = year }).GroupBy(x => x.Year)
                .Select(x => new YearSchoolStat { NumberOfSchools = x.Select(x => x.NumberOfSchools).Distinct().Count(), Year = x.Key }).OrderBy(x=>x.NumberOfSchools);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {


            throw new NotImplementedException();
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {

            var result = from good in goodList
                         join store in storePriceList
                         on good.Id equals store.GoodId
                         group storePriceList by good.Country into g
                         select new CountryStat { StoresNumber = g.Select(x => x.Select(x => x.Shop)).Count(),
                          Country = g.Key,
                          MinPrice = g.Select(x => x.Select(x => x.Price)).Min().FirstOrDefault()};

            return result.OrderBy(x => x.Country);

        }

        #endregion

    }
}
