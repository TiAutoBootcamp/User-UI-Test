namespace Estore.CoreAdditional.Extensions
{
    public static class FileExtension
    {
        public static byte[] GetByteArray(string path)
        {
            string filePath = $"{Directory.GetCurrentDirectory()}{path}";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] fileBytes = new byte[fileStream.Length];
                int bytesRead = fileStream.Read(fileBytes, 0, fileBytes.Length);
                if (bytesRead < fileBytes.Length)
                {
                    throw new IOException("Could not read the entire file.");
                }

                return fileBytes;
            }
        }
    }
}
