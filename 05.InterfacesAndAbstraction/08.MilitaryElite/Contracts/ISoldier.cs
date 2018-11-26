using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISoldier
    {
        //id, firstName and lastName
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
