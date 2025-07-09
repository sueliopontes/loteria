using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;
using GameResultsApi.Models;

namespace GameResultsApi.Utils
{
    public class ExcelParser
    {
        public List<GameResult> ParseExcelFile(Stream fileStream)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var gameResults = new List<GameResult>();

            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
            {
                while (reader.Read())
                {
                    // Skip header row
                    if (reader.Depth == 0)
                        continue;
                    if (reader.FieldCount >= 2)
                    {
                        var dateString = reader.GetValue(0)?.ToString();
                        DateTime date;
                        if (!DateTime.TryParseExact(dateString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                        {
                            date = DateTime.MinValue; // ou trate o erro conforme necessário
                        }
                        var numbers = new List<int>();
                        for (int i = 1; i <= 15; i++)
                        {
                            if (!reader.IsDBNull(i))
                            {
                                numbers.Add(Convert.ToInt32(reader.GetValue(i)));
                            }
                        }

                        gameResults.Add(new GameResult
                        {
                            Date = date,
                            Numbers = numbers
                        });
                    }
                }
            }

            return gameResults;
        }
    }
}