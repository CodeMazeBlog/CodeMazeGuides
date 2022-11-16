class Parent { public string Name => this.GetType().Name; }
class Child:Parent { public new string Name => this.GetType().Name; }