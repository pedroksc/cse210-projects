using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        else
        {
            Console.WriteLine("\n========== Journal Entries ==========");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("-----------------------------------");
        }
    }
    public void SaveToFile (string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.GetDate()}|{entry.GetPromptText()}|{entry.GetEntryText()}");
            }
        }

        Console.WriteLine($"Journal saved to \"{fileName}\".");
    }

    public void LoadFromFile (string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"File \"{fileName}\" does not exist.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                string date = parts[0];
                string promptText = parts[1];
                string entryText = parts[2];

                Entry entry = new Entry(date, promptText, entryText);
                _entries.Add(entry);
            }

            Console.WriteLine($"Journal loaded from \"{fileName}\". {_entries.Count} entries loaded.");
        }
    }


}