using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONETWrapper;
using System.Data;
using System.Configuration;

namespace DAO
{
    public class DALConnection
    {
        private DBWrapper cnConection;

        private CommandType oType;
        public DBWrapper Conn
        {
            get { return cnConection; }
        }
        public DALConnection()
        {
            cnConection = DBWrapper.GetADONETWrapper("SQLCLIENT");
            cnConection.CommandTimeout = 0;
            cnConection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            oType = CommandType.StoredProcedure;
        }
        public void DisposeConn()
        {
            cnConection.Disconnect();
            cnConection.Dispose();
            cnConection = null;
        }
    }
}
