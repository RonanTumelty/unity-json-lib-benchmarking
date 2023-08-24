using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Benchmarking.Logging
{
    public struct CSVLogEntry
    {
        public string library;
        public string serialiseDurationMs;
        public string serialiseAllocationsMB;
        public string deserialiseDurationMs;
        public string deserialiseAllocationsMB;

    }
    
    public class CSVLog
    {
        private FileStream _logFile;
        private bool fileHandleOpen = false;
        private string logName = "";
        private string fullPath = "";

        public CSVLog()
        {
            CreateNewLog();
        }
        
        public void CreateNewLog()
        {
            DateTime now = DateTime.Now;
            logName = string.Concat(now.Year, now.Month, now.Day, now.Hour, now.Minute, ".csv");
            fullPath = Path.Combine(Application.persistentDataPath, logName);
            
            try
            {
                _logFile = File.Create(fullPath);
                fileHandleOpen = true;
                Debug.Log("Created new log session at path " + fullPath);
            }
            catch (IOException e)
            {
                Debug.LogError("Couldn't open file at path " + fullPath);
            }
        }
        
        public void LogNewEntry(CSVLogEntry entry)
        {
            if (!fileHandleOpen)
            {
                Debug.LogError("No log file handle open");
                return;
            }

            try
            {
                string logText = string.Concat(entry.library, ",", entry.serialiseDurationMs, ",", entry.serialiseAllocationsMB,
                                 ",", entry.deserialiseDurationMs, ",", entry.deserialiseAllocationsMB, "\n");
                _logFile.Write(new UTF8Encoding(true).GetBytes(logText));
            }
            catch (IOException e)
            {
                Debug.LogError("Couldn't write to csv file " + fullPath);
            }
        }

        public void CloseFile()
        {
            if (fileHandleOpen)
            {
                _logFile.Close();
                _logFile = null;
                fileHandleOpen = false;
                Debug.Log("Closed file handle to " + fullPath);
            }
        }
    }
}