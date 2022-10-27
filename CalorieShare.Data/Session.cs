using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CalorieShare.Core;

namespace CalorieShare.Data;
public interface ISession
{
    string HeinrichGuid();
}
public class Session : Table
{
    private readonly string _Guid;
    public Session() : base("Heinrich_Session")
    {
        _Guid = Guid.NewGuid().ToString();

        var db = new Database();
        db.NonQuery("INSERT INTO dbo.Heinrich_Session (Guid) values (@guid)", "@guid", this._Guid);
    }

    public string HeinrichGuid()
    {
        return this._Guid;
    }

}
