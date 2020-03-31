using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T2
{
    class UniqueList : List
    {

        public override void AddToListFront(int newData)
        {
            if (Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException($"Element {newData} is already in the list");
            }

            base.AddToListFront(newData);
        }
    }
}
