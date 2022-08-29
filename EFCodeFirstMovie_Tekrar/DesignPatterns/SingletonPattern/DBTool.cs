using EFCodeFirstMovie_Tekrar.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.DesignPatterns.SingletonPattern
{
    public class DBTool 
    {
        public DBTool() { }

        public static MyContext _dbInstance;

        public static MyContext DBInstance 
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }

        }


    }
}
