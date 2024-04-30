using BenchmarkDotNet.Running;
using CompareTwoDictionaries;

Dictionary<int, string> dict1
    = new()
    {
        {1, "Rosary Ogechi"},
        {2, "Clare Chiamaka"},
    };

Dictionary<int, string> dict2
    = new()
    {
        {1, "Rosary Ogechi"},
        {2, "Clare Chiamaka"},
    };

DictionaryEqualityComparer.UseForeachLoop(dict1, dict2);

Dictionary<int, Teacher> teacherDict1
    = new()
    {
            { 1, new() {Name = "Rosary Ogechi", Age = 60} },
            { 2, new() {Name = "Clare Chiamaka", Age = 35} }
    };


Dictionary<int, Teacher> teacherDict2
    = new()
    {
            { 1, new() {Name = "Rosary Ogechi", Age = 60} },
            { 2, new() {Name = "Clare Chiamaka", Age = 35} }
    };

TeacherDictionaryEqualityComparer.UseComparer(teacherDict1, teacherDict2);

BenchmarkRunner.Run<DictionaryEqualityComparerBenchmark>();