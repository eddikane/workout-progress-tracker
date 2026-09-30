public class Workout
{
    public List<Exercise> Exercises { get; set; }

    public Workout()
    {
        Exercises = new List<Exercise>();
    }

    public int GetTotalVolume()
    {
        int totalVolume = 0;
        foreach (Exercise item in Exercises)
        {
            totalVolume += item.GetVolume();
        }
        return totalVolume;

    }

}
