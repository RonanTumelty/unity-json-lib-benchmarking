using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Benchmarking.Logging
{
    public class CSVLogEntry
    {
        public string library;
        public int serialiseDurationMs;
        public int serialiseAllocationsMB;
        public int deserialiseDurationMs;
        public int deserialiseAllocationsMB;
    }
    
    public class Results {
        public (string, int) quickestSerialise = (String.Empty, int.MaxValue);
        public (string, int) leastAllocationsSerialise = (String.Empty, int.MaxValue);
        public (string, int) quickestDeserialise = (String.Empty, int.MaxValue);
        public (string, int) leastAllocationsDeserialise = (String.Empty, int.MaxValue);
    }
    
    public class CSVLog
    {
        private Dictionary<string, CSVLogEntry> logEntries;
        public Results results = new Results();

        public CSVLog()
        {
            logEntries = new Dictionary<string, CSVLogEntry>();
        }

        public void LogResult(string library, Controller.JsonAction actionType, long duration, long allocations)
        {
            CSVLogEntry entry;
            logEntries.TryGetValue(library, out entry);
            if (entry == null)
            {
                entry = new CSVLogEntry();
                entry.library = library;
            }

            switch (actionType)
            {
                case Controller.JsonAction.Serialize:
                    entry.serialiseDurationMs = (int)duration;
                    if (duration < results.quickestSerialise.Item2)
                    {
                        results.quickestSerialise = (library, (int)duration);
                    }
                    
                    entry.serialiseAllocationsMB = (int)(allocations / 1048576);
                    if (allocations < results.leastAllocationsSerialise.Item2)
                    {
                        results.leastAllocationsSerialise = (library, entry.serialiseAllocationsMB);
                    }
                    break;
                case Controller.JsonAction.Deserialize:
                    entry.deserialiseDurationMs = (int)duration;
                    if (duration < results.quickestDeserialise.Item2)
                    {
                        results.quickestDeserialise = (library, (int)duration);
                    }
                    entry.deserialiseAllocationsMB = (int)(allocations / 1048576);
                    if (allocations < results.leastAllocationsDeserialise.Item2)
                    {
                        results.leastAllocationsDeserialise = (library, entry.serialiseAllocationsMB);
                    }
                    break;
            }

            logEntries[library] = entry;
        }
        
        public void OutputLog()
        {
            DateTime now = DateTime.Now;
            string logName = string.Concat(now.Year, now.Month, now.Day, now.Hour, now.Minute, ".csv");
            string fullPath = Path.Combine(Application.persistentDataPath, logName);

            UTF8Encoding utf8Encoding = new UTF8Encoding(true);
            
            try
            {
                FileStream _logFile = File.Create(fullPath);
                Debug.Log("Created new log session at path " + fullPath);

                string headers = "Library, Duration (Ser), Allocs (Ser), Duration (Des), Allocs (Des)\n";
                _logFile.Write(utf8Encoding.GetBytes(headers));

                foreach (var logEntryPair in logEntries)
                {
                    CSVLogEntry entry = logEntryPair.Value;
                    string logText = string.Concat(entry.library, ",", entry.serialiseDurationMs.ToString(), ",", 
                        entry.serialiseAllocationsMB.ToString(), ",", entry.deserialiseDurationMs.ToString(), ",", 
                        entry.deserialiseAllocationsMB.ToString(), "\n");
                    _logFile.Write(utf8Encoding.GetBytes(logText));
                }
                
                _logFile.Close();
            }
            catch (IOException e)
            {
                Debug.LogError("Couldn't write to csv file " + fullPath);
            }
        }
    }
}