using System;
using System.Collections.Generic;
using System.Text;

namespace GiunecoTeam.Domain.Exceptions
{
    public class RemoteException: Exception
    {
        public RemoteException(string message): base(message)
        {
            
        }
    }
}
