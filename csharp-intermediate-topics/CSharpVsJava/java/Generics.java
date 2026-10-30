void main() {
    var quantities = new ArrayList<Integer>(List.of(3, 1, 2));
    var customers = new ArrayList<String>(List.of("Ann", "Bob"));

    IO.println(quantities.getClass());
    IO.println(quantities.getClass() == customers.getClass());
    IO.println(describe(quantities, Integer.class));
}

<T> String describe(List<T> items, Class<T> type) {
    return items.size() + " items of type " + type.getSimpleName();
}
