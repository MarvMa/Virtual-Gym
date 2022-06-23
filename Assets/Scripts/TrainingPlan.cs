using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler
{
    public class TrainingPlan
    {
        public string name { get; set; }
        public string[] exercises { get; set; }
        public Difficulty difficulty { get; set; }
        public int duration { get; set; }
    }
}