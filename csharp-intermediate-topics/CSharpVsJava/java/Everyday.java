record Money(BigDecimal amount) {
    Money add(Money other) {
        return new Money(amount.add(other.amount));
    }
}

class Product {
    private final String name;
    private Money price;

    Product(String name, Money price) {
        this.name = name;
        this.price = price;
    }

    String getName() { return name; }
    Money getPrice() { return price; }
    void setPrice(Money price) { this.price = price; }
}

void main() {
    var lamp = new Product("Desk lamp", new Money(new BigDecimal("30")));
    lamp.setPrice(lamp.getPrice().add(new Money(new BigDecimal("5"))));
    IO.println(lamp.getName() + " costs " + lamp.getPrice().amount());

    try {
        IO.println(Files.readString(Path.of("orders.csv")));
    } catch (IOException e) {
        IO.println("Could not read " + e.getMessage());
    }
}
