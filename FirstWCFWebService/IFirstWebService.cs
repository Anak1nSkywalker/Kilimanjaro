using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FirstWCFWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFirstWebService" in both code and config file together.
    [ServiceContract]
    public interface IFirstWebService
    {
        [OperationContract]
        string Message();

        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        IEnumerable<User> ListAll();

        [OperationContract]
        List<User> TypeListAll();

    }
}
