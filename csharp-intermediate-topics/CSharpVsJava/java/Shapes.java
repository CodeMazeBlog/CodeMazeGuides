sealed interface Shape permits Circle, Square {}
record Circle(double radius) implements Shape {}
record Square(double side) implements Shape {}

void main() {
    List<Shape> shapes = List.of(new Circle(1), new Square(2));
    for (var shape : shapes) {
        IO.println("%s: %.2f".formatted(shape, area(shape)));
    }
}

double area(Shape shape) {
    return switch (shape) {
        case Circle(double radius) -> Math.PI * radius * radius;
        case Square(double side) -> side * side;
    };
}
