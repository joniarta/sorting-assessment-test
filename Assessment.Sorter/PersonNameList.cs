using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Assessment.Sorter
{
    public class PersonNameList : Collection<PersonName>
    {
        public PersonNameList() 
            : this(new List<PersonName>()) 
        { 
        
        }
        
        public PersonNameList(List<PersonName> list) 
            : base(list) 
        { 
        
        }
        
        public void Sort() 
        {
            ((List<PersonName>)Items).Sort((PersonName nameOne, PersonName nameTwo) =>
            {
                return nameOne.CompareTo(nameTwo);
            }); 
        }

        public static PersonNameList LoadFromFile(string file)
        {
            var names = new PersonNameList();

            using (var stream = new StreamReader(file))
            {
                while(!stream.EndOfStream)
                {
                    var name = stream.ReadLine();

                    if (!string.IsNullOrEmpty(name))
                    {
                        names.Add(new PersonName(name));
                    }
                }

                stream.Close();
            }

            return names;
        }

        public void SaveToFile(string destinationFile)
        {
            using (var stream = new StreamWriter(destinationFile, false))
            {
                foreach (var name in this)
                {
                    stream.WriteLine(name.Fullname);
                }

                stream.Flush();
                stream.Close();
            }
        }
    }
}
