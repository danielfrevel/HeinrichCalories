using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
//csv daten in meine Datenbank schreiben 😈


DataTable csvData = new DataTable();
using (TextFieldParser csvReader = new TextFieldParser("./nutritional_data.csv"))
{
    csvReader.SetDelimiters(new string[] { "," });
    csvReader.HasFieldsEnclosedInQuotes = true;
    string[] colFields = csvReader.ReadFields();
    foreach (string column in colFields)
    {
        DataColumn datecolumn = new DataColumn(column);
        datecolumn.AllowDBNull = true;
        csvData.Columns.Add(datecolumn);
    }
    while (!csvReader.EndOfData)
    {
        string[] fieldData = csvReader.ReadFields();
        //Making empty value as null
        for (int i = 0; i < fieldData.Length; i++)
        {
            if (fieldData[i] == "")
            {
                fieldData[i] = null;
            }
        }
        csvData.Rows.Add(fieldData);
    }
}


string sqlsc;

sqlsc = "CREATE TABLE " + "Nutrition_Base" + "(";
for (int i = 0; i < csvData.Columns.Count; i++)
{
    sqlsc += "\n [" + csvData.Columns[i].ColumnName + "] ";
    string columnType = csvData.Columns[i].DataType.ToString();
    switch (columnType)
    {
        case "System.Int32":
            sqlsc += " int ";
            break;
        case "System.Int64":
            sqlsc += " bigint ";
            break;
        case "System.Int16":
            sqlsc += " smallint";
            break;
        case "System.Byte":
            sqlsc += " tinyint";
            break;
        case "System.Decimal":
            sqlsc += " decimal";
            break;
        case "System.DateTime":
            sqlsc += " datetime ";
            break;
        case "System.String":
        default:
            sqlsc += string.Format(" nvarchar({0}) ", csvData.Columns[i].MaxLength == -1 ? "max" : csvData.Columns[i].MaxLength.ToString());
            break;
    }
    sqlsc += ",";
}

string command = sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";


string constring = "Server=localhost,50505;Database=CalorieShare;User Id=sa;Password=Vmware##";

using (SqlConnection con = new SqlConnection(constring))
{
    con.Open();

    var test = new SqlCommand(command, con);
    test.ExecuteNonQuery();
    using (SqlBulkCopy s = new SqlBulkCopy(con))
    {
        s.DestinationTableName = "Nutrition_Base";
        foreach (var column in csvData.Columns)
            s.ColumnMappings.Add(column.ToString(), column.ToString());
        s.WriteToServer(csvData);
    }
}


