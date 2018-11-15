using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ExtensionMethods
{
    public static class Class1
    {
        public static bool IsEmpty(this DataSet dataSet)
        {
            return dataSet == null ||
              !(from DataTable t in dataSet.Tables where t.Rows.Count > 0 select t).Any();
        }
    }
}
