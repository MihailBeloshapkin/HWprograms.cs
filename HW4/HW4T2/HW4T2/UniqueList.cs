﻿using System;
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
            if (base.Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException();
            }
            base.AddToListFront(newData);
        }

        /// <summary>
        /// Add to fixed list position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="newData"></param>
        public override void AddToListPosition(int position, int newData)
        {
            if (base.Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException();
            }
            base.AddToListPosition(position, newData);
        }

        /// <summary>
        /// Change element value by its position.
        /// </summary>
        /// <param name="position">Input position.</param>
        /// <param name="newData"></param>
        public override void ChangeElementByPosition(int position, int newData)
        {
            if (base.Contains(newData))
            {
                throw new AddDataThatIsAlreadyInTheListException();
            }

            base.ChangeElementByPosition(position, newData);
        }

        /// <summary>
        /// Delete from list front and throw an exception in case if the list is empty.
        /// </summary>
        public override void DeleteFromListFront()
        {
            base.DeleteFromListFront();
        }

        /// <summary>
        /// Delete from list back and throw an exception in case if the list is empty.
        /// </summary>
        public override void DeleteFromListBack()
        {
            base.DeleteFromListBack();
        }
    }
}
