using System.Collections;
using System.Collections.Generic;
using DataHandler;
using UnityEngine;

namespace DataHandler
{
    /// <summary>
    /// Stores different exercices in a list
    /// </summary>
    [System.Serializable]
    public class ExercisesContainer
    {
        public List<Exercise> exercisesList;
    }
}
