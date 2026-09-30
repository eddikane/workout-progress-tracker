Workout workout = new Workout();
int choice = 0;
while (choice != 6)
{
    Console.WriteLine("--------------------------");
    Console.WriteLine("WORKOUT PROGRESS TRACKER");
    Console.WriteLine("--------------------------");
    Console.WriteLine("1. Add Exercise");
    Console.WriteLine("2. View Workout");
    Console.WriteLine("3. View Workout Volume");
    Console.WriteLine("4. Save Workout");
    Console.WriteLine("5. Load Workout");
    Console.WriteLine("6. Exit");
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
            workout.Exercises.Add(exercise);

            Console.WriteLine("Exercise Added: ");
            Console.WriteLine($"{exerciseName}: {weight}lbs - {sets} sets x {reps} reps.");
            break;
    
        case 2:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("View Workout Selected!");
            Console.WriteLine();

            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                foreach (Exercise item in workout.Exercises)
                {
                    Console.WriteLine($"{item.Name}: {item.Weight}lbs - {item.Sets} sets x {item.Reps} reps");
                }
            }
            break;

        case 3:
            Console.WriteLine("View Workout Volume Selected");
            Console.WriteLine();

            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                foreach (Exercise item in workout.Exercises)
                {
                    int volume = item.GetVolume();
                    Console.WriteLine($"{item.Name}: {volume} lbs");
                }

                int totalVolume = workout.GetTotalVolume();

                Console.WriteLine();
                Console.WriteLine($"Total Workout Volume: {totalVolume} lbs");
            }
            break;

        case 4:
            Console.WriteLine("Save Workout Selected");
            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises to save.");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("workout.txt"))
                {
                    foreach (Exercise item in workout.Exercises)
                    {
                        writer.WriteLine($"{item.Name},{item.Weight},{item.Sets},{item.Reps}");
                    } 
                }
            }
            Console.WriteLine("Workout saved successfully.");
            break;
            

        case 5:
            Console.WriteLine("Load Workout Selcted");

            if (!File.Exists("workout.txt"))
            {
                Console.WriteLine("No saved workout file found.");
            }
            else
            {
                string[] lines = File.ReadAllLines("workout.txt");

                workout.Exercises.Clear();
                
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                    int loadedWeight = int.Parse(parts[1]);
                    int loadedSets = int.Parse(parts[2]);
                    int loadedReps = int.Parse(parts[3]);

                    Exercise loadedExercise = new Exercise(name, loadedWeight, loadedSets, loadedReps);
                    workout.Exercises.Add(loadedExercise);
                }

            Console.WriteLine("Workout loaded successfully.");
            }

            break;


        case 6:
            Console.WriteLine("Exit Selected");
            break;

        default:
            Console.WriteLine("Invalid Input");
            break;
    }
    Console.WriteLine();
}



