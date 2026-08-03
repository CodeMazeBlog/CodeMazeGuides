namespace OptimisticVsPessimisticLocking;

public record AssignWorkItemRequest(long Id, string AssignedTo, bool ForceConflict = false);