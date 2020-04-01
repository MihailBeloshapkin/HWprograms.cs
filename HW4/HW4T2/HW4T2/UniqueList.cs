using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T2
{
    public class UniqueList : List
    {
        /// <summary>
        /// Add to list front and throw exception in case if newData is already contained into list.
        /// </summary>
        /// <param name="newData">Data that we want to add.</param>
        public override void AddToListFront(int newData)
        {
            if (Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException($"Element {newData} is already in the list");
            }

            base.AddToListFront(newData);
        }

        /// <summary>
        /// Add to list back and throw exception in case if newData is already contained into list.
        /// </summary>
        /// <param name="newData">Data that we want to add.</param>
        public override void AddToListBack(int newData)
        {
            if (Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException($"Element {newData} is already in the list");
            }

            base.AddToListBack(newData);
        }

        /// <summary>
        /// Delete from list front and throw an exception in case if the list is empty.
        /// </summary>
        public override void DeleteFromListFront()
        {
            if (base.Size() < 1)
            {
                throw new DeleteFromEmptyListException("Impossible to delete data from empty list.");
            }

            base.DeleteFromListFront();
        }

        /// <summary>
        /// Delete from list back and throw an exception in case if the list is empty.
        /// </summary>
        public override void DeleteFromListBack()
        {
            if (base.Size() < 1)
            {
                throw new DeleteFromEmptyListException("Impossible to delete data from empty list.");
            }

            base.DeleteFromListBack();
        }
    }
}
