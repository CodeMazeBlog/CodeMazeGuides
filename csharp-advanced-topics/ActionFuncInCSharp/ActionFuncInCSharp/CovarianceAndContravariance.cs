public class Parent { public string Name => this.GetType().Name; }
public class Child:Parent { public new string Name => this.GetType().Name; }