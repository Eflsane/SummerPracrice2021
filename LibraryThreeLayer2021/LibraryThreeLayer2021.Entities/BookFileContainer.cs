using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class BookFileContainer
    {
        public string FileName { get; set; }

        private byte[] _bookFile;
       
        public byte[] BookFile
        {
            get
            {
                byte[] getableFile = new byte[_bookFile.Length];

                if (_bookFile != null)
                {
                    for(int i = 0; i < _bookFile.Length; i++)
                    {
                        getableFile[i] = _bookFile[i];
                    }
                }
                return getableFile;
            }
            set => _bookFile = value;            
        }

        public BookFileContainer(string fileName, byte[] bookFile)
        {
            FileName = fileName;
            BookFile = bookFile;
        }

        public BookFileContainer()
        {

        }
    }
}
