namespace Tests;

// Hangfire exposes a single process-wide JobStorage.Current. These tests each
// configure or read it, so they must not run in parallel with one another.
[CollectionDefinition("HangfireStorage", DisableParallelization = true)]
public class HangfireStorageCollection;
