List<Exercise> exercises = new List<Exercise>();
int choice = 0;
while (choice != 5)
{
    Console.WriteLine("--------------------------");
    Console.WriteLine("WORKOUT PROGRESS TRACKER");
    Console.WriteLine("--------------------------");
    Console.WriteLine("1. Add Exercise");
    Console.WriteLine("2. View Workout");
    Console.WriteLine("3. View Workout Volume");
    Console.WriteLine("4. Save Workout");
    Console.WriteLine("5. Exit");
    Console.WriteLine("--------------------------");
    Console.WriteLine();
    Console.WriteLine("Choose an option:");
    choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 1:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Add Exercise selected!");
            Console.WriteLine();

            Console.WriteLine("Enter Exercise Name: ");
            string exerciseName = Console.ReadLine()!;
            Console.WriteLine();

            Console.WriteLine("Enter Weight: ");
            int weight = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Console.WriteLine("Enter Sets: ");
            int sets = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Console.WriteLine("Enter Reps: ");
            int reps = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Exercise exercise = new Exercise(exerciseName, weight, sets, reps);
            exercises.Add(exercise);

            Console.WriteLine("Exercise Added: ");
            Console.WriteLine($"{exerciseName}: {weight}lbs - {sets} sets x {reps} reps.");
            break;
    
        case 2:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("View Workout Selected!");
            Console.WriteLine();

            if (exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                foreach (Exercise item in exercises)
                {
                    Console.WriteLine($"{item.Name}: {item.Weight}lbs - {item.Sets} sets x {item.Reps} reps");
                }
            }
            break;

        case 3:
            Console.WriteLine("View Workout Volume Selected");
            Console.WriteLine();

            int totalVolume = 0;
            if (exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                foreach (Exercise item in exercises)
                {
                    int volume = item.Weight * item.Sets * item.Reps;
                    totalVolume += volume;
                    Console.WriteLine($"{item.Name}: {volume} lbs");
                }

                Console.WriteLine();
                Console.WriteLine($"Total Workout Volume: {totalVolume} lbs");
            }
            break;

        case 4:
            Console.WriteLine("Save Workout Selected");
            break;

        case 5:
            Console.WriteLine("Exit Selected");
            break;

        default:
            Console.WriteLine("Invalid Input");
            break;
    }
    Console.WriteLine();
}



