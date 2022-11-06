using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Sorter
{
    public class PersonName : IComparable<PersonName>
    {
        private List<string> _structureparts;

        public string Fullname { get; }

        public IEnumerable<string> StructureParts { get { return this._structureparts; } }

        public PersonName(string fullname)
        {
            this.Fullname = fullname;

            this.ConstructStructureParts();
        }

        public int CompareTo(PersonName personName)
        {
            var result = 0;

            for (int i = 0; i < this.StructureParts.Count(); i++)
            {
                // Exit the loop if the length of the parts of the object
                // is greater then the object that needs to be compared
                if (i == personName.StructureParts.Count())
                {
                    break;
                }

                // compare the part of the two object using String built in function 
                // if the result is not zero then exit the loop
                // if equal to zero then continue to the next part of the name
                result = this.StructureParts.ElementAt(i).CompareTo(personName.StructureParts.ElementAt(i));

                if (result != 0)
                {
                    break;
                }
            }

            return result;
        }

        private void ConstructStructureParts()
        {
            // Split the name to parts using space as separator
            // and then add the part of the name to the list except for the last part.
            // the last part would be inserted in the beginning of the list.

            var splittedWords = this.Fullname.Split(" ");
            var lastIndex = splittedWords.Length - 1;

            this._structureparts = new List<string>();

            for (int i = 0; i < lastIndex; i++)
            {
                this._structureparts.Add(splittedWords[i]);
            }

            this._structureparts.Insert(0, splittedWords[lastIndex]);
        }
    }
}
