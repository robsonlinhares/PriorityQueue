

new PriorityQueue().OrdernarItens();
new ComparadorCustomizado().Comparar();


public class PriorityQueue
{
    public void OrdernarItens()
    {
        var queue = new PriorityQueue<string, int>();
        queue.Enqueue("Item 1", 3);
        queue.Enqueue("Item 2", 2);
        queue.Enqueue("Item 3", 1);
        queue.Enqueue("Item 4", 0);

        while (queue.TryDequeue(out var item, out var priority))
            Console.WriteLine($"{item}. Prioridade: {priority}");
    }
}

public class ComparadorCustomizado
{
    public record Student(string Name);
    public void Comparar()
    {
        var queue = new PriorityQueue<Student, string>(new RoleComparer());

        queue.Enqueue(new Student("Spiderman"), "student");
        queue.Enqueue(new Student("Ironman"), "premium");
        queue.Enqueue(new Student("Batman"), "admin");

        while (queue.TryDequeue(out var item, out var priority))
            Console.WriteLine($"Aluno: {item.Name}. Prioridade: {priority}");
    }
}
public class RoleComparer : IComparer<string>
{
    public int Compare(string? roleA, string? roleB)
    {
        if (roleA == roleB)
            return 0;

        return roleA switch
        {
            "admin" => -1,
            "premium" => 0,
            _ => 1
        };
    }
}