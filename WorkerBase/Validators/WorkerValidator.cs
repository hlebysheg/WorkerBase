using WorkerBase.Helpers;
using WorkerBase.models;

namespace WorkerBase.Validators
{
    public static class WorkerValidator
    {
        private static bool isDateCorrect(DateTime birth, DateTime workDay)
        {
            return birth > workDay;
        }

        public static bool isWorkerCorrect (WorkerToCreate wr)
        {
            return isDateCorrect(wr.BirhtDay, wr.WorkDay);
        }

        public static bool isWorkerCorrect(Worker wr)
        {
            return isDateCorrect(wr.BirhtDay, wr.WorkDay);
        }
    }
}
