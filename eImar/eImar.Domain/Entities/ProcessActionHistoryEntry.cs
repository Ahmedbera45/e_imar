// ...
public class ProcessActionHistoryEntry
{
    public int Id { get; set; }
    // ...
    public int ProcessActionId { get; set; } // Ref -> Id
    [ForeignKey("ProcessActionId")]
    public ProcessAction ProcessAction { get; set; } = null!;

    public int ProcessApplicationId { get; set; } // Ref -> Id
    [ForeignKey("ProcessApplicationId")]
    public ProcessApplication ProcessApplication { get; set; } = null!;
}
