using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryThreeLayer2021.Common.Entities;
using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System.IO;

namespace LibraryThreeLayer2021.BLL.Real1BLL
{
    public class BLL1 : ILogic
    {
        private ILibDAO _dao;

        /*public BLL1(ILibDAO dao)
        {
            _dao = dao;
        }*/

        

        

        

        

        

        

        public bool ConvertByteArchToFileAndSave(BookFileContainer fileContainer)
        {
            if (fileContainer?.FileName == null || fileContainer?.FileName == "") throw new DirectoryNotFoundException("File path is invalid");


            using(FileStream fs = new FileStream(fileContainer.FileName, FileMode.OpenOrCreate))
            {
                fs.Write(fileContainer.BookFile, 0, fileContainer.BookFile.Length);
            }

            return true;
        }

        public BookFileContainer ConvertFileToByteArch(string fileNameAndPath)
        {
            string shortFileName = fileNameAndPath.Substring(fileNameAndPath.LastIndexOf('\\')+1);

            byte[] fileData;

            using(FileStream fs = new FileStream(fileNameAndPath, FileMode.Open))
            {
                fileData = new byte[fs.Length];

                fs.Read(fileData, 0, fileData.Length);
            }

            return new BookFileContainer(shortFileName, fileData);
        }

        

        

        

        

        

        

        

        

        



        

        

        

        

        

        

       

        

        

        

        

        

        

        

        

        

        
    }
}
