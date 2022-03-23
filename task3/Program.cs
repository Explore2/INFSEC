using System;
using System.IO;

namespace task3
{
    internal class Program
    {
        private static void GenerateRandomKey(string keyPath)
        {
            int len = 256;
            byte[] arr = new byte[len];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (byte) i;
            }
            var rand = new Random();
            while (len > 1) 
            {
                int k = rand.Next(len--);
                var temp = arr[len];
                arr[len] = arr[k];
                arr[k] = temp;
            }
            using (StreamWriter sw = new StreamWriter(keyPath))
            {
                foreach (var num in arr)
                {
                   sw.WriteLine(num);
                }
            }
        }

        private static void CreateFileFromBytes(byte[] byteArray, string outputPath)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(outputPath)))
            {
                binaryWriter.Write(byteArray);
                binaryWriter.Close();
            }
        }

        private static byte[] GetByteFromFile(string filePath)
        {
            byte[] fileContent;
            var byteLength = new FileInfo(filePath).Length;
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(filePath)))
            {
                fileContent = binaryReader.ReadBytes((Int32)byteLength);
            }
            return fileContent;
        }

        private static byte[] GetKeyFromFile(string keyFilePath)
        {
            string[] keyFile = File.ReadAllLines(keyFilePath);
            byte[] keyArr = new byte[keyFile.Length];
            for (int i = 0; i < keyArr.Length; i++)
            {
                byte.TryParse(keyFile[i], out keyArr[i]);
            }
            return keyArr;
        }
        private static void Encrypt(string filePath, string keyFilePath, string outputPath)
        {

            byte[] keyArr = GetKeyFromFile(keyFilePath);
            byte[] fileContent = GetByteFromFile(filePath);
            byte[] encryptedFileContent = new byte[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
            {
                encryptedFileContent[i] = keyArr[fileContent[i]];
            }
            CreateFileFromBytes(encryptedFileContent, outputPath);
        }

        private static void Decrypt(string filePath, string keyFilePath, string outputPath)
        {
            byte[] keyArr = GetKeyFromFile(keyFilePath);
            byte[] encryptedFileContent = GetByteFromFile(filePath);
            byte[] decryptedFileContent = new byte[encryptedFileContent.Length];
            byte[] decryptKey = new byte[keyArr.Length];
            for (int i = 0; i < keyArr.Length; i++)
            {
                decryptKey[keyArr[i]] = (byte) i;
            }
            for (int i = 0; i < encryptedFileContent.Length; i++)
            {
                decryptedFileContent[i] = decryptKey[encryptedFileContent[i]];
            }
            CreateFileFromBytes(decryptedFileContent, outputPath);
        }
        public static void Main(string[] args)
        {
            const string keyPath = "C:/Users/Leonid/RiderProjects/INFSEC/task3/key.txt";
            const string filePath = "C:/Users/Leonid/RiderProjects/INFSEC/task3/test.png";
            const string encryptedFilePath = "C:/Users/Leonid/RiderProjects/INFSEC/task3/enc.png";
            const string decryptedFilePath = "C:/Users/Leonid/RiderProjects/INFSEC/task3/dec.png";
            GenerateRandomKey(keyPath);
            Encrypt(filePath, keyPath, encryptedFilePath);
            Decrypt(encryptedFilePath, keyPath, decryptedFilePath);
        }
    }
}