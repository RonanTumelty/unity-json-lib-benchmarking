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
        public long serialiseDurationMs;
        public long serialiseAllocationsMB;
        public long deserialiseDurationMs;
        public long deserialiseAllocationsMB;

    }
    
    public class CSVLog
    {
        private Dictionary<string, CSVLogEntry> logEntries;

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
                    entry.serialiseDurationMs = duration;
                    entry.serialiseAllocationsMB = allocations;
                    break;
                case Controller.JsonAction.Deserialize:
                    entry.deserialiseDurationMs = duration;
                    entry.deserialiseAllocationsMB = allocations;
                    break;
            }

            logEntries[library] = entry;
        }
        
        public void OutputLog()
        {
            DateTime now = DateTime.Now;
            string logName = string.Concat(now.Year, now.Month, now.Day, now.Hour, now.Minute, ".csv");
            string fullPath = Path.Combine(Application.persistentDataPath, logName);
            
            try
            {
                FileStream _logFile = File.Create(fullPath);
                Debug.Log("Created new log session at path " + fullPath);

                foreach (var logEntryPair in logEntries)
                {
                    CSVLogEntry entry = logEntryPair.Value;
                    string logText = string.Concat(entry.library, ",", entry.serialiseDurationMs.ToString(), ",", 
                        entry.serialiseAllocationsMB.ToString(), ",", entry.deserialiseDurationMs.ToString(), ",", 
                        entry.deserialiseAllocationsMB.ToString(), "\n");
                    _logFile.Write(new UTF8Encoding(true).GetBytes(logText));
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