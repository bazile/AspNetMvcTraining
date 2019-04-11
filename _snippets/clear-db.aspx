<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">
    void Page_Load()
    {
        if (Request.HttpMethod == "POST")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var allTables = connection.GetSchema("Tables")
                    .AsEnumerable()
                    .Select(r => r.Field<string>("TABLE_SCHEMA") + "." + r.Field<string>("TABLE_NAME"))
                    .OrderBy(name => name);
                foreach (string tableName in allTables)
                {
                    using (var command = new SqlCommand($"DROP TABLE [{tableName}]", connection))
                    {
                        Response.Write($"Dropping table {tableName}<br>\r\n");
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
</script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="post">
        <input type="submit" value="Удалить все таблицы" />
    </form>
</body>
</html>
