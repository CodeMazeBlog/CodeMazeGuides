record Order(String customer, int quantity) {}

void main() {
    var orders = List.of(
        new Order("Ann", 3), new Order("Bob", 1), new Order("Ann", 4),
        new Order("Cid", 5), new Order("Bob", 2));

    orders.stream()
        .collect(Collectors.groupingBy(Order::customer, Collectors.summingInt(Order::quantity)))
        .entrySet().stream()
        .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
        .forEach(total -> IO.println(total.getKey() + ": " + total.getValue()));
}
