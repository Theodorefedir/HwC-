using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHw
{
    public class FileManager
    {
        private string currentDir;
        private string rootDir;
        private int pos = 0;
        private bool IsStarted = false;

        public FileManager() {
            rootDir = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            currentDir = rootDir;
        }
        public List<FileInfo> GetFiles() { 
            var filesPath = Directory.GetFiles(currentDir);
            var files = filesPath.Select(fp => new FileInfo(fp));
            return files.ToList();
        }
        public List<DirectoryInfo> GetDirectories() { 
            var dirsPath = Directory.GetDirectories(currentDir);
            var dirs = dirsPath.Select(dp => new DirectoryInfo(dp));
            return dirs.ToList();
        }
        public void Stop() {
            IsStarted = false;
        }
        public void Start() {
            IsStarted = true;
            while (IsStarted) { 
                Console.Clear();
                Print();
                ConsoleKey key = Console.ReadKey(true).Key;
                KeyHandler(key);
            }
        }
        public int ItemsCount() { 
            return GetFiles().Count() + GetDirectories().Count();    
        }
        public void Print()
        {
            var dirs = GetDirectories();
            var files = GetFiles();
            int index = 0;

            foreach (var d in dirs)
            {
                if (index == pos)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"-> {d.Name}");
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine($"  {d.Name}");
                }
                index++;
            }
            foreach (var f in files)
            {
                if (index == pos)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"-> {f.Name}");
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine($"  {f.Name}");
                }
                index++;
            }
        }
        public void FileOpen(FileInfo file)
        {
            try
            {
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = file.FullName;
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }
            catch (Exception ex) {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }

        }
        public void Open()
        {
            var dirs = GetDirectories();
            var files = GetFiles();
            int total = dirs.Count + files.Count;
            if (pos < dirs.Count)
            {
                var dir = dirs[pos];
                pos = 0;
                currentDir = dir.FullName;
            }
            else if (pos >= dirs.Count && pos < total) {
                int fileIndex = pos - dirs.Count;
                FileOpen(files[fileIndex]);
            }
        }
        public void GoBack()
        {
            var parentDir = Directory.GetParent(currentDir);
            if (parentDir != null)
            {
                currentDir = parentDir.FullName;
                pos = 0;
            }
        }
        public void Delete() { 
            var dirs = GetDirectories();
            var files = GetFiles();
            int total = dirs.Count + files.Count;
            if (pos < dirs.Count)
            {
                Directory.Delete(dirs[pos].FullName, true);
            }
            else if (pos >= dirs.Count && pos < total) {
                int fileIndex = pos - dirs.Count;
                File.Delete(files[fileIndex].FullName);
            }
        }
        public void Rename() {
            var dirs = GetDirectories();
            var files = GetFiles();
            int total = dirs.Count + files.Count;

            Console.Clear();
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            if (pos < total) {
                if (pos < dirs.Count)
                {
                    string parentDir = Path.GetDirectoryName(dirs[pos].FullName);
                    string newFullName = Path.Combine(parentDir, newName);
                    Directory.Move(dirs[pos].FullName, newFullName);
                }
                else if (pos >= dirs.Count && pos < total) {
                    int fileIndex = pos - dirs.Count;
                    string parentDir = Path.GetDirectoryName(files[fileIndex].FullName);
                    string newFullName = Path.Combine(parentDir, newName);
                    File.Move(files[fileIndex].FullName, newFullName);
                }
            }

        }

        private void KeyHandler(ConsoleKey ck) {
            switch (ck) { 
                case ConsoleKey.UpArrow:
                    if (pos > 0) { 
                        pos--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (pos < ItemsCount() - 1)
                    {
                        pos++;
                    }
                    break;
                case ConsoleKey.Escape:
                    Stop();
                    break;
                case ConsoleKey.Enter:
                    Open();
                    break;
                case ConsoleKey.Home:
                    GoBack();
                    break;
                case ConsoleKey.Delete:
                    Delete();
                    break;
                case ConsoleKey.R:
                    Rename();
                    break;
            }
        }
        

    }
}
