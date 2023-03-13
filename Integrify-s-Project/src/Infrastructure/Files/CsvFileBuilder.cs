using System.Globalization;
using CsvHelper;
using Integrify_s_Project.Application.Common.Interfaces;
using Integrify_s_Project.Application.TodoLists.Queries.ExportTodos;
using Integrify_s_Project.Infrastructure.Files.Maps;

namespace Integrify_s_Project.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
