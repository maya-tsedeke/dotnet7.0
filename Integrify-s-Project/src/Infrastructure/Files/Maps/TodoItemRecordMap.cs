﻿using System.Globalization;
using CsvHelper.Configuration;
using Integrify_s_Project.Application.TodoLists.Queries.ExportTodos;

namespace Integrify_s_Project.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
