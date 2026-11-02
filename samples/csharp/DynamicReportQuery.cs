// Selected excerpt from Models/Report/ReportRepository.cs
// Executes selected columns; caller validates fields against reporting metadata.
// Enclosing types and application dependencies are intentionally omitted.

public DataTable ExecuteReport(string tableName, string[] fields)
        {
            var allowedTables = new[]
            {
                "CustomerDoc_tb",
                "CustomerFinan_tb",
                "Customer_tb"
            };

            if (!allowedTables.Contains(tableName))
                throw new InvalidOperationException("جدول گزارش معتبر نیست.");

            if (fields.Length == 0)
                throw new InvalidOperationException("فیلدی انتخاب نشده است.");

            foreach (var field in fields)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(
                        field, @"^[A-Za-z_][A-Za-z0-9_]*$"))
                {
                    throw new InvalidOperationException("نام فیلد معتبر نیست.");
                }
            }

            string columns = string.Join(", ", fields.Select(f => $"[{f}]"));
            string sql = $"SELECT {columns} FROM [{tableName}]";

            var result = new DataTable();

            using var con = new SqlConnection(_conStr);
            using var cmd = new SqlCommand(sql, con);

            con.Open();

            using var reader = cmd.ExecuteReader();
            result.Load(reader);

            return result;
        }
