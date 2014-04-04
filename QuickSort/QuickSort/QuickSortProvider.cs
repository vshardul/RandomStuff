using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class QuickSortProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static IEnumerable<T> NaiveSort<T>(T[] itemList) where T : IComparable
        {
            int numberOfElements = itemList.Count();

            if (!itemList.Any() || numberOfElements == 1)
            {
                return itemList;
            }

            int pivot = numberOfElements / 2;
            var leftArray = itemList.Where((item, i) =>  i != pivot && item.CompareTo(itemList[pivot]) <= 0);
            var rightArray = itemList.Where((item, i) => i != pivot && item.CompareTo(itemList[pivot]) > 0);

            return Concat(NaiveSort(leftArray.ToArray()).ToList(),  itemList[pivot], NaiveSort(rightArray.ToArray()).ToList());
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array1"></param>
        /// <param name="item"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private static IEnumerable<T> Concat<T>(List<T> array1, T item, List<T> array2) where T : IComparable
        {
            array1.Add(item);
            array1.AddRange(array2);
            return array1;
        }

    }
}
