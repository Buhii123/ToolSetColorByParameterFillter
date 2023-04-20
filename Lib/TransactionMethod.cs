using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.Models;

namespace ToolSetColorByFillter.Lib
{
    public static class TransactionMethod
    {
      
 
        public static void TranTransactionRun(Action myTransaction, Document doc,string name) 
        {
            using (Transaction tr = new Transaction(doc, name))
            {
               
                tr.Start();
                myTransaction();
                tr.Commit();
            }
        }
        public static void TranTransactionRun(Action<List<ElementId>> myTransaction, List<ElementId> thamso, Document doc, string name)
        {
            using (Transaction tr = new Transaction(doc, name))
            {

                tr.Start();
                myTransaction(thamso);
                tr.Commit();
            }
        }
        public static void TranTransactionRun(Action<ElementByFilter> myTransaction, ElementByFilter thamso, Document doc, string name)
        {
            using (Transaction tr = new Transaction(doc, name))
            {

                tr.Start();
                myTransaction(thamso);
                tr.Commit();
            }
        }

    }
}
