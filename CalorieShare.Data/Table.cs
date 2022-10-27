using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieShare.Data;

public abstract class Table
{

    private DataTable? _table;
    protected string _tableName;

    public Table(string tableName)
    {
        _tableName = tableName;
    }

    public DataTable All()
    {
        if (this._table is not null)
            return _table;

        var db = new Database();

        _table = db.Query($"SELECT * FROM {_tableName} ");
        return _table;
    }


}
